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
    public partial class EvaluarDepartamento : Form
    {

        public string id;
        SqlConnection con;
        public int id_eval;
        public bool exiting;

        public EvaluarDepartamento(SqlConnection con)
        {
            this.con = con;
            this.exiting = false;
            InitializeComponent();
        }

        private string getIDDepartamento()
        {
            string query = "SELECT * FROM DEPARTAMENTOS";
            string departamento = cbDepartamentoID.Text.ToUpper();

            SqlCommand cmd = new SqlCommand(query, con);

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string depto = dataReader["NOMBRE"].ToString().ToUpper();

                if (depto.Equals(departamento))
                {
                    string depto_id = dataReader["ID_DEPTO"].ToString();
                    dataReader.Close();
                    return depto_id;
                }

            }

            dataReader.Close();

            return null;
        }

        private string getIDEvaluacion()
        {

            string query = "SELECT * FROM INFORME_INDICADORES";
            string evaluacion = comboBox1.Text.ToUpper();

            SqlCommand cmd = new SqlCommand(query, con);

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                string eval = dataReader["NOMBRE"].ToString().ToUpper();

                if (eval.Equals(evaluacion))
                {
                    string eval_id = dataReader["ID"].ToString();
                    dataReader.Close();
                    return eval_id;
                }

            }

            dataReader.Close();

            return null;
        }

        public double getAverage()
        {



            var list = new List<string>();

            string id_depto = getIDDepartamento();
            string query = "SELECT * FROM EMPLEADOS";
            int cont = 0;

            if (con.State == ConnectionState.Closed)
                con.Open();

            using (var cmd = new SqlCommand(query, con))
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        cont++;
                        string depto = dataReader["ID_DEPTO"].ToString().ToUpper();

                        Console.WriteLine("Depto " + depto);
                        Console.WriteLine("------------------");
                        Console.WriteLine("Depto ID" + id_depto);
                        Console.WriteLine("------------------");
                        Console.WriteLine("Cont" + cont);
                        Console.WriteLine("------------------");


                        if (depto.Equals(id_depto))
                        {

                            string id = dataReader["ID_EMPLEADO"].ToString();

                            list.Add(id);
                            Console.WriteLine("id" + id);
                        }
                     
                    }
                }


            }

            return getAverage(list);
        }

        private double getAverage(List<string> list)
        {
            if (list.Count == 0)
                return -1;

            double average = 0;
            int cont = 0;


            string id_eval = getIDEvaluacion();
            string query = "SELECT * FROM EVALUACION";

            using (var cmd = new SqlCommand(query, con))
            {
                using (var dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string eval = dataReader["ID"].ToString().ToUpper();
                        string empleado = dataReader["ID_EMPLEADO"].ToString().ToUpper();

                        if (eval.Equals(id_eval) && list.Contains(empleado))
                        {
                            string res = dataReader["resultado"].ToString().ToUpper();
                            double cant = Convert.ToDouble(res);
                            cont++;
                            average += cant;
                        }
                    }
                }
            }

            if (average <= 0)
                return -1;
            else
                return average / cont;
        }

        // Departamento
        private void loadCbDepartamento(string query)
        {
            if (String.IsNullOrEmpty(query))
                query = "SELECT ID_DEPTO, (NOMBRE) AS Nombre FROM DEPARTAMENTOS";
            DataTable dtDepartamento = new DataTable();
            SqlCommand cmdDepartamento = new SqlCommand();
            cmdDepartamento.Connection = con;
            cmdDepartamento.CommandType = CommandType.Text;
            cmdDepartamento.CommandText = query;
            SqlDataAdapter daDepartamento = new SqlDataAdapter(cmdDepartamento);
            DataSet dsEmpleados = new DataSet();
            daDepartamento.Fill(dsEmpleados);
            dtDepartamento = dsEmpleados.Tables[0];
            cbDepartamentoID.DataSource = dtDepartamento;
            cbDepartamentoID.DisplayMember = "Nombre";
            cbDepartamentoID.ValueMember = "ID_DEPTO";
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

        private void EvaluarDepartamento_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                loadCbEvaluaciones();
                loadCbDepartamento("");
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

            double average = getAverage();

            if (average == -1)
                textBox1.Text = "Cantidad Invalida";
            else
            {
                string t = "" + average;
                textBox1.Text = t;
            }

        }

        private void cbDepartamentoID_SelectedIndexChanged(object sender, EventArgs e)
        {
            double average = getAverage();

            if (average == -1)
                textBox1.Text = "Cantidad Invalida";
            else
            {
                string t = "" + average;
                textBox1.Text = t;
            }
        }


        // Volver
        private void bVolver_Click(object sender, EventArgs e)
        {
            this.exiting = true;
            this.Close();
        }

        // Proceder a Evaluar
        private void button1_Click(object sender, EventArgs e)
        {
            id = (cbDepartamentoID.SelectedValue.ToString());
            id_eval = int.Parse(comboBox1.SelectedValue.ToString());
            this.Close();
        }

        // Visualizar Evaluacion
        private void button2_Click(object sender, EventArgs e)
        {
            id = (cbDepartamentoID.SelectedValue.ToString());
            id_eval = int.Parse(comboBox1.SelectedValue.ToString());
            Editar_Indicadores ei = new Editar_Indicadores(con, id_eval);
            ei.Show();
        }

    }
}
