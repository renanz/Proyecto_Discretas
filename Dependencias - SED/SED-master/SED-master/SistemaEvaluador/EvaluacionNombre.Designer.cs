namespace SistemaEvaluador
{
    partial class EvaluacionNombre
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.bVolver = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.c_evaluacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbGrupos = new System.Windows.Forms.GroupBox();
            this.rbDepto = new System.Windows.Forms.RadioButton();
            this.rbEmpleado = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.lEmpleado = new System.Windows.Forms.Label();
            this.lDepartamento = new System.Windows.Forms.Label();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.gbGrupos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre o Periodo de Evaluación";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(455, 107);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(559, 324);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(16, 22);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(300, 51);
            this.label9.TabIndex = 41;
            this.label9.Text = "EVALUACIÓN";
            // 
            // bVolver
            // 
            this.bVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVolver.Location = new System.Drawing.Point(693, 324);
            this.bVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bVolver.Name = "bVolver";
            this.bVolver.Size = new System.Drawing.Size(116, 50);
            this.bVolver.TabIndex = 42;
            this.bVolver.Text = "Volver a menu";
            this.bVolver.UseVisualStyleBackColor = true;
            this.bVolver.Click += new System.EventHandler(this.bVolver_Click);
            // 
            // delete_button
            // 
            this.delete_button.Enabled = false;
            this.delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_button.Location = new System.Drawing.Point(421, 324);
            this.delete_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(120, 50);
            this.delete_button.TabIndex = 43;
            this.delete_button.Text = "Borrar";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // c_evaluacion
            // 
            this.c_evaluacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_evaluacion.Enabled = false;
            this.c_evaluacion.FormattingEnabled = true;
            this.c_evaluacion.Location = new System.Drawing.Point(455, 155);
            this.c_evaluacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.c_evaluacion.Name = "c_evaluacion";
            this.c_evaluacion.Size = new System.Drawing.Size(281, 24);
            this.c_evaluacion.TabIndex = 44;
            this.c_evaluacion.SelectedIndexChanged += new System.EventHandler(this.c_evaluacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Evaluaciones Existentes:";
            // 
            // gbGrupos
            // 
            this.gbGrupos.Controls.Add(this.rbTodos);
            this.gbGrupos.Controls.Add(this.rbEmpleado);
            this.gbGrupos.Controls.Add(this.rbDepto);
            this.gbGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGrupos.Location = new System.Drawing.Point(124, 199);
            this.gbGrupos.Name = "gbGrupos";
            this.gbGrupos.Size = new System.Drawing.Size(192, 124);
            this.gbGrupos.TabIndex = 46;
            this.gbGrupos.TabStop = false;
            this.gbGrupos.Text = "Evaluación para:";
            // 
            // rbDepto
            // 
            this.rbDepto.AutoSize = true;
            this.rbDepto.Location = new System.Drawing.Point(6, 33);
            this.rbDepto.Name = "rbDepto";
            this.rbDepto.Size = new System.Drawing.Size(145, 24);
            this.rbDepto.TabIndex = 0;
            this.rbDepto.Text = "Departamento";
            this.rbDepto.UseVisualStyleBackColor = true;
            this.rbDepto.CheckedChanged += new System.EventHandler(this.rbDepto_CheckedChanged);
            // 
            // rbEmpleado
            // 
            this.rbEmpleado.AutoSize = true;
            this.rbEmpleado.Location = new System.Drawing.Point(6, 63);
            this.rbEmpleado.Name = "rbEmpleado";
            this.rbEmpleado.Size = new System.Drawing.Size(110, 24);
            this.rbEmpleado.TabIndex = 1;
            this.rbEmpleado.TabStop = true;
            this.rbEmpleado.Text = "Empleado";
            this.rbEmpleado.UseVisualStyleBackColor = true;
            this.rbEmpleado.CheckedChanged += new System.EventHandler(this.rbEmpleado_CheckedChanged);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(6, 93);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(79, 24);
            this.rbTodos.TabIndex = 2;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpleado.FormattingEnabled = true;
            this.cbEmpleado.Location = new System.Drawing.Point(455, 228);
            this.cbEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(288, 28);
            this.cbEmpleado.TabIndex = 47;
            // 
            // lEmpleado
            // 
            this.lEmpleado.AutoSize = true;
            this.lEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEmpleado.Location = new System.Drawing.Point(451, 199);
            this.lEmpleado.Name = "lEmpleado";
            this.lEmpleado.Size = new System.Drawing.Size(97, 20);
            this.lEmpleado.TabIndex = 48;
            this.lEmpleado.Text = "Empleado:";
            // 
            // lDepartamento
            // 
            this.lDepartamento.AutoSize = true;
            this.lDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDepartamento.Location = new System.Drawing.Point(451, 259);
            this.lDepartamento.Name = "lDepartamento";
            this.lDepartamento.Size = new System.Drawing.Size(133, 20);
            this.lDepartamento.TabIndex = 50;
            this.lDepartamento.Text = "Departamento:";
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(455, 288);
            this.cbDepartamento.Margin = new System.Windows.Forms.Padding(4);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(288, 28);
            this.cbDepartamento.TabIndex = 49;
            // 
            // EvaluacionNombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(840, 388);
            this.Controls.Add(this.lDepartamento);
            this.Controls.Add(this.cbDepartamento);
            this.Controls.Add(this.lEmpleado);
            this.Controls.Add(this.cbEmpleado);
            this.Controls.Add(this.gbGrupos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_evaluacion);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.bVolver);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EvaluacionNombre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvaluacionNombre";
            this.Load += new System.EventHandler(this.EvaluacionNombre_Load);
            this.gbGrupos.ResumeLayout(false);
            this.gbGrupos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bVolver;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.ComboBox c_evaluacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbGrupos;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbEmpleado;
        private System.Windows.Forms.RadioButton rbDepto;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.Label lEmpleado;
        private System.Windows.Forms.Label lDepartamento;
        private System.Windows.Forms.ComboBox cbDepartamento;
    }
}