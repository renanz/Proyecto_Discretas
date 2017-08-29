using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public partial class Indicadores : Form
    {

        public List<Indicadores_Arr> indicadoresEspecificos;
        private float peso = 0;
        int id_gen = 0;
        private int indicador = 0;
        private bool indEspecificos;
        SqlConnection con;
        private List<int> pesos_generales;
        private int contador = 0;
        private bool first = false;
        int informe;
        List<grados_Arr> gradosInsert;
        List<grados_Arr> gradosTable;
        public Indicadores(SqlConnection con, List<grados_Arr> gradosInsert)
        {
            InitializeComponent();
            this.con = con;
            informe = 0;
            id_gen = 0;
            this.gradosInsert = gradosInsert;
            this.gradosTable = new List<grados_Arr>();
            indicadoresEspecificos = new List<Indicadores_Arr>();
            pesos_generales = new List<int>();
            indEspecificos = false;
            listView2.Visible = false;
            listView3.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }
        
        private void agregar_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(Peso.Text))
            //{
            //    MessageBox.Show("No ha agregado un peso");
            //    return;
            //}
            //if (float.Parse(Peso.Text) > peso)
            //{
            //    MessageBox.Show("No puedes agregar un grado con un peso mayor a " + peso.ToString());
            //    return;
            //}
                        
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                insertSpecificIndicadores();
                insertParaGradosTable();
                insertGradosPerSpecificIndicador();
                insertIndicadoresArr();
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
            limpiar();
        }
        //Métodos auxiliares para agregar
        private void insertSpecificIndicadores()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;
            SqlCommand cmd2 = new SqlCommand("", con);
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "SELECT TOP 1 ID from INFORME_INDICADORES ORDER BY ID DESC";
            SqlDataAdapter da = new SqlDataAdapter(cmd2);

            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];

            informe = int.Parse(dt.Rows[0][0].ToString());

            cmd = new SqlCommand("", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_INSERT_INDICADOR";
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = informe;
            if (!indEspecificos)
            {
                cmd.Parameters.Add("@INDICADORES_ID", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@ID_GEN", SqlDbType.Int).Value = DBNull.Value;
                pesos_generales.Add(0); //int.Parse(Peso.Text));
            }
            else
            {
                cmd.Parameters.Add("@INDICADORES_ID", SqlDbType.Int).Value = informe;
                cmd.Parameters.Add("@ID_GEN", SqlDbType.Int).Value = indicadoresEspecificos.ElementAt(indicador).id_gen;
            }
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Nombre.Text;
            cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = 0;//float.Parse(Peso.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            MessageBox.Show("Se agrego correctamente");

        }

        private void insertParaGradosTable()
        {
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con;
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "SELECT TOP 1 ID_IND from INDICADORES ORDER BY ID_IND DESC";
            SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
            DataSet ds2 = new DataSet();
            DataTable dt2 = new DataTable();
            da2.Fill(ds2);
            dt2 = ds2.Tables[0];
            if (cbGradosAsumidos.Checked)
            {
                id_gen = int.Parse(dt2.Rows[0][0].ToString());
                for (int i = 0; i < gradosInsert.Count; i++)
                {
                    gradosInsert.ElementAt(i).ID_IND = id_gen;
                    gradosTable = gradosInsert;
                }
            }
            else
            {
                id_gen = int.Parse(dt2.Rows[0][0].ToString());
                Grados_NoAsumidos gn = new Grados_NoAsumidos(gradosInsert);
                gn.ShowDialog();
                for (int i = 0; i < gradosInsert.Count; i++)
                {
                    for (int j = 0; j < gn.grados.Count; j++)
                    {
                        if (gradosInsert.ElementAt(i).nombre == gn.grados[j].ToString())
                        {
                            gradosInsert.ElementAt(i).ID_IND = id_gen;
                            gradosTable.Add(gradosInsert.ElementAt(i));
                        }
                    }
                }

            }
        }

        private void insertGradosPerSpecificIndicador()
        {
            SqlCommand cmd5 = null;
            for (int i = 0; i < gradosInsert.Count; i++)
            {
                if (gradosInsert.ElementAt(i).ID_IND != 0)
                {
                    cmd5 = new SqlCommand("", con);
                    cmd5.CommandType = CommandType.StoredProcedure;
                    cmd5.CommandText = "SP_INSERT_GRADO";

                    cmd5.Parameters.Add("@ID_IND", SqlDbType.Int).Value = gradosInsert.ElementAt(i).ID_IND;
                    cmd5.Parameters.Add("@ID", SqlDbType.Int).Value = gradosInsert.ElementAt(i).ID;
                    cmd5.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = gradosInsert.ElementAt(i).nombre;
                    cmd5.Parameters.Add("@VALOR", SqlDbType.Int).Value = gradosInsert.ElementAt(i).valor;
                    cmd5.ExecuteNonQuery();
                    cmd5.Dispose();
                }
            }
            for (int i = 0; i < gradosInsert.Count; i++)
            {
                gradosInsert.ElementAt(i).ID_IND = 0;
            }
        }

        private void insertIndicadoresArr()
        {
            Indicadores_Arr ind = new Indicadores_Arr(Nombre.Text, 0, id_gen, gradosTable);
            gradosTable = new List<grados_Arr>();

            if (!indEspecificos)
            {
                indicadoresEspecificos.Add(ind);
                indicadoresEspecificos.Sort();
                listView1.Items.Clear();
                foreach (Indicadores_Arr id in indicadoresEspecificos)
                {
                    ListViewItem item = new ListViewItem(id.descp);
                    item.SubItems.Add(id.peso.ToString());
                    listView1.Items.Add(item);
                }

                //label2.Text = "(Peso disponible " + (peso -= float.Parse(Peso.Text)) + "%)";

                //if (peso == 0)
                //{
                    button1.Enabled = true;
                    agregar.Enabled = true;
                    //indEspecificos = true;
                    //progressBar1.Value = 100;
                    //bar = 0;
                //}
            }
            else
            {
                indicadoresEspecificos.ElementAt(indicador).IndicadoresEspecificos.Add(ind);
                indicadoresEspecificos.ElementAt(indicador).IndicadoresEspecificos.Sort();
                listView1.Items.Clear();
                foreach (Indicadores_Arr id in indicadoresEspecificos.ElementAt(indicador).IndicadoresEspecificos)
                {
                    ListViewItem item = new ListViewItem(id.descp);
                    item.SubItems.Add(id.peso.ToString());
                    listView1.Items.Add(item);
                }

               // label2.Text = "(Peso disponible " + (peso -= float.Parse(Peso.Text)) + "%)";

                //if (peso == 0)
                //{
                    button1.Enabled = true;
                    agregar.Enabled = true;
                    //indicador++;
                    //contador++;
                //}
            }
        }
        //Terminan los métodos para agregar

        private void Indicadores_Load(object sender, EventArgs e)
        {
            cbGradosAsumidos.Checked = true;            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (first != false)
            {
                indicador++;
                contador++;
            }
            first = true;
            if (indicador == indicadoresEspecificos.Count())
            {
                this.Close();
            }
            else
            {
                indEspecificos = true;
                //peso = 0;
                agregar.Enabled = true;
                button1.Enabled = true;
                label3.Text = "Especificos " + indicadoresEspecificos.ElementAt(indicador).descp;
                //label2.Text = "(Peso disponible " + peso + "%)";
                listView1.Items.Clear();
               

            }
            limpiar();
        }

        private void limpiar()
        {
            Nombre.Text = "";
            //Peso.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView3.Items.Add(listView2.SelectedItems[0].ToString());
            listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Items.Add(listView3.SelectedItems[0].ToString());
            listView3.Items.RemoveAt(listView3.SelectedIndices[0]);
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
