namespace WebcamEffect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btTake = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btFormat = new System.Windows.Forms.ToolStripButton();
            this.btSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.colorFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.invertColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btFrame = new System.Windows.Forms.ToolStripDropDownButton();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btSave = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btTake
            // 
            this.btTake.AutoSize = false;
            this.btTake.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btTake.Image = ((System.Drawing.Image)(resources.GetObject("btTake.Image")));
            this.btTake.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTake.Name = "btTake";
            this.btTake.Size = new System.Drawing.Size(100, 22);
            this.btTake.Text = "Take Picture";
            this.btTake.Click += new System.EventHandler(this.btTake_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btFormat
            // 
            this.btFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btFormat.Image = ((System.Drawing.Image)(resources.GetObject("btFormat.Image")));
            this.btFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFormat.Name = "btFormat";
            this.btFormat.Size = new System.Drawing.Size(82, 22);
            this.btFormat.Text = "Video Format";
            this.btFormat.Click += new System.EventHandler(this.btFormat_Click);
            // 
            // btSource
            // 
            this.btSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btSource.Image = ((System.Drawing.Image)(resources.GetObject("btSource.Image")));
            this.btSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSource.Name = "btSource";
            this.btSource.Size = new System.Drawing.Size(80, 22);
            this.btSource.Text = "Video Source";
            this.btSource.Click += new System.EventHandler(this.btSource_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorFilterToolStripMenuItem,
            this.invertColorToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripSplitButton1.Text = "Effect";
            // 
            // colorFilterToolStripMenuItem
            // 
            this.colorFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem});
            this.colorFilterToolStripMenuItem.Name = "colorFilterToolStripMenuItem";
            this.colorFilterToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.colorFilterToolStripMenuItem.Text = "Color Filter";
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.redToolStripMenuItem.Items.AddRange(new object[] {
            "No Filter",
            "Black&White",
            "Red",
            "Green",
            "Blue"});
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(152, 23);
            this.redToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.redToolStripMenuItem_SelectedIndexChanged);
            // 
            // invertColorToolStripMenuItem
            // 
            this.invertColorToolStripMenuItem.Name = "invertColorToolStripMenuItem";
            this.invertColorToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.invertColorToolStripMenuItem.Text = "Invert Color";
            this.invertColorToolStripMenuItem.Click += new System.EventHandler(this.invertColorToolStripMenuItem_Click);
            // 
            // btFrame
            // 
            this.btFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btFrame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frameToolStripMenuItem});
            this.btFrame.Image = ((System.Drawing.Image)(resources.GetObject("btFrame.Image")));
            this.btFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFrame.Name = "btFrame";
            this.btFrame.Size = new System.Drawing.Size(78, 22);
            this.btFrame.Text = "Add Image";
            // 
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.frameToolStripMenuItem.Text = "Add Image";
            this.frameToolStripMenuItem.Click += new System.EventHandler(this.frameToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btSave
            // 
            this.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(35, 22);
            this.btSave.Text = "Save";
            this.btSave.Visible = false;
            this.btSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(508, 298);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btTake,
            this.toolStripSeparator1,
            this.btFormat,
            this.btSource,
            this.toolStripSeparator2,
            this.toolStripSplitButton1,
            this.btFrame,
            this.toolStripSeparator3,
            this.btSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(508, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(508, 323);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btTake;
        private System.Windows.Forms.ToolStripButton btFormat;
        private System.Windows.Forms.ToolStripButton btSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton btSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem colorFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton btFrame;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

