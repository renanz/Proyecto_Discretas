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
    public partial class Departamentos : Form
    {
        SqlConnection con;
        //int buttonx = 580;
        //int buttony = 169;
        public bool modificar = false;
        int id_depto;
        public Departamentos(SqlConnection con, bool modificar)
        {
            InitializeComponent();
            this.con = con;
            this.modificar = modificar;
            this.Departamento.Enabled = false;
            id_depto = 0;
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {
            Agregar.Visible = false;
            button1.Visible = false;
            bEliminar.Visible = false;
            //this.Size = new Size(774, 585);
            //dataGridView1.Visible = false;
            if (modificar)
            {
                //button1.Location = new Point(buttonx, buttony);
                button1.Visible = true;
                bEliminar.Visible = true;
                // this.Size = new Size(774, 585);
                this.Refresh();
                dataGridView1.Visible = true;
                //  SqlCommand cmd = null;
                try
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.CommandText = "SELECT ID_DEPTO AS 'CODIGO DEPARTAMENTO', NOMBRE AS 'NOMBRE DEPARTAMENTO' from DEPARTAMENTOS";
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
            else
            {
                //Agregar.Location = new Point(buttonx, buttony);
                Agregar.Visible = true;
                this.Departamento.Enabled = true;
            }

            //bVolver.Location = new Point(buttonx, buttony - 40);
            bVolver.Visible = true;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_DEPARTAMENTO";
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Departamento.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se agregó correctamente");
                this.Close();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Departamento.Enabled = true;
            id_depto = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Departamento.Text = Convert.ToString(id_depto); 
        }

        private void Departamento_Click(object sender, EventArgs e)
        {
            if (Departamento.Enabled == false)
                MessageBox.Show("Seleccione el Departamento a Editar de la Tabla");
        }

        private void Departamento_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Departamento.Enabled == false)
                MessageBox.Show("Seleccione el Departamento a Editar de la Tabla");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Departamento.Enabled == false)
                MessageBox.Show("Seleccione el Departamento a Editar de la Tabla");
            SqlCommand cmd = null;
            try
            {
                if (id_depto > 0)
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_UPDATE_DEPTO";
                    cmd.Parameters.Add("@ID_DEPTO", SqlDbType.Int).Value = id_depto;
                    cmd.Parameters.Add("@NUEVON", SqlDbType.VarChar).Value = Departamento.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Se Modificó Correctamente");
                    this.Close();
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
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (Departamento.Enabled == false)
                MessageBox.Show("Seleccione el departamento a eliminar de la tabla");
            SqlCommand cmd = null;
            try
            {
                if (id_depto > 0)
                {

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_DELETE_DEPARTAMENTO";
                    cmd.Parameters.Add("@ID_DEP", SqlDbType.Int).Value = id_depto;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    MessageBox.Show("Se eliminó correctamente");
                    this.Close();
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
        }
    }
}
