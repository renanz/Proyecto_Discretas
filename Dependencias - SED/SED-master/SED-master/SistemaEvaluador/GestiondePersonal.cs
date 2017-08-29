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
    public partial class GestiondePersonal : Form
    {
        SqlConnection con;
        bool modificar;
        private List<DependientesEmpleados> hijos;
        private List<int> idsJefes;
        private Empleado emp;
        
        public GestiondePersonal(SqlConnection con, bool modificar, Empleado emp)
        {
            InitializeComponent();
            this.con = con;
            this.idsJefes = new List<int>();
            this.modificar = modificar;
            this.hijos = new List<DependientesEmpleados>();
            if (modificar)                            
                Agregar.Visible = false;            
            else            
                Modificar.Visible = false;

            this.emp = emp;                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dependientes depen = new Dependientes();
            this.Hide();
            var result = depen.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.Show();
                hijos = depen.hijos;
            }
        }

        private void modifyValues()
        {
            if (modificar)
            {
                this.Nombre.Text = emp.nombres;
                this.Apellido.Text = emp.apellidos;
                this.pasaporte.Text = emp.identidad;
                this.Direcion.Text = emp.direccion;
                this.estadoCivil.SelectedText = emp.estadoCivil.ToString().Equals("S") ? "Soltero(a)" : "Casado(a)";
                this.NivelEducacion.Text = emp.nivelEducacional;
                this.Puesto.Text = emp.puesto;
                this.Telefono.Text = emp.telefono.ToString();
                if (emp.antecedentes == 'N')
                    this.no.Checked = true;
                else
                    this.si.Checked = true;
                this.dateTimePicker1.Value = emp.fechaIngreso;
                if (emp.genero == 'M')
                    this.Masculino.Checked = true;
                else
                    this.Femenino.Checked = true;
                Console.WriteLine(emp.idDepto);
                Console.Write(emp.idJefe);
                this.DepartamentoTrabajo.SelectedValue = emp.idDepto;
                this.Jefe.SelectedValue = emp.idJefe > 0 ? emp.idJefe : Jefe.SelectedIndex;
            }
        }

        private void GestiondePersonal_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = null;                     

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM DEPARTAMENTOS";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                DepartamentoTrabajo.DataSource = dt;
                DepartamentoTrabajo.DisplayMember = "NOMBRE";
                DepartamentoTrabajo.ValueMember = "ID_DEPTO";

                //Llenar datos por si hay que modificar
                modifyValues();
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

        private void clear()
        {
            Nombre.Text = "";
            Apellido.Text = "";
            Direcion.Text = "";
            Telefono.Text = "";
            pasaporte.Text = "";
            Puesto.Text = "";
            Femenino.Checked = false;
            Masculino.Checked = false;
            si.Checked = false;
            no.Checked = false;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                SqlCommand cmd3;
                int idJefe;
                if (idsJefes.Count == 0)
                    idJefe = 0;
                else
                {
                    cmd3 = new SqlCommand("", con);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "SELECT ID_EMPLEADO FROM EMPLEADOS WHERE ID_DEPTO="
                        + idsJefes[(DepartamentoTrabajo.SelectedIndex)] + " AND CONCAT(NOMBRES,' ',APELLIDOS)="
                        + "'" + Jefe.GetItemText(Jefe.SelectedItem) + "'";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                    DataTable dt1 = new DataTable();
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    dt1 = ds1.Tables[0];
                    if (dt1.Rows.Count == 0)
                        idJefe = 0;
                    else
                        idJefe = int.Parse(dt1.Rows[0][0].ToString());
                }

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERT_EMPLEADOS";
                if (idJefe == 0)
                    cmd.Parameters.Add("@ID_JEFE", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@ID_JEFE", SqlDbType.Int).Value = idJefe;
                cmd.Parameters.Add("@ID_DEPTO", SqlDbType.Int).Value = DepartamentoTrabajo.SelectedIndex + 1;
                cmd.Parameters.Add("@NOMBRES", SqlDbType.VarChar).Value = Nombre.Text;
                cmd.Parameters.Add("@APELLIDOS", SqlDbType.VarChar).Value = Apellido.Text;
                cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = Direcion.Text;
                cmd.Parameters.Add("@ESTADO_CIVIL", SqlDbType.Char).Value = estadoCivil.SelectedText.Equals("Soltero(a)") ? 'S' : 'C';
                if (NivelEducacion.SelectedIndex > -1)
                    cmd.Parameters.Add("@NIVEL_EDUCACIONAL", SqlDbType.VarChar).Value = NivelEducacion.GetItemText(NivelEducacion.SelectedItem);
                else
                    cmd.Parameters.Add("@NIVEL_EDUCACIONAL", SqlDbType.VarChar).Value = NivelEducacion.Text;

                cmd.Parameters.Add("@PUESTO", SqlDbType.VarChar).Value = Puesto.Text;
                if (si.Checked == true)
                {
                    cmd.Parameters.Add("@ANTECEDENTES", SqlDbType.VarChar).Value = 'S';
                }
                else if (no.Checked == true)
                {
                    cmd.Parameters.Add("@ANTECEDENTES", SqlDbType.VarChar).Value = 'N';
                }

                cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = int.Parse(Telefono.Text);
                cmd.Parameters.Add("@FECHA_INGRESO", SqlDbType.DateTime).Value = dateTimePicker1.Value.ToShortDateString();
                if (Masculino.Checked == true)
                {
                    cmd.Parameters.Add("@GENERO", SqlDbType.VarChar).Value = 'M';
                }
                else if (Femenino.Checked == true)
                {
                    cmd.Parameters.Add("@GENERO", SqlDbType.VarChar).Value = 'F';
                }
                cmd.Parameters.Add("@N_IDENTIDAD", SqlDbType.VarChar).Value = pasaporte.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (hijos != null)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.CommandText = "select top 1 ID_EMPLEADO  from EMPLEADOS order by ID_EMPLEADO desc ";
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dt = ds.Tables[0];
                                        
                    for (int x = 0; x < hijos.Count(); x++)
                    {
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4.Connection = con;
                        cmd4.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd4.CommandText = "SP_INSERT_DEPENDIENTE";
                        cmd4.Parameters.Add("@ID_EMPLEADO", SqlDbType.Int).Value = int.Parse(dt.Rows[0][0].ToString());
                        cmd4.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = hijos.ElementAt(x).Nombre_Dependiente;
                        cmd4.Parameters.Add("@PARENTESCO", SqlDbType.VarChar).Value = hijos.ElementAt(x).Parentesco;
                        cmd4.ExecuteNonQuery();
                        cmd4.Dispose();
                    }

                }
                MessageBox.Show("Se agregó correctamente");
                this.clear();
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
        
        private void DepartamentoTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Jefe.Items.Count != 0)
            {
                Jefe.DataSource = null;
                Jefe.Items.Clear();
            }

            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT CONCAT(NOMBRES,' ',APELLIDOS) AS NOMBRECOMPLETO, ID_EMPLEADO FROM EMPLEADOS WHERE ID_DEPTO=" 
                    + (DepartamentoTrabajo.SelectedIndex + 1);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dt2 = ds2.Tables[0];
                Jefe.DataSource = dt2;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    idsJefes.Add(int.Parse(dt2.Rows[i][1].ToString()));
                }
                Jefe.DisplayMember = "NOMBRECOMPLETO";
                Jefe.ValueMember = "ID_EMPLEADO";
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

        private void Modificar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmd = new SqlCommand("", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_UPDATE_EMPLEADO";
                cmd.Parameters.Add("@ID_EMP", SqlDbType.Int).Value = emp.idEmpleado;
                cmd.Parameters.Add("@ID_JEFE", SqlDbType.Int).Value = Jefe.SelectedValue;

                if (NivelEducacion.SelectedIndex > -1)
                    cmd.Parameters.Add("@NIVEL_EDUCACIONAL", SqlDbType.VarChar).Value = NivelEducacion.GetItemText(NivelEducacion.SelectedItem);
                else
                    cmd.Parameters.Add("@NIVEL_EDUCACIONAL", SqlDbType.VarChar).Value = NivelEducacion.Text;

                if (si.Checked == true)
                {
                    cmd.Parameters.Add("@ANTECEDENTES", SqlDbType.VarChar).Value = 'S';
                }
                else if (no.Checked == true)
                {
                    cmd.Parameters.Add("@ANTECEDENTES", SqlDbType.VarChar).Value = 'N';
                }
                
                cmd.Parameters.Add("@ID_DEPTO", SqlDbType.Int).Value = DepartamentoTrabajo.SelectedValue;
                cmd.Parameters.Add("@NOMBRES", SqlDbType.VarChar).Value = Nombre.Text;
                cmd.Parameters.Add("@APELLIDOS", SqlDbType.VarChar).Value = Apellido.Text;
                cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = Direcion.Text;
                cmd.Parameters.Add("@ESTADO_CIVIL", SqlDbType.Char).Value = estadoCivil.SelectedText.Equals("Soltero(a)") ? 'S' : 'C';
                cmd.Parameters.Add("@PUESTO", SqlDbType.VarChar).Value = Puesto.Text;
                cmd.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = int.Parse(Telefono.Text);
                cmd.Parameters.Add("@NUM_ID", SqlDbType.VarChar).Value = pasaporte.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Se actualizó correctamente.");
                //loadDataGrid();
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
