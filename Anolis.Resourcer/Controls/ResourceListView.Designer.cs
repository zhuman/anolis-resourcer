﻿namespace Anolis.Resourcer.Controls {
	partial class ResourceListView {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ToolStripSeparator @__cArrangeSep;
			this.@__list = new System.Windows.Forms.ListView();
			this.@__listCName = new System.Windows.Forms.ColumnHeader();
			this.@__listCSize = new System.Windows.Forms.ColumnHeader();
			this.@__listCType = new System.Windows.Forms.ColumnHeader();
			this.@__images = new System.Windows.Forms.ImageList(this.components);
			this.@__c = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.@__cView = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cViewThumbnails = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cViewTiles = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cViewIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cViewList = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cViewDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cArrange = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cArrangeName = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cArrangeSize = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cArrangeType = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cArrangeLang = new System.Windows.Forms.ToolStripMenuItem();
			this.@__cArrangeGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.@__t = new System.Windows.Forms.ToolStrip();
			this.@__sizeDetails = new System.Windows.Forms.ToolStripButton();
			this.@__size16 = new System.Windows.Forms.ToolStripButton();
			this.@__size32 = new System.Windows.Forms.ToolStripButton();
			this.@__size96 = new System.Windows.Forms.ToolStripButton();
			this.@__progessBar = new System.Windows.Forms.ToolStripProgressBar();
			this.@__bg = new System.ComponentModel.BackgroundWorker();
			@__cArrangeSep = new System.Windows.Forms.ToolStripSeparator();
			this.@__c.SuspendLayout();
			this.@__t.SuspendLayout();
			this.SuspendLayout();
			// 
			// __cArrangeSep
			// 
			@__cArrangeSep.Name = "__cArrangeSep";
			@__cArrangeSep.Size = new System.Drawing.Size(156, 6);
			// 
			// __list
			// 
			this.@__list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.@__listCName,
            this.@__listCSize,
            this.@__listCType});
			this.@__list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.@__list.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.@__list.LargeImageList = this.@__images;
			this.@__list.Location = new System.Drawing.Point(0, 25);
			this.@__list.Name = "__list";
			this.@__list.Size = new System.Drawing.Size(537, 319);
			this.@__list.TabIndex = 0;
			this.@__list.UseCompatibleStateImageBehavior = false;
			// 
			// __listCName
			// 
			this.@__listCName.Text = "Name";
			// 
			// __listCSize
			// 
			this.@__listCSize.Text = "Size";
			this.@__listCSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// __listCType
			// 
			this.@__listCType.Text = "Type";
			// 
			// __images
			// 
			this.@__images.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.@__images.ImageSize = new System.Drawing.Size(32, 32);
			this.@__images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// __c
			// 
			this.@__c.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__cView,
            this.@__cArrange});
			this.@__c.Name = "__c";
			this.@__c.Size = new System.Drawing.Size(169, 48);
			// 
			// __cView
			// 
			this.@__cView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__cViewThumbnails,
            this.@__cViewTiles,
            this.@__cViewIcons,
            this.@__cViewList,
            this.@__cViewDetails});
			this.@__cView.Name = "__cView";
			this.@__cView.Size = new System.Drawing.Size(168, 22);
			this.@__cView.Text = "View";
			// 
			// __cViewThumbnails
			// 
			this.@__cViewThumbnails.Name = "__cViewThumbnails";
			this.@__cViewThumbnails.Size = new System.Drawing.Size(138, 22);
			this.@__cViewThumbnails.Text = "Thumbnails";
			// 
			// __cViewTiles
			// 
			this.@__cViewTiles.Name = "__cViewTiles";
			this.@__cViewTiles.Size = new System.Drawing.Size(138, 22);
			this.@__cViewTiles.Text = "Tiles";
			// 
			// __cViewIcons
			// 
			this.@__cViewIcons.Name = "__cViewIcons";
			this.@__cViewIcons.Size = new System.Drawing.Size(138, 22);
			this.@__cViewIcons.Text = "Icons";
			// 
			// __cViewList
			// 
			this.@__cViewList.Name = "__cViewList";
			this.@__cViewList.Size = new System.Drawing.Size(138, 22);
			this.@__cViewList.Text = "List";
			// 
			// __cViewDetails
			// 
			this.@__cViewDetails.Name = "__cViewDetails";
			this.@__cViewDetails.Size = new System.Drawing.Size(138, 22);
			this.@__cViewDetails.Text = "Details";
			// 
			// __cArrange
			// 
			this.@__cArrange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__cArrangeName,
            this.@__cArrangeSize,
            this.@__cArrangeType,
            this.@__cArrangeLang,
            @__cArrangeSep,
            this.@__cArrangeGroup});
			this.@__cArrange.Name = "__cArrange";
			this.@__cArrange.Size = new System.Drawing.Size(168, 22);
			this.@__cArrange.Text = "Arrange Icons By";
			// 
			// __cArrangeName
			// 
			this.@__cArrangeName.Name = "__cArrangeName";
			this.@__cArrangeName.Size = new System.Drawing.Size(159, 22);
			this.@__cArrangeName.Text = "Name";
			// 
			// __cArrangeSize
			// 
			this.@__cArrangeSize.Name = "__cArrangeSize";
			this.@__cArrangeSize.Size = new System.Drawing.Size(159, 22);
			this.@__cArrangeSize.Text = "Size";
			// 
			// __cArrangeType
			// 
			this.@__cArrangeType.Name = "__cArrangeType";
			this.@__cArrangeType.Size = new System.Drawing.Size(159, 22);
			this.@__cArrangeType.Text = "Type";
			// 
			// __cArrangeLang
			// 
			this.@__cArrangeLang.Name = "__cArrangeLang";
			this.@__cArrangeLang.Size = new System.Drawing.Size(159, 22);
			this.@__cArrangeLang.Text = "Language";
			// 
			// __cArrangeGroup
			// 
			this.@__cArrangeGroup.Name = "__cArrangeGroup";
			this.@__cArrangeGroup.Size = new System.Drawing.Size(159, 22);
			this.@__cArrangeGroup.Text = "Show in Groups";
			// 
			// __t
			// 
			this.@__t.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.@__t.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__sizeDetails,
            this.@__size16,
            this.@__size32,
            this.@__size96,
            this.@__progessBar});
			this.@__t.Location = new System.Drawing.Point(0, 0);
			this.@__t.Name = "__t";
			this.@__t.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.@__t.Size = new System.Drawing.Size(537, 25);
			this.@__t.TabIndex = 1;
			this.@__t.Text = "toolStrip1";
			// 
			// __sizeDetails
			// 
			this.@__sizeDetails.CheckOnClick = true;
			this.@__sizeDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.@__sizeDetails.Image = global::Anolis.Resourcer.Resources.Details;
			this.@__sizeDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.@__sizeDetails.Name = "__sizeDetails";
			this.@__sizeDetails.Size = new System.Drawing.Size(23, 22);
			this.@__sizeDetails.Text = "Details View";
			// 
			// __size16
			// 
			this.@__size16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.@__size16.Image = global::Anolis.Resourcer.Resources.Icon16;
			this.@__size16.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.@__size16.Name = "__size16";
			this.@__size16.Size = new System.Drawing.Size(23, 22);
			this.@__size16.Text = "16x16";
			// 
			// __size32
			// 
			this.@__size32.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.@__size32.Image = global::Anolis.Resourcer.Resources.Icon32;
			this.@__size32.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.@__size32.Name = "__size32";
			this.@__size32.Size = new System.Drawing.Size(23, 22);
			this.@__size32.Text = "32x32";
			// 
			// __size96
			// 
			this.@__size96.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.@__size96.Image = global::Anolis.Resourcer.Resources.Icon96;
			this.@__size96.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.@__size96.Name = "__size96";
			this.@__size96.Size = new System.Drawing.Size(23, 22);
			this.@__size96.Text = "96x96";
			// 
			// __progessBar
			// 
			this.@__progessBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.@__progessBar.Name = "__progessBar";
			this.@__progessBar.Size = new System.Drawing.Size(150, 22);
			// 
			// __bg
			// 
			this.@__bg.WorkerReportsProgress = true;
			this.@__bg.WorkerSupportsCancellation = true;
			// 
			// ResourceListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.@__list);
			this.Controls.Add(this.@__t);
			this.Name = "ResourceListView";
			this.Size = new System.Drawing.Size(537, 344);
			this.@__c.ResumeLayout(false);
			this.@__t.ResumeLayout(false);
			this.@__t.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView __list;
		private System.Windows.Forms.ContextMenuStrip __c;
		private System.Windows.Forms.ToolStripMenuItem __cView;
		private System.Windows.Forms.ToolStripMenuItem __cViewThumbnails;
		private System.Windows.Forms.ToolStripMenuItem __cViewTiles;
		private System.Windows.Forms.ToolStripMenuItem __cViewIcons;
		private System.Windows.Forms.ToolStripMenuItem __cViewList;
		private System.Windows.Forms.ToolStripMenuItem __cViewDetails;
		private System.Windows.Forms.ToolStripMenuItem __cArrange;
		private System.Windows.Forms.ToolStripMenuItem __cArrangeName;
		private System.Windows.Forms.ToolStripMenuItem __cArrangeSize;
		private System.Windows.Forms.ToolStripMenuItem __cArrangeType;
		private System.Windows.Forms.ToolStripMenuItem __cArrangeLang;
		private System.Windows.Forms.ToolStripMenuItem __cArrangeGroup;
		private System.Windows.Forms.ToolStrip __t;
		private System.Windows.Forms.ToolStripProgressBar __progessBar;
		private System.ComponentModel.BackgroundWorker __bg;
		private System.Windows.Forms.ToolStripButton __size16;
		private System.Windows.Forms.ToolStripButton __size32;
		private System.Windows.Forms.ToolStripButton __size96;
		private System.Windows.Forms.ImageList __images;
		private System.Windows.Forms.ToolStripButton __sizeDetails;
		private System.Windows.Forms.ColumnHeader __listCName;
		private System.Windows.Forms.ColumnHeader __listCSize;
		private System.Windows.Forms.ColumnHeader __listCType;
	}
}
