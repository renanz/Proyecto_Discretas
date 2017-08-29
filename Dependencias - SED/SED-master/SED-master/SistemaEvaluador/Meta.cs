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
    public partial class Meta : Form
    {
        SqlConnection con;
       public double valor;
        public Meta(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
          
        }

        private void Meta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.valor = double.Parse(textBox1.Text);
                this.Close();
            }
            else if (checkBoxX1.Checked)
            {
                this.Close();
            }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
                textBox1.Enabled = false;
            else
                textBox1.Enabled = true;
        }
    }
}
