using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class GradosInicio : Form
    {
        public List<String> grados;
        int index;
            public GradosInicio()
        {
            InitializeComponent();
            grados = new List<String>();
        }

        private void GradosInicio_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Nombre.Text == "")
                return;
            grados.Add(Nombre.Text);
            ListViewItem item = new ListViewItem(Nombre.Text);
            listView1.Items.Add(item);
            Nombre.Text = "";

            
            /*
            Indicadores_Arr grado = new Indicadores_Arr(Nombre.Text, float.Parse(Peso.Text));
            grados.Add(grado);
            grados.Sort();
            listView1.Items.Clear();
            foreach(Indicadores_Arr grad in grados)
            {
                ListViewItem item = new ListViewItem(grad.descp);
                item.SubItems.Add(grad.peso.ToString());
                listView1.Items.Add(item);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          if(index==0)
             return;

          listView1.Items.RemoveAt(index);
          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            index = int.Parse(listView1.SelectedIndices.ToString());
            
        }

        private void GradosInicio_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
