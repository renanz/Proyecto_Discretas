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
    public partial class Editar_Indicadores : Form
    {
        SqlConnection con;
        int id;
        List<Indicadores_Arr> indicadores;
        public Editar_Indicadores(SqlConnection con, int id)
        {
            InitializeComponent();
            this.con = con;
            this.id = id;
            indicadores = new List<Indicadores_Arr>();
        }

        private void Editar_Indicadores_Load(object sender, EventArgs e)
        {
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT I.NOMBRE,I.PESO, IE.NOMBRE, IE.PESO,I.ID_IND,IE.ID_IND from INDICADORES I INNER JOIN INDICADORES IE ON I.ID_IND = IE.ID_GEN WHERE I.ID =" + this.id;
                SqlDataAdapter da = new SqlDataAdapter(cmd2);

                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                string n_gen = "";
                dataGridView1.Columns.Add("NOMBRE", "NOMBRE");
                dataGridView1.Columns.Add("PESO", "PESO");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString() != n_gen)
                    {
                        n_gen = dt.Rows[i][0].ToString();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["NOMBRE"].Value = n_gen;
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PESO"].Value = dt.Rows[i][1].ToString();
                        indicadores.Add(new Indicadores_Arr(n_gen, float.Parse(dt.Rows[i][1].ToString()), int.Parse(dt.Rows[i][4].ToString()), null));
                    }
                    if (dt.Rows[i][0].ToString() == n_gen)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["NOMBRE"].Value = " ---" + dt.Rows[i][2].ToString();
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PESO"].Value = dt.Rows[i][3].ToString();
                        indicadores.ElementAt(indicadores.Count - 1).IndicadoresEspecificos.Add(new Indicadores_Arr(dt.Rows[i][2].ToString(), float.Parse(dt.Rows[i][3].ToString()), int.Parse(dt.Rows[i][5].ToString()), null));
                    }
                }

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

        private void button1_Click(object sender, EventArgs e)
        {
            float suma = 0;
            float sumaesp = 0;
            int x = 0;
            for (int i = 0; i < indicadores.Count; i++)
            {
                suma += float.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString());
                x++;
                sumaesp = 0;
                for (int j = 0; j < indicadores.ElementAt(i).IndicadoresEspecificos.Count; j++)
                {
                    sumaesp += float.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString());
                    x++;
                }

                if (sumaesp != 100)
                {
                    MessageBox.Show("La Suma de Indicadores Especificos es distinta de 100");
                    return;
                }

            }
            if (suma != 100)
            {
                MessageBox.Show("La Suma de Indicadores Generales es distinta de 100");
                return;
            }
            x = 0;
            for (int i = 0; i < indicadores.Count; i++)
            {
                indicadores.ElementAt(i).descp = dataGridView1.Rows[x].Cells[0].Value.ToString();
                indicadores.ElementAt(i).peso = float.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString());
                x++;

                for (int j = 0; j < indicadores.ElementAt(i).IndicadoresEspecificos.Count; j++)
                {
                    indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(j).descp = dataGridView1.Rows[x].Cells[0].Value.ToString().Replace(" ---", "");
                    indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(j).peso = float.Parse(dataGridView1.Rows[x].Cells[1].Value.ToString());
                    x++;
                }
            }
            try
            {

                if (con.State != ConnectionState.Open)
                    con.Open();
                for (int i = 0; i < indicadores.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_UPDATE_INDICADOR";

                    cmd.Parameters.Add("@ID_IND", SqlDbType.Int).Value = indicadores.ElementAt(i).id_gen;
                    cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = indicadores.ElementAt(i).descp;
                    cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = indicadores.ElementAt(i).peso;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    for (int j = 0; j < indicadores.ElementAt(i).IndicadoresEspecificos.Count; j++)
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = con;
                        cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd2.CommandText = "SP_UPDATE_INDICADOR";

                        cmd2.Parameters.Add("@ID_IND", SqlDbType.Int).Value = indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(j).id_gen;
                        cmd2.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(j).descp;
                        cmd2.Parameters.Add("@PESO", SqlDbType.Float).Value = indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(j).peso;

                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                    }
                }
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
            this.Close();
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

