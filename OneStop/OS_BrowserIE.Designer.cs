namespace OneStop
{
    partial class OS_Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OS_Browser));
            this.pnlBrowserChromium = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbForward = new System.Windows.Forms.ToolStripButton();
            this.tstxtURL = new System.Windows.Forms.ToolStripTextBox();
            this.tsbGo = new System.Windows.Forms.ToolStripButton();
            this.wbMain = new System.Windows.Forms.WebBrowser();
            this.pnlBrowserChromium.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowserChromium
            // 
            this.pnlBrowserChromium.AutoSize = true;
            this.pnlBrowserChromium.Controls.Add(this.toolStrip1);
            this.pnlBrowserChromium.Controls.Add(this.wbMain);
            this.pnlBrowserChromium.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBrowserChromium.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowserChromium.Name = "pnlBrowserChromium";
            this.pnlBrowserChromium.Size = new System.Drawing.Size(754, 531);
            this.pnlBrowserChromium.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBack,
            this.tsbForward,
            this.tstxtURL,
            this.tsbGo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(754, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBack
            // 
            this.tsbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbBack.Image")));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(23, 22);
            this.tsbBack.Text = "<";
            this.tsbBack.ToolTipText = "Back";
            this.tsbBack.Click += new System.EventHandler(this.tsbBack_Click);
            // 
            // tsbForward
            // 
            this.tsbForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbForward.Image = ((System.Drawing.Image)(resources.GetObject("tsbForward.Image")));
            this.tsbForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForward.Name = "tsbForward";
            this.tsbForward.Size = new System.Drawing.Size(23, 22);
            this.tsbForward.Text = ">";
            this.tsbForward.ToolTipText = "Forward";
            this.tsbForward.Click += new System.EventHandler(this.tsbForward_Click);
            // 
            // tstxtURL
            // 
            this.tstxtURL.Name = "tstxtURL";
            this.tstxtURL.Size = new System.Drawing.Size(200, 25);
            this.tstxtURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeys);
            // 
            // tsbGo
            // 
            this.tsbGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbGo.Image = ((System.Drawing.Image)(resources.GetObject("tsbGo.Image")));
            this.tsbGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGo.Name = "tsbGo";
            this.tsbGo.Size = new System.Drawing.Size(26, 22);
            this.tsbGo.Text = "Go";
            this.tsbGo.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // wbMain
            // 
            this.wbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMain.Location = new System.Drawing.Point(0, 0);
            this.wbMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMain.Name = "wbMain";
            this.wbMain.Size = new System.Drawing.Size(754, 531);
            this.wbMain.TabIndex = 1;
            // 
            // OS_Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 531);
            this.Controls.Add(this.pnlBrowserChromium);
            this.Name = "OS_Browser";
            this.Text = "OneStop Internal Browser: IE Engine";
            this.pnlBrowserChromium.ResumeLayout(false);
            this.pnlBrowserChromium.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBrowserChromium;
        private System.Windows.Forms.WebBrowser wbMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripButton tsbForward;
        private System.Windows.Forms.ToolStripTextBox tstxtURL;
        private System.Windows.Forms.ToolStripButton tsbGo;
    }
}