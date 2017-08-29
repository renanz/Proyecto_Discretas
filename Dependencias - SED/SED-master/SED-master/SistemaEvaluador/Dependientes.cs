using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Dependientes : Form
    {
        public List<DependientesEmpleados> hijos;
        
        public Dependientes()
        {
            InitializeComponent();
            hijos = new List<DependientesEmpleados>();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            if (nombredependiente.Text.Equals("") || textBox1.Text.Equals(""))
            {
                MessageBox.Show("No puedes agregar con campos vacios");
                return;
            }
            DependientesEmpleados depen = new DependientesEmpleados(nombredependiente.Text, textBox1.Text);
            hijos.Add(depen);
            MessageBox.Show("Agregado exitosamente");
            textBox1.Text = "";
            nombredependiente.Text = "";
        }        

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
