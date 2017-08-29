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
    public partial class EmpleadosComboBox : Form
    {
        private int id_evaluacion;
        private string id_emp;
        SqlConnection con;
        public EmpleadosComboBox(SqlConnection con, int id_eva)
        {
            this.con = con;
            id_evaluacion = id_eva;
            InitializeComponent();
        }

        private void EmpleadosComboBox_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                //Llenar cb con Empleados
                DataTable dtEmpleados = new DataTable();
                SqlCommand cmdEmpleados = new SqlCommand();
                cmdEmpleados.Connection = con;
                cmdEmpleados.CommandType = CommandType.Text;
                cmdEmpleados.CommandText = "SELECT ID_EMPLEADO, (NOMBRES + ' ' + APELLIDOS) AS Nombre FROM EMPLEADOS";
                SqlDataAdapter daEmpleados = new SqlDataAdapter(cmdEmpleados);
                DataSet dsEmpleados = new DataSet();
                daEmpleados.Fill(dsEmpleados);
                dtEmpleados = dsEmpleados.Tables[0];
                comboBox1.DataSource = dtEmpleados;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "ID_EMPLEADO";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id_emp = (comboBox1.SelectedValue.ToString());
            Console.WriteLine("empleado "+id_emp+"\nEvaluacion "+id_evaluacion);
            Evaluador i = new Evaluador(con, id_emp, id_evaluacion);
            i.MdiParent = this.MdiParent;
            i.Show();
            this.Close();
        }
    }
}
