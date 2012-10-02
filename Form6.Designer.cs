namespace ReportSystem
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mAXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vALUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tYPEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView8
            // 
            this.dataGridView8.AllowUserToAddRows = false;
            this.dataGridView8.AllowUserToDeleteRows = false;
            this.dataGridView8.AllowUserToResizeColumns = false;
            this.dataGridView8.AllowUserToResizeRows = false;
            this.dataGridView8.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView8.GridColor = System.Drawing.Color.Gray;
            this.dataGridView8.Location = new System.Drawing.Point(12, 12);
            this.dataGridView8.MultiSelect = false;
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.RowHeadersVisible = false;
            this.dataGridView8.RowHeadersWidth = 178;
            this.dataGridView8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView8.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView8.Size = new System.Drawing.Size(780, 595);
            this.dataGridView8.TabIndex = 17;
            this.dataGridView8.Resize += new System.EventHandler(this.dataGridView8_Resize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mINToolStripMenuItem,
            this.mAXToolStripMenuItem,
            this.rATEToolStripMenuItem,
            this.vALUEToolStripMenuItem,
            this.tYPEToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(108, 19);
            this.toolStripDropDownButton1.Text = "SHOW OPTIONS";
            // 
            // mINToolStripMenuItem
            // 
            this.mINToolStripMenuItem.Checked = true;
            this.mINToolStripMenuItem.CheckOnClick = true;
            this.mINToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mINToolStripMenuItem.Name = "mINToolStripMenuItem";
            this.mINToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.mINToolStripMenuItem.Text = "MIN";
            this.mINToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tYPEToolStripMenuItem_CheckedChanged);
            // 
            // mAXToolStripMenuItem
            // 
            this.mAXToolStripMenuItem.Checked = true;
            this.mAXToolStripMenuItem.CheckOnClick = true;
            this.mAXToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mAXToolStripMenuItem.Name = "mAXToolStripMenuItem";
            this.mAXToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.mAXToolStripMenuItem.Text = "MAX";
            this.mAXToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tYPEToolStripMenuItem_CheckedChanged);
            // 
            // rATEToolStripMenuItem
            // 
            this.rATEToolStripMenuItem.Checked = true;
            this.rATEToolStripMenuItem.CheckOnClick = true;
            this.rATEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rATEToolStripMenuItem.Name = "rATEToolStripMenuItem";
            this.rATEToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.rATEToolStripMenuItem.Text = "RATE";
            this.rATEToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tYPEToolStripMenuItem_CheckedChanged);
            // 
            // vALUEToolStripMenuItem
            // 
            this.vALUEToolStripMenuItem.Checked = true;
            this.vALUEToolStripMenuItem.CheckOnClick = true;
            this.vALUEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vALUEToolStripMenuItem.Name = "vALUEToolStripMenuItem";
            this.vALUEToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.vALUEToolStripMenuItem.Text = "VALUE";
            this.vALUEToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tYPEToolStripMenuItem_CheckedChanged);
            // 
            // tYPEToolStripMenuItem
            // 
            this.tYPEToolStripMenuItem.Checked = true;
            this.tYPEToolStripMenuItem.CheckOnClick = true;
            this.tYPEToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tYPEToolStripMenuItem.Name = "tYPEToolStripMenuItem";
            this.tYPEToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.tYPEToolStripMenuItem.Text = "TYPE";
            this.tYPEToolStripMenuItem.CheckedChanged += new System.EventHandler(this.tYPEToolStripMenuItem_CheckedChanged);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(804, 632);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.Resize += new System.EventHandler(this.Form6_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem mINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vALUEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tYPEToolStripMenuItem;
    }
}