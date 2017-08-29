namespace PPP
{
    partial class ListarExpertos
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
            this.dgvExpertos = new System.Windows.Forms.DataGridView();
            this.bSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpertos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvExpertos
            // 
            this.dgvExpertos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvExpertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpertos.Location = new System.Drawing.Point(27, 31);
            this.dgvExpertos.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvExpertos.Name = "dgvExpertos";
            this.dgvExpertos.Size = new System.Drawing.Size(757, 237);
            this.dgvExpertos.TabIndex = 0;
            // 
            // bSalir
            // 
            this.bSalir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalir.Location = new System.Drawing.Point(314, 281);
            this.bSalir.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(141, 33);
            this.bSalir.TabIndex = 6;
            this.bSalir.Text = "Salir";
            this.bSalir.UseVisualStyleBackColor = true;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // ListarExpertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 325);
            this.ControlBox = false;
            this.Controls.Add(this.bSalir);
            this.Controls.Add(this.dgvExpertos);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ListarExpertos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listar Expertos";
            this.Load += new System.EventHandler(this.ListarExpertos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpertos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExpertos;
        private System.Windows.Forms.Button bSalir;
    }
}