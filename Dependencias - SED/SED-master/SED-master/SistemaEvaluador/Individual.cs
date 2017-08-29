using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEvaluador
{
    public partial class Individual : Form
    {
        private SqlConnection con;
        private bool loading;
        private int id_empleado;
        private List<int> id_Empleados;
        List<int> id_dept;
        public Individual(SqlConnection con)
        {
            InitializeComponent();
            this.con = con;
           
           
            SqlCommand cmd = null;
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();

                id_Empleados = new List<int>();
                cmd = new SqlCommand();
                loading = true;
                cmd.Connection = con;
                id_dept = new List<int>();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM DEPARTAMENTOS";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "NOMBRE";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id_dept.Add(int.Parse(dt.Rows[i][0].ToString()));
                }

                loading = false;
                DataTable dt1 = new DataTable();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "SELECT CONCAT(NOMBRES,' ',APELLIDOS) as NOMBRE, ID_EMPLEADO AS ID FROM EMPLEADOS WHERE ID_DEPTO = "+ id_dept.ElementAt(comboBox1.SelectedIndex);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[1].Visible = false;
                id_Empleados.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    id_Empleados.Add(int.Parse(dt1.Rows[i][1].ToString()));
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

        private void Individual_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           id_empleado=id_Empleados.ElementAt(e.RowIndex );
            GraficoBarras gb  = new GraficoBarras(con,id_empleado);
            gb.ShowDialog();
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loading)
                return;
            try {

                if (con.State != ConnectionState.Open)
                    con.Open();

                DataTable dt1 = new DataTable();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText =
                    "SELECT CONCAT(NOMBRES,' ',APELLIDOS) as NOMBRE, ID_EMPLEADO AS ID FROM EMPLEADOS WHERE ID_DEPTO = " + id_dept.ElementAt(comboBox1.SelectedIndex);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);

                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dt1 = ds1.Tables[0];
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[1].Visible = false;
          
                id_Empleados.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    id_Empleados.Add(int.Parse(dt1.Rows[i][1].ToString()));
                }



                dataGridView1.DataSource = dt1;


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
