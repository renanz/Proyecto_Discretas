using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaEvaluador
{
    public partial class ListaEmpleados : Form
    {
        private SqlConnection conexion;
        private bool modify;
        public Empleado emp;

        public ListaEmpleados(SqlConnection con, bool modificar)
        {
            InitializeComponent();
            this.conexion = con;
            tEmpleado.ReadOnly = true;
            this.modify = modificar;
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void loadDataGrid()
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
                SqlCommand cmdEmps = new SqlCommand("", conexion);
                cmdEmps.CommandType = CommandType.Text;
                cmdEmps.CommandText = "SELECT * from v_EmpleadosTodos";
                SqlDataAdapter da = new SqlDataAdapter(cmdEmps);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvEmpleados.DataSource = dt;
            }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            if (modify)
            {
                this.bEliminar.Visible = false;
                this.tRazon.Visible = false;
                this.label2.Visible = false;
            }
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string empId = dgvEmpleados.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (!modify)
                tEmpleado.Text = empId;
            else
            {
                emp = getEmpleadoInfo(empId);
                Console.WriteLine(emp.ToString());
                this.DialogResult = DialogResult.OK;//para saber si ya salimos de acá
                this.Hide();
            }
        }

        /**
            Este método obtiene la información del empleado y retorna un objeto de Empleado para que
            este pueda ser utilizado fácilmente en el GestionDePersonal form
        **/
        private Empleado getEmpleadoInfo(string empId)
        {
            SqlCommand cmdGetEmp = null;
            Empleado emp = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                cmdGetEmp = new SqlCommand("", conexion);
                cmdGetEmp.CommandType = CommandType.Text;
                cmdGetEmp.CommandText = "SELECT * FROM EMPLEADOS WHERE ID_EMPLEADO='" + empId + "'";
                SqlDataAdapter daEmp = new SqlDataAdapter(cmdGetEmp);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                daEmp.Fill(ds);

                dt = ds.Tables[0];
                emp = new Empleado();
                Object[] empleado = dt.Rows[0].ItemArray;                

                emp.idEmpleado = int.Parse(empleado[0].ToString());
                //a veces no tiene jefe, así que es null, por lo que decide si dar un cero o no
                emp.idJefe = String.IsNullOrEmpty((empleado[1].ToString())) ? 0 : int.Parse(empleado[1].ToString());
                emp.isJefe = emp.idJefe > 0 ? true : false;
                emp.idDepto = int.Parse(empleado[2].ToString()); 
                emp.nombres = empleado[3].ToString();
                emp.apellidos = (empleado[4].ToString());
                emp.direccion = (empleado[5].ToString());
                emp.estadoCivil = empleado[6].ToString()[0];
                emp.nivelEducacional = (empleado[7].ToString());
                emp.puesto = (empleado[8].ToString());
                emp.antecedentes = (empleado[9].ToString()[0]);
                emp.telefono = int.Parse(empleado[10].ToString());
                emp.fechaIngreso = Convert.ToDateTime(empleado[11]);
                emp.genero = (empleado[12].ToString()[0]);
                emp.identidad = (empleado[13].ToString());
                emp.activo = Convert.ToBoolean(empleado[14].ToString());
                emp.razonDespido = (empleado[15].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
            }
            
            return emp;
        }

        private void limpiar()
        {
            tEmpleado.Clear();
            tRazon.Clear();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (tEmpleado.TextLength == 0 || String.IsNullOrEmpty(tEmpleado.Text))
            {
                MessageBox.Show("Seleccione el empleado a eliminar de la tabla e indiqué el porqué está siendo desactivado.");
                return;
            }
            DialogResult dgDelete = MessageBox.Show(this, "¿Desea desactivar este empleado?", "Desactivar empleado", MessageBoxButtons.YesNo);

            if (dgDelete == DialogResult.No)
            {
                limpiar();
                return;
            }

            int idEmp = int.Parse(tEmpleado.Text);
            eliminar(idEmp);
        }
        
        private void eliminar(int idEmp)
        {
            SqlCommand cmd = null;
            try
            {
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();
                cmd = new SqlCommand("", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DELETE_EMPLEADO";
                cmd.Parameters.Add("@ID_EMP", SqlDbType.Int).Value = idEmp;
                cmd.Parameters.Add("@RAZON", SqlDbType.VarChar).Value = tRazon.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se eliminó correctamente.");
                loadDataGrid();
            }
            catch (Exception ene)
            {
                MessageBox.Show(ene.ToString());
            }
            finally
            {
                if (conexion.State != ConnectionState.Closed)
                    conexion.Close();
                limpiar();
            }
        }
    }
}
