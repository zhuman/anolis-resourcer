﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Anolis.Core;
using Anolis.Packages;
using System.Threading;

namespace Anolis.Packager {
	
	public partial class ConditionEditor : Form {
		
		public ConditionEditor() {
			InitializeComponent();
			
			__expression.Font = new Font(FontFamily.GenericMonospace, __expression.Font.SizeInPoints );
			
			__eval  .Click += new EventHandler(__eval_Click);
			__tok   .Click += new EventHandler(__tok_Click);
			
			__ok    .Click += new EventHandler(__ok_Click);
			__cancel.Click += new EventHandler(__cancel_Click);
			
			__dbgBack.Click += new EventHandler(__dbgBack_Click);
			__dbgNext.Click += new EventHandler(__dbgNext_Click);
			
		}
		
		private void __cancel_Click(object sender, EventArgs e) {
			
			this.Close();
		}
		
		private void __ok_Click(object sender, EventArgs e) {
			
			DialogResult = DialogResult.OK;
			
			this.Close();
		}
		
		public String Expression {
			get { return __expression.Text; }
			set { __expression.Text = value; }
		}
		
		private Dictionary<String,Double> GetSymbols() {
			
			Dictionary<String,Double> symbols = new Dictionary<string,double>();
			
			foreach( DataGridViewRow row in __symbols.Rows ) {
				
				String name = row.Cells[0].Value as String;
				String sval = row.Cells[1].Value as String;
				
				Double dval;
				if( Double.TryParse( sval, out dval ) )
					symbols.Add( name, dval );
			}
			
			return symbols;
			
		}
		
		private void __tok_Click(object sender, EventArgs e) {
			
			// TODO: Use the tokenizing code in Expression instead
			
			String expr = __expression.Text;
			__result.Text = "";
			
			List<String> tokens = new List<String>();
			
			Int32 i=0;
			while( i < expr.Length ) {
				
				String tok = expr.Tok(ref i);
				
				if( i < expr.Length ) tokens.Add( tok );
			}
			
			for(i=0;i<tokens.Count;i++) {
				
				__result.Text += tokens[i];
				if( i != tokens.Count - 1 ) __result.Text += ", ";
			}
			
		}
		
		private void __eval_Click(object sender, EventArgs e) {
			
			_stateOverTime.Clear();
			_stateIdx = 0;
			
			Expression expr = new Expression( __expression.Text );
			
			expr.StackChanged += new EventHandler(expr_StackChanged);
			
			String exMessage;
			
			try {
				
				Double result = expr.Evaluate( GetSymbols() );
				
				exMessage = result.ToString();
			
			} catch(ExpressionException ex) {
				
				exMessage = ex.Message;
				
			} catch(Exception ex) {
				
				exMessage = "Unhandled: " + ex.Message;
				
			}
			
			__result.Text = exMessage;
			
		}
		
		private class ExpressionState {
			
			public Operator[] OperatorStack;
			public Double[]   ValueStack;
			public Double     Value;
			
		}
		
		private List<ExpressionState> _stateOverTime = new List<ExpressionState>();
		private Int32 _stateIdx = 0;
		
		private void expr_StackChanged(object sender, EventArgs e) {
			
			Expression expr = sender as Expression;
			
			ExpressionState state = new ExpressionState() {
				OperatorStack = expr.CurrentOperatorStack,
				ValueStack    = expr.CurrentValueStack,
				Value         = expr.CurrentValue
			};
			
			_stateOverTime.Add( state );
			
		}
		
		private void ShowState(ExpressionState state) {
			
			__dbgOpStack .Items.Clear();
			__dbgValStack.Items.Clear();
			
			foreach(Operator op in state.OperatorStack) __dbgOpStack .Items.Add( Anolis.Packages.Expression.OperatorSymbols[ op ] );
			foreach(Double   db in state.ValueStack   ) __dbgValStack.Items.Add( db );
			
			__dbgVal.Text = state.Value.ToString();
			
		}
		
		private void __dbgNext_Click(object sender, EventArgs e) {
			
			__dbgBack.Enabled = true;
			
			ShowState( _stateOverTime[ _stateIdx++ ] );
			
			if( _stateIdx >= _stateOverTime.Count ) __dbgNext.Enabled = false;
			
		}
		
		private void __dbgBack_Click(object sender, EventArgs e) {
			
			__dbgNext.Enabled = true;
			
			ShowState( _stateOverTime[ --_stateIdx ] );
			
			if( _stateIdx == -1 ) __dbgBack.Enabled = false;
			
		}
		
	}
}
