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
    public partial class Gradosindicadores : Form
    {
        private SqlConnection con = new SqlConnection();
        public Gradosindicadores(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
       }

        private void Grados_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {


                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_GRADO";

                //cmd.Parameters.Add("@ID_IND", SqlDbType.Int).Value = Indicador.SelectedIndex + 1;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Descripcion.Text;
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se Agrego Exitosamente");
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

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
