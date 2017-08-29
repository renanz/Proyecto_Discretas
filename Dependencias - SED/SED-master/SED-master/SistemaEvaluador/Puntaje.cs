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
    public partial class Puntaje : Form
    {
        public int index;
        public Puntaje()
        {
            InitializeComponent();
     
        }

        private void Puntaje_Load(object sender, EventArgs e)
        {
            
            //cargar el combobox de la bd y hacer una consulta, con eso llenar el richtexbox 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //volver al grid y en el marcar con algo en la celda del indicador correspondiente

            //index, seria el index en el combobox
            index = 2;

            this.Close();
        }
    }
}
