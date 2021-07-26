﻿using System;
using System.Windows.Forms;

using System.Net;
using System.Reflection;

using Anolis.Core.Utility;
using Anolis.Resourcer.Settings;

namespace Anolis.Resourcer {
	
	public partial class OptionsForm : BaseForm {
		
		public OptionsForm() {
			InitializeComponent();
			
			this.Load += new EventHandler(OptionsForm_Load);
			
			this.__ok.Click += new EventHandler(__ok_Click);
			this.__update.Click += new EventHandler(__update_Click);
			
			//////////////////////////////
			// Settings
			
			this.__sAssoc.Click += new EventHandler(__sAssoc_Click);
			this.__sAssoc.Tag = false;

			this.__sGimmick.Click += new EventHandler(__sGimmick_Click);
			
			this.__sLibAdd.Click += new EventHandler(__sLibAdd_Click);
			this.__sLibDel.Click += new EventHandler(__sLibDel_Click);
			this.__sLib.SelectedIndexChanged += new EventHandler(__sLib_SelectedIndexChanged);
			
			//////////////////////////////
			// About
			
			this.__aboutLinkCodeplex.Click += new EventHandler(__aboutLink_Click);
			this.__aboutLinkAnolis  .Click += new EventHandler(__aboutLink_Click);
			
			//////////////////////////////
			// Legal
			
			this.__legalToggle.Click += new EventHandler(__legalToggle_Click);
			this.__legalToggle.Tag = false;
			
		}
		
		private static ARSettings S {
			get { return ARSettings.Default; }
		}
		
		public MainForm MainForm { get; set; }
		
		public OptionsFormPage SelectedPage {
			get {
				if( __tabs.SelectedTab == __tSettings ) return OptionsFormPage.Settings;
				if( __tabs.SelectedTab == __tLegal    ) return OptionsFormPage.Legal;
				if( __tabs.SelectedTab == __tAbout    ) return OptionsFormPage.About;
				return OptionsFormPage.None;
			}
			set {
				switch(value) {
					case OptionsFormPage.None:
						throw new ArgumentOutOfRangeException("Must be a valid page");
					case OptionsFormPage.Settings:
						__tabs.SelectedTab = __tSettings; return;
					case OptionsFormPage.About:
						__tabs.SelectedTab = __tAbout; return;
					case OptionsFormPage.Legal:
						__tabs.SelectedTab = __tLegal; return;
				}
			}
		}
		
		private void OptionsForm_Load(object sender, EventArgs e) {
			
			__legalText.Text = Anolis.Resources.Properties.Resources.LegalOverview;
			
			LoadVersion();
			
			LoadSettings();
		}
		
		private void LoadVersion() {
			
			String assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			
			__aboutVersion.Text = assemblyVersion;
		}
		
#region Settings
		
		private void LoadSettings() {
			
			//////////////////////////////
			// Toolbar Size
			__sUIButtonsLarge.Checked = !S.Toolbar24;
			
			//////////////////////////////
			// Gimmicks
			__sGimmick.Checked = S.Gimmicks;
			
			//////////////////////////////
			// File Associations
			TriState isAssoc = S.IsAssociatedWithFiles;
			
			__sAssoc.CheckState =
				isAssoc == TriState.True  ? CheckState.Checked : 
				isAssoc == TriState.False ? CheckState.Unchecked : CheckState.Indeterminate;
			
			__sAssoc.Enabled = Miscellaneous.IsElevatedAdministrator;
			
			//////////////////////////////
			// Load Assemblies
			if( S.LoadAssemblies != null ) {
				
				foreach( String filename in S.LoadAssemblies ) {
					
					LibraryEntry ent = new LibraryEntry( filename );
					__sLib.Items.Add( ent );
					
				}
				
			}
			
		}
		
		private void SaveSettings() {
			
			//////////////////////////////
			// Toolbar Size
			S.Toolbar24 = !__sUIButtonsLarge.Checked;
			
			//////////////////////////////
			// File Associations
			if( __sAssoc.Enabled && (Boolean)__sAssoc.Tag && __sAssoc.CheckState != CheckState.Indeterminate ) {
				S.AssociateWithFiles( __sAssoc.Checked );
			}
			
			//////////////////////////////
			// Gimmicks
			S.Gimmicks = __sGimmick.Checked;
			
			//////////////////////////////
			// Load Assemblies
			if( S.LoadAssemblies == null ) S.LoadAssemblies = new System.Collections.Specialized.StringCollection();
			S.LoadAssemblies.Clear();
			foreach(LibraryEntry ent in __sLib.Items) {
				
				S.LoadAssemblies.Add( ent.Filename );
			}
			
			S.Save();
		}
		
		private void __sAssoc_Click(object sender, EventArgs e) {
			__sAssoc.Tag = true; // the tag just means the checkbox has had its value updated
		}
		
		private void __sGimmick_Click(object sender, EventArgs e) {
			
		}
		
		////////////////////////////////////////////////
		
		private class LibraryEntry {
			public LibraryEntry(String filename) { Filename = filename; }
			public String Filename;
			public override string ToString() {
				return Miscellaneous.TrimPath( Filename, 60 );
			}
		}
		
		private void __sLibAdd_Click(object sender, EventArgs e) {
			
			if( __ofd.ShowDialog(this) != DialogResult.OK ) return;
			
			String filename = __ofd.FileName;
			
			if( !System.IO.File.Exists( filename ) ) return;
			
			if( __sLib.Items.Contains( filename ) ) return;
			
			if( Miscellaneous.IsAssembly( filename ) ) {
				
				LibraryEntry ent = new LibraryEntry( filename );
				
				__sLib.Items.Add( ent );
				
			} else {
				
				MessageBox.Show(this, "The specified file is not a Managed Assembly", "Anolis Resourcer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				
			}
			
		}
		
		private void __sLibDel_Click(object sender, EventArgs e) {
			
			if( __sLib.SelectedItem != null ) __sLib.Items.Remove( __sLib.SelectedItem );
			
		}
		
		private void __sLib_SelectedIndexChanged(object sender, EventArgs e) {
			
			__sLibDel.Enabled = __sLib.SelectedItem != null;
		}
		
#endregion
		
#region Updates
		
		public static void CheckForUpdates(IWin32Window window) {
			
			WebClient w = new WebClient();
			
			Int32 updBuild;
			
			String downloadLink = "http://www.anol.is/download.php";
			
			try {
				String version = w.DownloadString("http://www.anol.is/resourcer/versionInfo.txt");
				
				String[] strs = version.Replace("\r", "").Split('\n');
				if(strs.Length < 2) throw new FormatException("Split version string's length was less than 2");
				
				updBuild = Int32.Parse( strs[0] );
				downloadLink = strs[1];
			
			} catch(WebException wex) {
				
				MessageBox.Show(window, "Unable to download information about the latest version, the error was: " + wex.Message, "Anolis Resourcer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
				
			} catch(FormatException fex) {
				
				MessageBox.Show(window, "Unable to read information about the latest version, the error was: " + fex.Message, "Anolis Resourcer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
				
			}
			
			// get this version
			Assembly thisAssembly = Assembly.GetAssembly( typeof(OptionsForm) );
			AssemblyName name = thisAssembly.GetName();
			Int32 thisBuild = name.Version.Build;
			
			if( updBuild > thisBuild ) {
				
				DialogResult r = MessageBox.Show(window, "There is an updated version of Anolis Resourcer available. Would you like to download it?", "Anolis Resourcer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
				
				if( r == DialogResult.Yes ) {
					
					System.Diagnostics.Process.Start( downloadLink );
					
				}
				
			} else if( updBuild == thisBuild ) {
				
				MessageBox.Show(window, "You already have the most recent build of Resourcer", "Anolis Resourcer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				
			} else {
				
				MessageBox.Show(window, "You have a more recent build of Resourcer than is publically available", "Anolis Resourcer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			}
		
		}
		
#endregion
		
#region About
		
		private void __aboutLink_Click(Object sender, EventArgs e) {
			
			LinkLabel link = sender as LinkLabel;
			
			String url = link.Text.Substring( link.LinkArea.Start, link.LinkArea.Length - link.LinkArea.Start );
			
			System.Diagnostics.Process.Start( url );
			
		}
		
#endregion
		
		
#region Legal
		
		private void __legalToggle_Click(object sender, EventArgs e) {
			
			Boolean showOverview = (Boolean)__legalToggle.Tag;
			
			__legalText.Text = showOverview ? Anolis.Resources.Properties.Resources.LegalOverview : Anolis.Resources.Properties.Resources.LegalGpl;
			
			__legalToggle.Text = showOverview ? "Show GPLv2 License" : "Show License Overview";
			
			__legalToggle.Tag = !showOverview;
		}
		
#endregion
		
#region Misc
		
		private void __ok_Click(Object sender, EventArgs e) {
			
			SaveSettings();
			
			DialogResult = DialogResult.OK;
			
			Close();
			
		}
		
		private void __update_Click(object sender, EventArgs e) {
			
			CheckForUpdates( this );
		}
		
#endregion
		
	}
	
	public enum OptionsFormPage {
		None = 0,
		Settings,
		About,
		Legal
	}
	
}
