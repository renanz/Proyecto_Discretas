namespace SistemaEvaluador
{
    partial class Ponderador
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
            this.label1 = new System.Windows.Forms.Label();
            this.CBName = new System.Windows.Forms.ComboBox();
            this.Ponderar_Button = new System.Windows.Forms.Button();
            this.Volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escoja una evaluacion";
            // 
            // CBName
            // 
            this.CBName.FormattingEnabled = true;
            this.CBName.Location = new System.Drawing.Point(39, 75);
            this.CBName.Name = "CBName";
            this.CBName.Size = new System.Drawing.Size(179, 21);
            this.CBName.TabIndex = 1;
            // 
            // Ponderar_Button
            // 
            this.Ponderar_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ponderar_Button.Location = new System.Drawing.Point(62, 120);
            this.Ponderar_Button.Name = "Ponderar_Button";
            this.Ponderar_Button.Size = new System.Drawing.Size(75, 37);
            this.Ponderar_Button.TabIndex = 2;
            this.Ponderar_Button.Text = "Ponderar";
            this.Ponderar_Button.UseVisualStyleBackColor = true;
            this.Ponderar_Button.Click += new System.EventHandler(this.Ponderar_Button_Click);
            // 
            // Volver
            // 
            this.Volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Volver.Location = new System.Drawing.Point(143, 120);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(75, 36);
            this.Volver.TabIndex = 3;
            this.Volver.Text = "Volver al menu";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // Ponderador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(252, 169);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.Ponderar_Button);
            this.Controls.Add(this.CBName);
            this.Controls.Add(this.label1);
            this.Name = "Ponderador";
            this.Text = "Ponderador";
            this.Load += new System.EventHandler(this.Ponderador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBName;
        private System.Windows.Forms.Button Ponderar_Button;
        private System.Windows.Forms.Button Volver;
    }
}