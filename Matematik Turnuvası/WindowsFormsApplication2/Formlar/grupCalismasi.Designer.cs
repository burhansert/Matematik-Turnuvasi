namespace WindowsFormsApplication2
{
    partial class grupCalismasi
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yeniGrupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yenniGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hizalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dikeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yatayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniGrupToolStripMenuItem,
            this.hizalaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // yeniGrupToolStripMenuItem
            // 
            this.yeniGrupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yenniGToolStripMenuItem});
            this.yeniGrupToolStripMenuItem.Name = "yeniGrupToolStripMenuItem";
            this.yeniGrupToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.yeniGrupToolStripMenuItem.Text = "Gruplar";
            this.yeniGrupToolStripMenuItem.Click += new System.EventHandler(this.yeniGrupToolStripMenuItem_Click);
            // 
            // yenniGToolStripMenuItem
            // 
            this.yenniGToolStripMenuItem.Name = "yenniGToolStripMenuItem";
            this.yenniGToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.yenniGToolStripMenuItem.Text = "Sınıf Seç";
            this.yenniGToolStripMenuItem.Click += new System.EventHandler(this.yenniGToolStripMenuItem_Click);
            // 
            // hizalaToolStripMenuItem
            // 
            this.hizalaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dikeyToolStripMenuItem,
            this.yatayToolStripMenuItem});
            this.hizalaToolStripMenuItem.Name = "hizalaToolStripMenuItem";
            this.hizalaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.hizalaToolStripMenuItem.Text = "Hizala";
            this.hizalaToolStripMenuItem.Click += new System.EventHandler(this.hizalaToolStripMenuItem_Click);
            // 
            // dikeyToolStripMenuItem
            // 
            this.dikeyToolStripMenuItem.Name = "dikeyToolStripMenuItem";
            this.dikeyToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.dikeyToolStripMenuItem.Text = "Dikey";
            this.dikeyToolStripMenuItem.Click += new System.EventHandler(this.dikeyToolStripMenuItem_Click);
            // 
            // yatayToolStripMenuItem
            // 
            this.yatayToolStripMenuItem.Name = "yatayToolStripMenuItem";
            this.yatayToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.yatayToolStripMenuItem.Text = "Yatay";
            this.yatayToolStripMenuItem.Click += new System.EventHandler(this.yatayToolStripMenuItem_Click);
            // 
            // grupCalismasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 603);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "grupCalismasi";
            this.Text = "grupCalismasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sorular_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniGrupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yenniGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hizalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dikeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yatayToolStripMenuItem;
    }
}