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
    public partial class EditarGrados : Form
    {
        SqlConnection con;
        int id_eva;
        private string gradoMod;
        public EditarGrados(SqlConnection con, int id_eva)
        {
            InitializeComponent();
            this.con = con;
            this.id_eva = id_eva;
        }

        private void EditarGrados_Load(object sender, EventArgs e)
        {
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "select NOMBRE from GRADOS where ID=" 
                    + id_eva + " group by NOMBRE;";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
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

        private void load()
        {
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "select NOMBRE from GRADOS where ID=" + id_eva + " group by NOMBRE;";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE GRADOS SET NOMBRE= '" + Grados.Text + "' WHERE ID_GRADO = '" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "'";

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
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
            //this.Close();
            load();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Grados.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //Grados.Text = "Nada";
            
            gradoMod = Grados.Text;

            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "select ID_GRADO, ID_IND, ID, NOMBRE, VALOR from GRADOS where ID=" + id_eva + " and NOMBRE='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' group by ID_GRADO, ID_IND, ID, NOMBRE, VALOR ORDER BY ID_GRADO;";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView2.DataSource = dt;
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

        private void Grados_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Grados.Text))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Grados.Text == "")
            {
                MessageBox.Show("No ha seleccionado un grado.");
                return;
            }
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM GRADOS WHERE NOMBRE='"
                                  + dataGridView2["NOMBRE", dataGridView1.CurrentRow.Index].Value.ToString()
                                  + "' AND ID ='"
                                  + dataGridView2["ID", dataGridView1.CurrentRow.Index].Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                load();
                
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
