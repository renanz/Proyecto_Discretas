namespace PPP
{
    partial class OrdenarIndicadores
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
            this.lExperto = new System.Windows.Forms.Label();
            this.lbIndicadores = new System.Windows.Forms.ListBox();
            this.bIncrementar = new System.Windows.Forms.Button();
            this.bDecrementar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lMensaje = new System.Windows.Forms.Label();
            this.bFinalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lExperto
            // 
            this.lExperto.AutoSize = true;
            this.lExperto.Location = new System.Drawing.Point(30, 54);
            this.lExperto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lExperto.Name = "lExperto";
            this.lExperto.Size = new System.Drawing.Size(78, 21);
            this.lExperto.TabIndex = 0;
            this.lExperto.Text = "Experto: ";
            // 
            // lbIndicadores
            // 
            this.lbIndicadores.FormattingEnabled = true;
            this.lbIndicadores.ItemHeight = 21;
            this.lbIndicadores.Location = new System.Drawing.Point(34, 94);
            this.lbIndicadores.Name = "lbIndicadores";
            this.lbIndicadores.Size = new System.Drawing.Size(148, 235);
            this.lbIndicadores.TabIndex = 1;
            // 
            // bIncrementar
            // 
            this.bIncrementar.Location = new System.Drawing.Point(225, 165);
            this.bIncrementar.Name = "bIncrementar";
            this.bIncrementar.Size = new System.Drawing.Size(75, 34);
            this.bIncrementar.TabIndex = 2;
            this.bIncrementar.Text = "↑";
            this.toolTip1.SetToolTip(this.bIncrementar, "Aumentar importancia al indicador");
            this.bIncrementar.UseVisualStyleBackColor = true;
            this.bIncrementar.Click += new System.EventHandler(this.bIncrementar_Click);
            // 
            // bDecrementar
            // 
            this.bDecrementar.Location = new System.Drawing.Point(225, 205);
            this.bDecrementar.Name = "bDecrementar";
            this.bDecrementar.Size = new System.Drawing.Size(75, 33);
            this.bDecrementar.TabIndex = 3;
            this.bDecrementar.Text = "↓";
            this.toolTip1.SetToolTip(this.bDecrementar, "Disminuir importancia al indicador");
            this.bDecrementar.UseVisualStyleBackColor = true;
            this.bDecrementar.Click += new System.EventHandler(this.bDecrementar_Click);
            // 
            // lMensaje
            // 
            this.lMensaje.AutoSize = true;
            this.lMensaje.Location = new System.Drawing.Point(300, 94);
            this.lMensaje.Name = "lMensaje";
            this.lMensaje.Size = new System.Drawing.Size(0, 21);
            this.lMensaje.TabIndex = 4;
            // 
            // bFinalizar
            // 
            this.bFinalizar.Location = new System.Drawing.Point(206, 278);
            this.bFinalizar.Name = "bFinalizar";
            this.bFinalizar.Size = new System.Drawing.Size(108, 34);
            this.bFinalizar.TabIndex = 5;
            this.bFinalizar.Text = "Finalizar";
            this.bFinalizar.UseVisualStyleBackColor = true;
            this.bFinalizar.Click += new System.EventHandler(this.bFinalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Escalar Importancia ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Indicador General ";
            this.label2.Visible = false;
            // 
            // OrdenarIndicadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 345);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bFinalizar);
            this.Controls.Add(this.lMensaje);
            this.Controls.Add(this.bDecrementar);
            this.Controls.Add(this.bIncrementar);
            this.Controls.Add(this.lbIndicadores);
            this.Controls.Add(this.lExperto);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OrdenarIndicadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenar Indicadores";
            this.Load += new System.EventHandler(this.OrdenarIndicadores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lExperto;
        private System.Windows.Forms.ListBox lbIndicadores;
        private System.Windows.Forms.Button bIncrementar;
        private System.Windows.Forms.Button bDecrementar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lMensaje;
        private System.Windows.Forms.Button bFinalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}