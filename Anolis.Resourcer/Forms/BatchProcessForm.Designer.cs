﻿namespace Anolis.Resourcer {
	partial class BatchProcessForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.@__optionsGrp = new System.Windows.Forms.GroupBox();
			this.@__exportLongNames = new System.Windows.Forms.CheckBox();
			this.@__exportDirectoryLbl = new System.Windows.Forms.Label();
			this.@__exportDirectory = new System.Windows.Forms.TextBox();
			this.@__exportBrowse = new System.Windows.Forms.Button();
			this.@__exportNonvisual = new System.Windows.Forms.CheckBox();
			this.@__exportSkipCommonplace = new System.Windows.Forms.CheckBox();
			this.@__exportNonvisualSize = new System.Windows.Forms.CheckBox();
			this.@__exportNonvisualSizeNum = new System.Windows.Forms.NumericUpDown();
			this.@__exportNonvisualSizeLbl = new System.Windows.Forms.Label();
			this.@__exportIconSubimages = new System.Windows.Forms.CheckBox();
			this.@__sourceDirBrowse = new System.Windows.Forms.Button();
			this.@__sourceDirLbl = new System.Windows.Forms.Label();
			this.@__sourceRecurse = new System.Windows.Forms.CheckBox();
			this.@__sourceGrp = new System.Windows.Forms.GroupBox();
			this.@__sourceFileRad = new System.Windows.Forms.RadioButton();
			this.@__sourceFileLbl = new System.Windows.Forms.Label();
			this.@__sourceFile = new System.Windows.Forms.TextBox();
			this.@__sourceFileBrowse = new System.Windows.Forms.Button();
			this.@__sourceDirRad = new System.Windows.Forms.RadioButton();
			this.@__sourceDir = new System.Windows.Forms.TextBox();
			this.@__sourceFilterLbl = new System.Windows.Forms.Label();
			this.@__sourceFilter = new System.Windows.Forms.TextBox();
			this.@__process = new System.Windows.Forms.Button();
			this.@__progGrp = new System.Windows.Forms.GroupBox();
			this.@__progSourceLbl = new System.Windows.Forms.Label();
			this.@__progSource = new System.Windows.Forms.ProgressBar();
			this.@__progOverallLbl = new System.Windows.Forms.Label();
			this.@__progOverall = new System.Windows.Forms.ProgressBar();
			this.@__close = new System.Windows.Forms.Button();
			this.@__fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.@__sfd = new System.Windows.Forms.SaveFileDialog();
			this.@__error = new System.Windows.Forms.ErrorProvider(this.components);
			this.@__bw = new System.ComponentModel.BackgroundWorker();
			this.@__ofd = new System.Windows.Forms.OpenFileDialog();
			this.@__optionsGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__exportNonvisualSizeNum)).BeginInit();
			this.@__sourceGrp.SuspendLayout();
			this.@__progGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__error)).BeginInit();
			this.SuspendLayout();
			// 
			// __optionsGrp
			// 
			this.@__optionsGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__optionsGrp.Controls.Add(this.@__exportLongNames);
			this.@__optionsGrp.Controls.Add(this.@__exportDirectoryLbl);
			this.@__optionsGrp.Controls.Add(this.@__exportDirectory);
			this.@__optionsGrp.Controls.Add(this.@__exportBrowse);
			this.@__optionsGrp.Controls.Add(this.@__exportNonvisual);
			this.@__optionsGrp.Controls.Add(this.@__exportSkipCommonplace);
			this.@__optionsGrp.Controls.Add(this.@__exportNonvisualSize);
			this.@__optionsGrp.Controls.Add(this.@__exportNonvisualSizeNum);
			this.@__optionsGrp.Controls.Add(this.@__exportNonvisualSizeLbl);
			this.@__optionsGrp.Controls.Add(this.@__exportIconSubimages);
			this.@__optionsGrp.Location = new System.Drawing.Point(12, 186);
			this.@__optionsGrp.Name = "__optionsGrp";
			this.@__optionsGrp.Size = new System.Drawing.Size(589, 163);
			this.@__optionsGrp.TabIndex = 1;
			this.@__optionsGrp.TabStop = false;
			this.@__optionsGrp.Text = "Export Options";
			// 
			// __exportLongNames
			// 
			this.@__exportLongNames.AutoSize = true;
			this.@__exportLongNames.Location = new System.Drawing.Point(116, 137);
			this.@__exportLongNames.Name = "__exportLongNames";
			this.@__exportLongNames.Size = new System.Drawing.Size(259, 17);
			this.@__exportLongNames.TabIndex = 19;
			this.@__exportLongNames.Text = "Always include resource language ID in filenames";
			this.@__exportLongNames.UseVisualStyleBackColor = true;
			// 
			// __exportDirectoryLbl
			// 
			this.@__exportDirectoryLbl.Location = new System.Drawing.Point(6, 22);
			this.@__exportDirectoryLbl.Name = "__exportDirectoryLbl";
			this.@__exportDirectoryLbl.Size = new System.Drawing.Size(104, 20);
			this.@__exportDirectoryLbl.TabIndex = 13;
			this.@__exportDirectoryLbl.Text = "Export Directory";
			this.@__exportDirectoryLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// __exportDirectory
			// 
			this.@__exportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__exportDirectory.Location = new System.Drawing.Point(116, 19);
			this.@__exportDirectory.Name = "__exportDirectory";
			this.@__exportDirectory.Size = new System.Drawing.Size(372, 20);
			this.@__exportDirectory.TabIndex = 0;
			// 
			// __exportBrowse
			// 
			this.@__exportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__exportBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.@__exportBrowse.Location = new System.Drawing.Point(506, 17);
			this.@__exportBrowse.Name = "__exportBrowse";
			this.@__exportBrowse.Size = new System.Drawing.Size(75, 23);
			this.@__exportBrowse.TabIndex = 1;
			this.@__exportBrowse.Text = "Browse...";
			this.@__exportBrowse.UseVisualStyleBackColor = true;
			// 
			// __exportNonvisual
			// 
			this.@__exportNonvisual.AutoSize = true;
			this.@__exportNonvisual.Location = new System.Drawing.Point(116, 45);
			this.@__exportNonvisual.Name = "__exportNonvisual";
			this.@__exportNonvisual.Size = new System.Drawing.Size(156, 17);
			this.@__exportNonvisual.TabIndex = 6;
			this.@__exportNonvisual.Text = "Export non-visual resources";
			this.@__exportNonvisual.UseVisualStyleBackColor = true;
			// 
			// __exportSkipCommonplace
			// 
			this.@__exportSkipCommonplace.AutoSize = true;
			this.@__exportSkipCommonplace.Checked = true;
			this.@__exportSkipCommonplace.CheckState = System.Windows.Forms.CheckState.Checked;
			this.@__exportSkipCommonplace.Enabled = false;
			this.@__exportSkipCommonplace.Location = new System.Drawing.Point(128, 68);
			this.@__exportSkipCommonplace.Name = "__exportSkipCommonplace";
			this.@__exportSkipCommonplace.Size = new System.Drawing.Size(227, 17);
			this.@__exportSkipCommonplace.TabIndex = 14;
			this.@__exportSkipCommonplace.Text = "Skip Version, MUI, and Manifest resources";
			this.@__exportSkipCommonplace.UseVisualStyleBackColor = true;
			// 
			// __exportNonvisualSize
			// 
			this.@__exportNonvisualSize.AutoSize = true;
			this.@__exportNonvisualSize.Enabled = false;
			this.@__exportNonvisualSize.Location = new System.Drawing.Point(128, 91);
			this.@__exportNonvisualSize.Name = "__exportNonvisualSize";
			this.@__exportNonvisualSize.Size = new System.Drawing.Size(232, 17);
			this.@__exportNonvisualSize.TabIndex = 15;
			this.@__exportNonvisualSize.Text = "Only export non-visual resources larger than";
			this.@__exportNonvisualSize.UseVisualStyleBackColor = true;
			// 
			// __exportNonvisualSizeNum
			// 
			this.@__exportNonvisualSizeNum.Enabled = false;
			this.@__exportNonvisualSizeNum.Location = new System.Drawing.Point(363, 90);
			this.@__exportNonvisualSizeNum.Maximum = new decimal(new int[] {
            2097152,
            0,
            0,
            0});
			this.@__exportNonvisualSizeNum.Name = "__exportNonvisualSizeNum";
			this.@__exportNonvisualSizeNum.Size = new System.Drawing.Size(60, 20);
			this.@__exportNonvisualSizeNum.TabIndex = 18;
			this.@__exportNonvisualSizeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.@__exportNonvisualSizeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// __exportNonvisualSizeLbl
			// 
			this.@__exportNonvisualSizeLbl.AutoSize = true;
			this.@__exportNonvisualSizeLbl.Enabled = false;
			this.@__exportNonvisualSizeLbl.Location = new System.Drawing.Point(423, 93);
			this.@__exportNonvisualSizeLbl.Name = "__exportNonvisualSizeLbl";
			this.@__exportNonvisualSizeLbl.Size = new System.Drawing.Size(21, 13);
			this.@__exportNonvisualSizeLbl.TabIndex = 17;
			this.@__exportNonvisualSizeLbl.Text = "KB";
			// 
			// __exportIconSubimages
			// 
			this.@__exportIconSubimages.AutoSize = true;
			this.@__exportIconSubimages.Location = new System.Drawing.Point(116, 114);
			this.@__exportIconSubimages.Name = "__exportIconSubimages";
			this.@__exportIconSubimages.Size = new System.Drawing.Size(238, 17);
			this.@__exportIconSubimages.TabIndex = 7;
			this.@__exportIconSubimages.Text = "Export Icon and Cursor subimages (as PNGs)";
			this.@__exportIconSubimages.UseVisualStyleBackColor = true;
			// 
			// __sourceDirBrowse
			// 
			this.@__sourceDirBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__sourceDirBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.@__sourceDirBrowse.Location = new System.Drawing.Point(506, 90);
			this.@__sourceDirBrowse.Name = "__sourceDirBrowse";
			this.@__sourceDirBrowse.Size = new System.Drawing.Size(75, 23);
			this.@__sourceDirBrowse.TabIndex = 1;
			this.@__sourceDirBrowse.Text = "Browse...";
			this.@__sourceDirBrowse.UseVisualStyleBackColor = true;
			// 
			// __sourceDirLbl
			// 
			this.@__sourceDirLbl.Location = new System.Drawing.Point(23, 95);
			this.@__sourceDirLbl.Name = "__sourceDirLbl";
			this.@__sourceDirLbl.Size = new System.Drawing.Size(87, 20);
			this.@__sourceDirLbl.TabIndex = 4;
			this.@__sourceDirLbl.Text = "Directory";
			this.@__sourceDirLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// __sourceRecurse
			// 
			this.@__sourceRecurse.AutoSize = true;
			this.@__sourceRecurse.Checked = true;
			this.@__sourceRecurse.CheckState = System.Windows.Forms.CheckState.Checked;
			this.@__sourceRecurse.Location = new System.Drawing.Point(116, 144);
			this.@__sourceRecurse.Name = "__sourceRecurse";
			this.@__sourceRecurse.Size = new System.Drawing.Size(130, 17);
			this.@__sourceRecurse.TabIndex = 3;
			this.@__sourceRecurse.Text = "Search Subdirectories";
			this.@__sourceRecurse.UseVisualStyleBackColor = true;
			// 
			// __sourceGrp
			// 
			this.@__sourceGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__sourceGrp.Controls.Add(this.@__sourceFileRad);
			this.@__sourceGrp.Controls.Add(this.@__sourceFileLbl);
			this.@__sourceGrp.Controls.Add(this.@__sourceFile);
			this.@__sourceGrp.Controls.Add(this.@__sourceFileBrowse);
			this.@__sourceGrp.Controls.Add(this.@__sourceDirRad);
			this.@__sourceGrp.Controls.Add(this.@__sourceDirLbl);
			this.@__sourceGrp.Controls.Add(this.@__sourceDir);
			this.@__sourceGrp.Controls.Add(this.@__sourceDirBrowse);
			this.@__sourceGrp.Controls.Add(this.@__sourceFilterLbl);
			this.@__sourceGrp.Controls.Add(this.@__sourceFilter);
			this.@__sourceGrp.Controls.Add(this.@__sourceRecurse);
			this.@__sourceGrp.Location = new System.Drawing.Point(12, 12);
			this.@__sourceGrp.Name = "__sourceGrp";
			this.@__sourceGrp.Size = new System.Drawing.Size(589, 168);
			this.@__sourceGrp.TabIndex = 0;
			this.@__sourceGrp.TabStop = false;
			this.@__sourceGrp.Text = "Source";
			// 
			// __sourceFileRad
			// 
			this.@__sourceFileRad.AutoSize = true;
			this.@__sourceFileRad.Location = new System.Drawing.Point(11, 19);
			this.@__sourceFileRad.Name = "__sourceFileRad";
			this.@__sourceFileRad.Size = new System.Drawing.Size(73, 17);
			this.@__sourceFileRad.TabIndex = 8;
			this.@__sourceFileRad.Text = "Single File";
			this.@__sourceFileRad.UseVisualStyleBackColor = true;
			// 
			// __sourceFileLbl
			// 
			this.@__sourceFileLbl.Location = new System.Drawing.Point(23, 43);
			this.@__sourceFileLbl.Name = "__sourceFileLbl";
			this.@__sourceFileLbl.Size = new System.Drawing.Size(87, 20);
			this.@__sourceFileLbl.TabIndex = 11;
			this.@__sourceFileLbl.Text = "File Name";
			this.@__sourceFileLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// __sourceFile
			// 
			this.@__sourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__sourceFile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.@__sourceFile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.@__sourceFile.Location = new System.Drawing.Point(116, 39);
			this.@__sourceFile.Name = "__sourceFile";
			this.@__sourceFile.Size = new System.Drawing.Size(372, 20);
			this.@__sourceFile.TabIndex = 12;
			// 
			// __sourceFileBrowse
			// 
			this.@__sourceFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__sourceFileBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.@__sourceFileBrowse.Location = new System.Drawing.Point(506, 38);
			this.@__sourceFileBrowse.Name = "__sourceFileBrowse";
			this.@__sourceFileBrowse.Size = new System.Drawing.Size(75, 23);
			this.@__sourceFileBrowse.TabIndex = 10;
			this.@__sourceFileBrowse.Text = "Browse...";
			this.@__sourceFileBrowse.UseVisualStyleBackColor = true;
			// 
			// __sourceDirRad
			// 
			this.@__sourceDirRad.AutoSize = true;
			this.@__sourceDirRad.Location = new System.Drawing.Point(11, 68);
			this.@__sourceDirRad.Name = "__sourceDirRad";
			this.@__sourceDirRad.Size = new System.Drawing.Size(67, 17);
			this.@__sourceDirRad.TabIndex = 9;
			this.@__sourceDirRad.Text = "Directory";
			this.@__sourceDirRad.UseVisualStyleBackColor = true;
			// 
			// __sourceDir
			// 
			this.@__sourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__sourceDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.@__sourceDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.@__sourceDir.Location = new System.Drawing.Point(116, 91);
			this.@__sourceDir.Name = "__sourceDir";
			this.@__sourceDir.Size = new System.Drawing.Size(372, 20);
			this.@__sourceDir.TabIndex = 7;
			// 
			// __sourceFilterLbl
			// 
			this.@__sourceFilterLbl.Location = new System.Drawing.Point(11, 121);
			this.@__sourceFilterLbl.Name = "__sourceFilterLbl";
			this.@__sourceFilterLbl.Size = new System.Drawing.Size(99, 17);
			this.@__sourceFilterLbl.TabIndex = 6;
			this.@__sourceFilterLbl.Text = "File Extension Filter";
			this.@__sourceFilterLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// __sourceFilter
			// 
			this.@__sourceFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__sourceFilter.Location = new System.Drawing.Point(116, 118);
			this.@__sourceFilter.Name = "__sourceFilter";
			this.@__sourceFilter.Size = new System.Drawing.Size(372, 20);
			this.@__sourceFilter.TabIndex = 2;
			this.@__sourceFilter.Text = "*.exe;*.dll;*.scr;*.msstyles;*.ocx;*.cpl;*.mui";
			// 
			// __process
			// 
			this.@__process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.@__process.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.@__process.Location = new System.Drawing.Point(445, 471);
			this.@__process.Name = "__process";
			this.@__process.Size = new System.Drawing.Size(75, 23);
			this.@__process.TabIndex = 3;
			this.@__process.Text = "Export";
			this.@__process.UseVisualStyleBackColor = true;
			// 
			// __progGrp
			// 
			this.@__progGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__progGrp.Controls.Add(this.@__progSourceLbl);
			this.@__progGrp.Controls.Add(this.@__progSource);
			this.@__progGrp.Controls.Add(this.@__progOverallLbl);
			this.@__progGrp.Controls.Add(this.@__progOverall);
			this.@__progGrp.Location = new System.Drawing.Point(12, 355);
			this.@__progGrp.Name = "__progGrp";
			this.@__progGrp.Size = new System.Drawing.Size(589, 107);
			this.@__progGrp.TabIndex = 2;
			this.@__progGrp.TabStop = false;
			this.@__progGrp.Text = "Progress";
			// 
			// __progSourceLbl
			// 
			this.@__progSourceLbl.AutoSize = true;
			this.@__progSourceLbl.Location = new System.Drawing.Point(8, 22);
			this.@__progSourceLbl.Name = "__progSourceLbl";
			this.@__progSourceLbl.Size = new System.Drawing.Size(67, 13);
			this.@__progSourceLbl.TabIndex = 0;
			this.@__progSourceLbl.Text = "0% complete";
			// 
			// __progSource
			// 
			this.@__progSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__progSource.Location = new System.Drawing.Point(11, 38);
			this.@__progSource.Name = "__progSource";
			this.@__progSource.Size = new System.Drawing.Size(570, 14);
			this.@__progSource.TabIndex = 1;
			// 
			// __progOverallLbl
			// 
			this.@__progOverallLbl.AutoSize = true;
			this.@__progOverallLbl.Location = new System.Drawing.Point(8, 63);
			this.@__progOverallLbl.Name = "__progOverallLbl";
			this.@__progOverallLbl.Size = new System.Drawing.Size(114, 13);
			this.@__progOverallLbl.TabIndex = 2;
			this.@__progOverallLbl.Text = "0% complete - 0/0 files";
			// 
			// __progOverall
			// 
			this.@__progOverall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__progOverall.Location = new System.Drawing.Point(11, 80);
			this.@__progOverall.Name = "__progOverall";
			this.@__progOverall.Size = new System.Drawing.Size(570, 14);
			this.@__progOverall.TabIndex = 3;
			// 
			// __close
			// 
			this.@__close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.@__close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.@__close.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.@__close.Location = new System.Drawing.Point(526, 471);
			this.@__close.Name = "__close";
			this.@__close.Size = new System.Drawing.Size(75, 23);
			this.@__close.TabIndex = 4;
			this.@__close.Text = "Close";
			this.@__close.UseVisualStyleBackColor = true;
			// 
			// __error
			// 
			this.@__error.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.@__error.ContainerControl = this;
			// 
			// BatchProcessForm
			// 
			this.AcceptButton = this.@__process;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.CancelButton = this.@__close;
			this.ClientSize = new System.Drawing.Size(613, 505);
			this.Controls.Add(this.@__sourceGrp);
			this.Controls.Add(this.@__optionsGrp);
			this.Controls.Add(this.@__progGrp);
			this.Controls.Add(this.@__process);
			this.Controls.Add(this.@__close);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BatchProcessForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Batch Export";
			this.@__optionsGrp.ResumeLayout(false);
			this.@__optionsGrp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__exportNonvisualSizeNum)).EndInit();
			this.@__sourceGrp.ResumeLayout(false);
			this.@__sourceGrp.PerformLayout();
			this.@__progGrp.ResumeLayout(false);
			this.@__progGrp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__error)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox __optionsGrp;
		private System.Windows.Forms.Button __sourceDirBrowse;
		private System.Windows.Forms.Label __sourceDirLbl;
		private System.Windows.Forms.CheckBox __sourceRecurse;
		private System.Windows.Forms.GroupBox __sourceGrp;
		private System.Windows.Forms.TextBox __sourceFilter;
		private System.Windows.Forms.Label __sourceFilterLbl;
		private System.Windows.Forms.GroupBox __progGrp;
		private System.Windows.Forms.ProgressBar __progOverall;
		private System.Windows.Forms.ProgressBar __progSource;
		private System.Windows.Forms.Button __process;
		private System.Windows.Forms.Label __progOverallLbl;
		private System.Windows.Forms.Label __progSourceLbl;
		private System.Windows.Forms.Button __close;
		private System.Windows.Forms.CheckBox __exportNonvisual;
		private System.Windows.Forms.TextBox __exportDirectory;
		private System.Windows.Forms.Button __exportBrowse;
		private System.Windows.Forms.Label __exportDirectoryLbl;
		private System.Windows.Forms.FolderBrowserDialog __fbd;
		private System.Windows.Forms.SaveFileDialog __sfd;
		private System.Windows.Forms.ErrorProvider __error;
		private System.ComponentModel.BackgroundWorker __bw;
		private System.Windows.Forms.CheckBox __exportIconSubimages;
		private System.Windows.Forms.CheckBox __exportSkipCommonplace;
		private System.Windows.Forms.CheckBox __exportNonvisualSize;
		private System.Windows.Forms.Label __exportNonvisualSizeLbl;
		private System.Windows.Forms.NumericUpDown __exportNonvisualSizeNum;
		private System.Windows.Forms.TextBox __sourceDir;
		private System.Windows.Forms.RadioButton __sourceDirRad;
		private System.Windows.Forms.RadioButton __sourceFileRad;
		private System.Windows.Forms.Label __sourceFileLbl;
		private System.Windows.Forms.TextBox __sourceFile;
		private System.Windows.Forms.Button __sourceFileBrowse;
		private System.Windows.Forms.OpenFileDialog __ofd;
		private System.Windows.Forms.CheckBox __exportLongNames;
	}
}