using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaEvaluador
{
    public partial class GraficaDepto : Form
    {
        private int id_depto;
        private int biggest = 0;
        private SqlConnection con;
        private Random random;
        private double meta;
        private List<string> listempleados;
        private Color color_used;
        public GraficaDepto(SqlConnection con, int id_Depto)
        {
            InitializeComponent();
            this.id_depto = id_Depto;
            this.con = con;
            meta = 0;
            listempleados = new List<string>();
            random = new Random();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                DataTable dt3 = new DataTable();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText =
                    "select ev.fecha_evaluacion from EVALUACION as ev, DEPARTAMENTOS as d, EMPLEADOS as e where e.ID_DEPTO=d.ID_DEPTO and e.ID_EMPLEADO=ev.ID_EMPLEADO and d.ID_DEPTO=" +
                    id_depto + " GROUP BY ev.fecha_evaluacion";
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                DataSet ds3 = new DataSet();
                da3.Fill(ds3);
                dt3 = ds3.Tables[0];
                for (int j = 0; j < dt3.Rows.Count; j++)
                {
                    comboBox1.Items.Add(dt3.Rows[j]["fecha_evaluacion"].ToString());
                    comboBox2.Items.Add(dt3.Rows[j]["fecha_evaluacion"].ToString());
                }

                //comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                //comboBox1.ValueMember = "ID";

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

        private void GraficaDepto_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Color getRandomColor()
        {
            return Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> empleados = new List<string>();
            List<string> empleados_asignados = new List<string>();
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {



                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;

                List<int> empleados_id = new List<int>();
                cmd.CommandText = "SELECT ID_EMPLEADO, NOMBRES from EMPLEADOS where ID_DEPTO = " + id_depto;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    empleados_id.Add(int.Parse(dt.Rows[i][0].ToString()));
                    empleados.Add(dt.Rows[i][1].ToString());
                }


                List<double> valores = new List<double>();



                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("draw");
                chart1.ChartAreas["draw"].AxisY.Minimum = 0;

                chart1.ChartAreas["draw"].AxisY.Interval = 1;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                chart1.ChartAreas["draw"].AxisX.Interval = 1;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
             
                chart1.ChartAreas["draw"].BackColor = Color.White;

                for (int j = 0; j < empleados_id.Count; j++)
                {

                    DataTable dt3 = new DataTable();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.Connection = con;


                    cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd3.CommandText = "SP_RESULTADOS_VARIOS";
                    cmd3.Parameters.Add("@eval_date", SqlDbType.Date).Value =
                        DateTime.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
                    cmd3.Parameters.Add("@eval_datef", SqlDbType.Date).Value =
                        DateTime.Parse(comboBox2.GetItemText(comboBox2.SelectedItem));
                    cmd3.Parameters.Add("@id_empleado", SqlDbType.Int).Value = empleados_id.ElementAt(j);
                    cmd3.ExecuteNonQuery();
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3);
                    dt3 = ds3.Tables[0];
                    chart1.Series.Add("" + j);
                    chart1.Series["" + j].ChartType = SeriesChartType.Line;
                    color_used = getRandomColor();
                    chart1.Series["" + j].Color = color_used;
                    chart1.Series["" + j].BorderWidth = 3;
                    chart1.Series["" + j].IsValueShownAsLabel = true;

                    if (dt3.Rows.Count > 0)
                    {
                        
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            valores.Add(Double.Parse(dt3.Rows[i][0].ToString()));
                            //empleados_asignados.Add(empleados.ElementAt(j));
                            chart1.Series["" + j].Points.AddXY(i + 1, Math.Round(valores.ElementAt(i), 2));
                            if (i == 0)
                            {
                                chart1.ChartAreas[0].AxisY.CustomLabels.Add(Math.Round(valores.ElementAt(i), 2), Math.Round(valores.ElementAt(i), 2)+0.12,
                                    empleados.ElementAt(j)).ForeColor = color_used;
                            }


                        }
                        biggest += (valores.Count-biggest);
                        valores.Clear();
                       
                    }
                    cmd3.Dispose();
                }




                for (int i = 0; i < biggest; i++)
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(i , i + 2,
                        comboBox1.Items[i].ToString().Split(' ')[0]);

                
                    

                //for (int i = 0; i < valores.Count; i++)
                //{
                //    chart1.ChartAreas[0].AxisX.CustomLabels.Add(i, i + 1, comboBox1.Items[i].ToString().Split(' ')[0]);
                //    chart1.ChartAreas[0].AxisY.CustomLabels.Add(valores.ElementAt(i), valores.ElementAt(i) + 0.4, empleados_asignados.ElementAt(i));
                //}

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
            Meta met = new Meta(con);
            met.ShowDialog();
            this.meta = met.valor;

            chart1.Series.Add("MEDIA");

            chart1.Series["MEDIA"].ChartType = SeriesChartType.Line;

            chart1.Series["MEDIA"].Color = Color.Blue;
            chart1.Series["MEDIA"].BorderWidth = 3;
           
           
            for (int x = 0; x <biggest+1 ; x++)
            {
                chart1.Series["MEDIA"].Points.AddXY(x, meta);
            }

        }

    }

}
