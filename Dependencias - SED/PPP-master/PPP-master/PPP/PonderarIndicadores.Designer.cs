namespace PPP
{
    partial class PonderarIndicadores
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
            this.lIndicadoresOrdenados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvIndicadores = new System.Windows.Forms.DataGridView();
            this.bFinalizar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndicadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lIndicadoresOrdenados
            // 
            this.lIndicadoresOrdenados.AutoSize = true;
            this.lIndicadoresOrdenados.Location = new System.Drawing.Point(33, 66);
            this.lIndicadoresOrdenados.Name = "lIndicadoresOrdenados";
            this.lIndicadoresOrdenados.Size = new System.Drawing.Size(467, 20);
            this.lIndicadoresOrdenados.TabIndex = 0;
            this.lIndicadoresOrdenados.Text = "Dar pesos de mayor a menor según el orden en que aparecen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Indicadores:";
            // 
            // dgvIndicadores
            // 
            this.dgvIndicadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndicadores.Location = new System.Drawing.Point(37, 89);
            this.dgvIndicadores.Name = "dgvIndicadores";
            this.dgvIndicadores.Size = new System.Drawing.Size(626, 250);
            this.dgvIndicadores.TabIndex = 2;
            // 
            // bFinalizar
            // 
            this.bFinalizar.Location = new System.Drawing.Point(145, 349);
            this.bFinalizar.Name = "bFinalizar";
            this.bFinalizar.Size = new System.Drawing.Size(182, 47);
            this.bFinalizar.TabIndex = 3;
            this.bFinalizar.Text = "Ponderar y Finalizar";
            this.bFinalizar.UseVisualStyleBackColor = true;
            this.bFinalizar.Click += new System.EventHandler(this.bFinalizar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(363, 349);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(159, 45);
            this.bCancelar.TabIndex = 4;
            this.bCancelar.Text = "Cancelar y Cerrar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(33, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Indicador ";
            this.label2.Visible = false;
            // 
            // PonderarIndicadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bFinalizar);
            this.Controls.Add(this.dgvIndicadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lIndicadoresOrdenados);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PonderarIndicadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ponderar Indicadores";
            this.Load += new System.EventHandler(this.PonderarIndicadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndicadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lIndicadoresOrdenados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvIndicadores;
        private System.Windows.Forms.Button bFinalizar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Label label2;
    }
}