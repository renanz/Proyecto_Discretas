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
    public partial class EvaluacionGrupal : Form
    {
        SqlConnection con;
        public EvaluacionGrupal(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void EvaluacionGrupal_Load(object sender, EventArgs e)
        {
         
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                DataTable dt1 = new DataTable();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "SELECT * FROM DEPARTAMENTOS";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[0].Visible = false;
               
            }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_depto = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            GraficaDepto gb = new GraficaDepto(con, id_depto);
            this.Hide();
            gb.ShowDialog();
            this.Show();
            this.Close();
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
