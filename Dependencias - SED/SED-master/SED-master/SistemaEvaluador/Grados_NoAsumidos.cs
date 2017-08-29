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
    public partial class Grados_NoAsumidos : Form
    {
        List<grados_Arr> gradosInsert;
        public ListBox.ObjectCollection grados; 
        public Grados_NoAsumidos(List<grados_Arr> gradosInsert )
        {
            InitializeComponent();
            this.gradosInsert = gradosInsert;
            for (int i = 0; i<gradosInsert.Count; i++)
            {
                listView2.Items.Add(gradosInsert.ElementAt(i).nombre);
            }

        }

        private void Grados_NoAsumidos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView3.Items.Add(listView2.SelectedItem);
            listView2.Items.RemoveAt(listView2.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Items.Add(listView3.SelectedItem);
            listView3.Items.RemoveAt(listView3.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView3.Items.Count > 0)
            {
                grados = listView3.Items;
                this.Close();
            }
            else
            {
                MessageBox.Show("Defina grados para Indicador");
            }
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
