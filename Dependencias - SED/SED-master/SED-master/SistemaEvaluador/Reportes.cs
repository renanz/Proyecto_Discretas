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
    public partial class Reportes : Form
    {
        private SqlConnection con;
        public Reportes(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Individual ind = new Individual(con);
            ind.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EvaluacionGrupal gru = new EvaluacionGrupal(con);
            gru.ShowDialog();

        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
