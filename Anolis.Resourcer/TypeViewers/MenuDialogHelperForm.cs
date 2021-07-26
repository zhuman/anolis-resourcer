﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Anolis.Core.Utility;

namespace Anolis.Resourcer.TypeViewers {
	
	public partial class MenuDialogHelperForm : Form {
		
		public MenuDialogHelperForm() {
			InitializeComponent();
		}
		
		public MenuStrip DialogMenu { get { return __menu; } }
		
		public void LoadMenu(DialogMenu menu) {
			
			__menu.Items.Clear();
			
			LoadMenu( __menu.Items, menu.Root );
			
		}
		
		private void LoadMenu(ToolStripItemCollection target, DialogMenuItem item) {
			
			foreach(DialogMenuItem child in item.Children) {
				
				ToolStripMenuItem i = new ToolStripMenuItem( child.Text );
				
				target.Add( i );
				
				if(child.Children.Count > 0) {
					
					LoadMenu( i.DropDownItems, child );
				}
			}
			
		}
		
		public void LoadDialog(Dialog dialog) {
			
			this.Controls.Clear();
			
			// TODO: In future, consider calling the actual dialog functions to show the dialog
			// and just use this form for editing dialogs
			
			this.Size     = Correct( dialog.Size );
			this.Location = Correct( dialog.Location );
			this.Text     = String.IsNullOrEmpty( dialog.Text ) ? "Untitled" : dialog.Text;
			
			foreach(DialogControl ctrl in dialog.Controls) {
				
				Control c = CreateControl(ctrl);
				
				c.Size     = Correct( ctrl.Size );
				c.Location = Correct( ctrl.Location );
				c.Text     = String.IsNullOrEmpty( ctrl.Text ) ? "Untitled" : ctrl.Text;
				
				this.Controls.Add( c );
			}
			
		}
		
		private static Point Correct(Point point) {
			
			return new Point( Correct( new Size( point ) ) );
		}
		
		/// <summary>Converts a DLU size into a screen pixel size</summary>
		private static Size Correct(Size size) {
			
			// HACK: Presume 8pt Tahoma
			
			// from: http://msdn.microsoft.com/en-us/library/bb847924.aspx
			// x = 1.5 * x
			// y = 1.625 * y
			
			return new Size( (int)(size.Width * 1.5), (int)(size.Height * 1.625) );
			
		}
		
		private static Control CreateControl(DialogControl ctrl) {
			
			return new Button();
		}
		
	}
}
