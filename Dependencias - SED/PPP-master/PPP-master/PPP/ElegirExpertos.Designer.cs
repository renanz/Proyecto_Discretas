namespace PPP
{
    partial class ElegirExpertos
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
            this.lbExpertosDisponibles = new System.Windows.Forms.ListBox();
            this.lbExpertosUsar = new System.Windows.Forms.ListBox();
            this.bMoveToUsar = new System.Windows.Forms.Button();
            this.bMoveToDisponibles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bFinalizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbExpertosDisponibles
            // 
            this.lbExpertosDisponibles.FormattingEnabled = true;
            this.lbExpertosDisponibles.Location = new System.Drawing.Point(12, 101);
            this.lbExpertosDisponibles.Name = "lbExpertosDisponibles";
            this.lbExpertosDisponibles.Size = new System.Drawing.Size(150, 199);
            this.lbExpertosDisponibles.TabIndex = 0;
            // 
            // lbExpertosUsar
            // 
            this.lbExpertosUsar.FormattingEnabled = true;
            this.lbExpertosUsar.Location = new System.Drawing.Point(301, 101);
            this.lbExpertosUsar.Name = "lbExpertosUsar";
            this.lbExpertosUsar.Size = new System.Drawing.Size(150, 199);
            this.lbExpertosUsar.TabIndex = 1;
            // 
            // bMoveToUsar
            // 
            this.bMoveToUsar.Location = new System.Drawing.Point(195, 138);
            this.bMoveToUsar.Name = "bMoveToUsar";
            this.bMoveToUsar.Size = new System.Drawing.Size(75, 23);
            this.bMoveToUsar.TabIndex = 2;
            this.bMoveToUsar.Text = ">>";
            this.bMoveToUsar.UseVisualStyleBackColor = true;
            this.bMoveToUsar.Click += new System.EventHandler(this.bMoveToUsar_Click);
            // 
            // bMoveToDisponibles
            // 
            this.bMoveToDisponibles.Location = new System.Drawing.Point(195, 183);
            this.bMoveToDisponibles.Name = "bMoveToDisponibles";
            this.bMoveToDisponibles.Size = new System.Drawing.Size(75, 23);
            this.bMoveToDisponibles.TabIndex = 3;
            this.bMoveToDisponibles.Text = "<<";
            this.bMoveToDisponibles.UseVisualStyleBackColor = true;
            this.bMoveToDisponibles.Click += new System.EventHandler(this.bMoveToDisponibles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Expertos Que Ponderarán";
            // 
            // bFinalizar
            // 
            this.bFinalizar.Location = new System.Drawing.Point(195, 277);
            this.bFinalizar.Name = "bFinalizar";
            this.bFinalizar.Size = new System.Drawing.Size(75, 23);
            this.bFinalizar.TabIndex = 5;
            this.bFinalizar.Text = "Finalizar";
            this.bFinalizar.UseVisualStyleBackColor = true;
            this.bFinalizar.Click += new System.EventHandler(this.bFinalizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(21, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "A Indicadores Generales";
            // 
            // ElegirExpertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 356);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bFinalizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bMoveToDisponibles);
            this.Controls.Add(this.bMoveToUsar);
            this.Controls.Add(this.lbExpertosUsar);
            this.Controls.Add(this.lbExpertosDisponibles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ElegirExpertos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elegir Expertos";
            this.Load += new System.EventHandler(this.ElegirExpertos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbExpertosDisponibles;
        private System.Windows.Forms.ListBox lbExpertosUsar;
        private System.Windows.Forms.Button bMoveToUsar;
        private System.Windows.Forms.Button bMoveToDisponibles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bFinalizar;
        private System.Windows.Forms.Label label2;
    }
}