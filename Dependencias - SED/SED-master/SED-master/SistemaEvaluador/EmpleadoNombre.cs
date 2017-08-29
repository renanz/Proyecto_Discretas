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
    public partial class EmpleadoNombre : Form
    {
        public string id;
        SqlConnection con;
        public int id_eval;
        public bool exiting;
        public EmpleadoNombre(SqlConnection con)
        {
            this.con = con;
            this.exiting = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = (cbEmpleadoID.SelectedValue.ToString());
            id_eval = int.Parse(comboBox1.SelectedValue.ToString());
            this.Close();
        }

        private void loadCmbEmpleados(string query)
        {
            //Llenar cb con Empleados
            if (String.IsNullOrEmpty(query))
                query = "SELECT ID_EMPLEADO, (NOMBRES + ' ' + APELLIDOS) AS Nombre FROM EMPLEADOS";
            DataTable dtEmpleados = new DataTable();
            SqlCommand cmdEmpleados = new SqlCommand();
            cmdEmpleados.Connection = con;
            cmdEmpleados.CommandType = CommandType.Text;
            cmdEmpleados.CommandText = query;
            SqlDataAdapter daEmpleados = new SqlDataAdapter(cmdEmpleados);
            DataSet dsEmpleados = new DataSet();
            daEmpleados.Fill(dsEmpleados);
            dtEmpleados = dsEmpleados.Tables[0];
            cbEmpleadoID.DataSource = dtEmpleados;
            cbEmpleadoID.DisplayMember = "Nombre";
            cbEmpleadoID.ValueMember = "ID_EMPLEADO";
        }

        private void loadCbEvaluaciones()
        {
            DataTable dt3 = new DataTable();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "SELECT * from INFORME_INDICADORES";
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dt3 = ds3.Tables[0];

            comboBox1.DataSource = dt3;
            comboBox1.DisplayMember = "NOMBRE";
            comboBox1.ValueMember = "ID";
        }

        private void EmpleadoNombre_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                loadCbEvaluaciones();
                loadCmbEmpleados("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.exiting = true;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //0 es para todos, 1 es para empleados y 2 es para deptos
            DataTable dt = (DataTable)comboBox1.DataSource;
            int index_elegido = comboBox1.SelectedIndex;
            int valor_eval = int.Parse(dt.Rows[index_elegido]["evalParaEmp"].ToString());
            
            string query = "";
            switch (valor_eval)
            {
                case 0:
                    query = "SELECT ID_EMPLEADO, (NOMBRES + ' ' + APELLIDOS) AS Nombre FROM EMPLEADOS";
                    break;
                case 1:
                    int valor_empleado = int.Parse(dt.Rows[index_elegido]["ID_Empleado"].ToString());
                    query = "SELECT ID_EMPLEADO, (NOMBRES + ' ' + APELLIDOS) AS Nombre FROM EMPLEADOS WHERE ID_EMPLEADO =" + valor_empleado;
                    break;
                case 2:
                    int valor_depto = int.Parse(dt.Rows[index_elegido]["ID_DEPTO"].ToString());
                    query = "SELECT ID_EMPLEADO, (NOMBRES + ' ' + APELLIDOS) AS Nombre FROM EMPLEADOS WHERE ID_DEPTO =" + valor_depto;
                    break;
            }

            loadCmbEmpleados(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = (cbEmpleadoID.SelectedValue.ToString());
            id_eval = int.Parse(comboBox1.SelectedValue.ToString());
            Editar_Indicadores ei = new Editar_Indicadores(con, id_eval);
            ei.Show();
        }

        private void cbEmpleadoID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
