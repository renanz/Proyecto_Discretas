namespace PPP
{
    partial class Menu
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.expertosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarExpertosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarExpertosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ponderarIndicadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expertosToolStripMenuItem,
            this.ponderarIndicadoresToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(673, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // expertosToolStripMenuItem
            // 
            this.expertosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarExpertosItem,
            this.listarExpertosItem});
            this.expertosToolStripMenuItem.Name = "expertosToolStripMenuItem";
            this.expertosToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.expertosToolStripMenuItem.Text = "Expertos";
            // 
            // agregarExpertosItem
            // 
            this.agregarExpertosItem.Name = "agregarExpertosItem";
            this.agregarExpertosItem.Size = new System.Drawing.Size(116, 22);
            this.agregarExpertosItem.Text = "Agregar";
            this.agregarExpertosItem.Click += new System.EventHandler(this.agregarExpertosItem_Click);
            // 
            // listarExpertosItem
            // 
            this.listarExpertosItem.Name = "listarExpertosItem";
            this.listarExpertosItem.Size = new System.Drawing.Size(116, 22);
            this.listarExpertosItem.Text = "Listar";
            this.listarExpertosItem.Click += new System.EventHandler(this.listarExpertosItem_Click);
            // 
            // ponderarIndicadoresToolStripMenuItem
            // 
            this.ponderarIndicadoresToolStripMenuItem.Name = "ponderarIndicadoresToolStripMenuItem";
            this.ponderarIndicadoresToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.ponderarIndicadoresToolStripMenuItem.Text = "Ponderar Indicadores";
            this.ponderarIndicadoresToolStripMenuItem.Click += new System.EventHandler(this.ponderarIndicadoresToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 357);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.ShowIcon = false;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem expertosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarExpertosItem;
        private System.Windows.Forms.ToolStripMenuItem listarExpertosItem;
        private System.Windows.Forms.ToolStripMenuItem ponderarIndicadoresToolStripMenuItem;
    }
}