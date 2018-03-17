namespace VirtualDesktopManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.removeButton = new System.Windows.Forms.Button();
			this.downButton = new System.Windows.Forms.Button();
			this.upButton = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.addFileButton = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.detailsGroup = new System.Windows.Forms.GroupBox();
			this.clearButton = new System.Windows.Forms.Button();
			this.browseButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.nameBox = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.detailsGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = global::VirtualDesktopManager.Properties.Resources.mainIco;
			this.notifyIcon1.Text = "Virtual Desktop Manager";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(128, 52);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.ForeColor = System.Drawing.Color.White;
			this.checkBox1.Location = new System.Drawing.Point(14, 54);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(396, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Use alternate key combination (Shift+Alt+Left/Right)";
			this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.BackColor = System.Drawing.Color.Black;
			this.groupBox1.Controls.Add(this.removeButton);
			this.groupBox1.Controls.Add(this.downButton);
			this.groupBox1.Controls.Add(this.upButton);
			this.groupBox1.Controls.Add(this.listView1);
			this.groupBox1.Controls.Add(this.addFileButton);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(8, 9);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Size = new System.Drawing.Size(593, 347);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Desktops";
			// 
			// removeButton
			// 
			this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeButton.BackColor = System.Drawing.Color.Black;
			this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.removeButton.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.removeButton.ForeColor = System.Drawing.Color.White;
			this.removeButton.Location = new System.Drawing.Point(181, 282);
			this.removeButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(144, 37);
			this.removeButton.TabIndex = 7;
			this.removeButton.Text = "Remove";
			this.removeButton.UseVisualStyleBackColor = false;
			this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
			// 
			// downButton
			// 
			this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.downButton.BackColor = System.Drawing.Color.Black;
			this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.downButton.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.downButton.ForeColor = System.Drawing.Color.White;
			this.downButton.Location = new System.Drawing.Point(539, 188);
			this.downButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.downButton.Name = "downButton";
			this.downButton.Size = new System.Drawing.Size(41, 37);
			this.downButton.TabIndex = 6;
			this.downButton.Text = "â";
			this.downButton.UseVisualStyleBackColor = false;
			this.downButton.Click += new System.EventHandler(this.downButton_Click);
			// 
			// upButton
			// 
			this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.upButton.BackColor = System.Drawing.Color.Black;
			this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.upButton.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.upButton.ForeColor = System.Drawing.Color.White;
			this.upButton.Location = new System.Drawing.Point(539, 128);
			this.upButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.upButton.Name = "upButton";
			this.upButton.Size = new System.Drawing.Size(41, 37);
			this.upButton.TabIndex = 5;
			this.upButton.Text = "á";
			this.upButton.UseVisualStyleBackColor = false;
			this.upButton.Click += new System.EventHandler(this.upButton_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(14, 98);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.ShowItemToolTips = true;
			this.listView1.Size = new System.Drawing.Size(508, 168);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Order";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Id";
			this.columnHeader2.Width = 85;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Name";
			this.columnHeader3.Width = 180;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Image";
			this.columnHeader4.Width = 160;
			// 
			// addFileButton
			// 
			this.addFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addFileButton.BackColor = System.Drawing.Color.Black;
			this.addFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.addFileButton.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.addFileButton.ForeColor = System.Drawing.Color.White;
			this.addFileButton.Location = new System.Drawing.Point(14, 282);
			this.addFileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.addFileButton.Name = "addFileButton";
			this.addFileButton.Size = new System.Drawing.Size(163, 37);
			this.addFileButton.TabIndex = 3;
			this.addFileButton.Text = "Add background";
			this.addFileButton.UseVisualStyleBackColor = false;
			this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// detailsGroup
			// 
			this.detailsGroup.Controls.Add(this.clearButton);
			this.detailsGroup.Controls.Add(this.browseButton);
			this.detailsGroup.Controls.Add(this.saveButton);
			this.detailsGroup.Controls.Add(this.pictureBox);
			this.detailsGroup.Controls.Add(this.nameBox);
			this.detailsGroup.Enabled = false;
			this.detailsGroup.Font = new System.Drawing.Font("Segoe UI", 20.29091F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.detailsGroup.ForeColor = System.Drawing.Color.White;
			this.detailsGroup.Location = new System.Drawing.Point(8, 362);
			this.detailsGroup.Name = "detailsGroup";
			this.detailsGroup.Size = new System.Drawing.Size(593, 193);
			this.detailsGroup.TabIndex = 4;
			this.detailsGroup.TabStop = false;
			this.detailsGroup.Text = "Details";
			// 
			// clearButton
			// 
			this.clearButton.BackColor = System.Drawing.Color.Black;
			this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.clearButton.Font = new System.Drawing.Font("Segoe UI", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clearButton.Location = new System.Drawing.Point(233, 103);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(144, 37);
			this.clearButton.TabIndex = 4;
			this.clearButton.Text = "Clear Image";
			this.clearButton.UseVisualStyleBackColor = false;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// browseButton
			// 
			this.browseButton.BackColor = System.Drawing.Color.Black;
			this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseButton.Font = new System.Drawing.Font("Segoe UI", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.browseButton.Location = new System.Drawing.Point(233, 150);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(144, 37);
			this.browseButton.TabIndex = 3;
			this.browseButton.Text = "Browse...";
			this.browseButton.UseVisualStyleBackColor = false;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.BackColor = System.Drawing.Color.Black;
			this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.saveButton.Font = new System.Drawing.Font("Segoe UI", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveButton.Location = new System.Drawing.Point(14, 150);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(144, 37);
			this.saveButton.TabIndex = 2;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = false;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(383, 48);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(194, 139);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 1;
			this.pictureBox.TabStop = false;
			// 
			// nameBox
			// 
			this.nameBox.Location = new System.Drawing.Point(14, 48);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new System.Drawing.Size(363, 49);
			this.nameBox.TabIndex = 0;
			this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(609, 567);
			this.Controls.Add(this.detailsGroup);
			this.Controls.Add(this.groupBox1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Virtual Desktop Manager";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.detailsGroup.ResumeLayout(false);
			this.detailsGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion



        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.GroupBox detailsGroup;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button addFileButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox nameBox;
	}
}

