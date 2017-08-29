using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SistemaEvaluador
{
    public partial class Evaluacion : Form
    {
        int id;
        Indicadores indicador;
        Gradosindicadores grados;
        private SqlConnection con;
        private bool shouldExit = false;
        List<String> gradosLista;
        List<Indicadores_Arr> indicadores;
        List<grados_Arr> gradosInsert;
        public Evaluacion(SqlConnection con)
        {

            InitializeComponent();
            this.con = con;
            grados = new Gradosindicadores(con);
            gradosInsert = new List<grados_Arr>();
            id = 0;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Evaluacion_Load(object sender, EventArgs e)
        {
            EvaluacionNombre Evanom = new EvaluacionNombre(con);
            Evanom.ShowDialog();
            this.shouldExit = Evanom.exiting;
            if (Evanom.exiting)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();

                return;
            }
            Nombre.Text = Evanom.nombreEvaluacion;
            Fecha.Text = DateTime.Today.ToString();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandType = System.Data.CommandType.Text;
                cmd2.CommandText = "SELECT TOP 1 ID from INFORME_INDICADORES ORDER BY ID DESC";
                SqlDataAdapter da = new SqlDataAdapter(cmd2);

                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                id = int.Parse(dt.Rows[0][0].ToString());
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

            GradosInicio grad = new GradosInicio();
            grad.ShowDialog();
            gradosLista = grad.grados;
            for (int i = 0; i < gradosLista.Count; i++)
            {
                gradosInsert.Add(new grados_Arr(0, int.Parse(dt.Rows[0][0].ToString()), gradosLista.ElementAt(i), i + 1));
            }

            Indicadores ind = new Indicadores(con, gradosInsert);
            ind.ShowDialog();
            indicadores = ind.indicadoresEspecificos;
            indicador = new Indicadores(con, gradosInsert);

            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {

            dataGridView1.ColumnCount = gradosLista.Count() + 2;
            dataGridView1.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new System.Drawing.Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Columns[0].Name = "Peso";
            dataGridView1.Columns[1].Name = "Indicadores";
            for (int i = 0; i < gradosLista.Count(); i++)
            {
                dataGridView1.Columns[i + 2].Name = gradosLista.ElementAt(i);
            }



            AddIndicadoresDataGrid();
        }

        private void AddIndicadoresDataGrid()
        {
            string[] rows = new string[gradosLista.Count() + 1];
            for (int i = 0; i < indicadores.Count(); i++)
            {
                //Agregar indicador General, luego un for para el especifico de este
                rows[0] = indicadores.ElementAt(i).peso.ToString();
                rows[1] = indicadores.ElementAt(i).descp;
                dataGridView1.Rows.Add(rows);
                for (int x = 0; x < indicadores.ElementAt(i).IndicadoresEspecificos.Count(); x++)
                {
                    rows[0] = indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(x).peso.ToString();
                    rows[1] = "   ------" + indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(x).descp;

                    dataGridView1.Rows.Add(rows);
                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        for (int h = 0;
                            h < indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(x).grados.Count;
                            h++)
                        {
                            if (indicadores.ElementAt(i).IndicadoresEspecificos.ElementAt(x).grados.ElementAt(h).nombre ==
                                dataGridView1.Columns[j].Name)
                            {
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j].ReadOnly = false;
                                break;
                            }
                            else
                            {
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[j].ReadOnly = true;
                            }
                        }
                    }

                }

            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                dataGridView1.Rows[i].Cells[1].ReadOnly = true;
            }

        }

        private void guardarEvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application Excel = new Excel.Application();
            Workbook wb = Excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)Excel.ActiveSheet;

            Excel.Visible = true;

            ws.Cells[3, 2] = "Pesos";
            ws.Cells[3, 3] = "Indicadores";

            for (int i = 0; i < gradosLista.Count(); i++)
            {
                ws.Cells[3, i + 4] = gradosLista.ElementAt(i);
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int x = 0; x < gradosLista.Count() + 2; x++)
                {
                    ws.Cells[i + 4, x + 2] = dataGridView1.Rows[i].Cells[x].Value;
                }
            }

            Excel.Range usedRange = ws.UsedRange;
            Excel.Range rows = usedRange.Rows;

            Borders border = rows.Borders;
            int count = 0;
            foreach (Excel.Range row in rows)
            {

                if (count == 0)
                {
                    row.Interior.Color = Color.SeaGreen;
                    row.Font.Color = ColorTranslator.ToOle(Color.White);
                    row.Font.Size = 12;

                }
                //row.Cells.AutoFit();

                border[XlBordersIndex.xlEdgeLeft].LineStyle =
              XlLineStyle.xlContinuous;
                border[XlBordersIndex.xlEdgeTop].LineStyle =
                   XlLineStyle.xlContinuous;
                border[XlBordersIndex.xlEdgeBottom].LineStyle =
                    XlLineStyle.xlContinuous;
                border[XlBordersIndex.xlEdgeRight].LineStyle =
                   XlLineStyle.xlContinuous;
                //row.Cells.AutoFit();
                count++;
            }

            Excel.Range chartRange;

            usedRange.Columns.Rows[0].Merge(false);
            chartRange = usedRange.Columns.Rows[0];
            chartRange.FormulaR1C1 = "Sistema Evaluador del Desempeño\n" + "Evaluacion: " + Nombre.Text + "\n" + "Fecha: " + DateTime.Today;
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 2;
            chartRange.Interior.Color = ColorTranslator.ToOle(Color.SeaGreen);
            chartRange.Font.Color = ColorTranslator.ToOle(Color.White);
            chartRange.Font.Size = 16;

        }

        private void indicadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar_Indicadores ed = new Editar_Indicadores(con, 9);
            ed.ShowDialog();
        }

        private void gradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarGrados gr = new EditarGrados(con, 2);
            gr.ShowDialog();
        }

        private void cancelarEvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[4, 2] = "";
            xlWorkSheet.Cells[4, 3] = "Student1";
            xlWorkSheet.Cells[4, 4] = "Student2";
            xlWorkSheet.Cells[4, 5] = "Student3";

            xlWorkSheet.Cells[5, 2] = "Term1";
            xlWorkSheet.Cells[5, 3] = "80";
            xlWorkSheet.Cells[5, 4] = "65";
            xlWorkSheet.Cells[5, 5] = "45";

            xlWorkSheet.Cells[6, 2] = "Term2";
            xlWorkSheet.Cells[6, 3] = "78";
            xlWorkSheet.Cells[6, 4] = "72";
            xlWorkSheet.Cells[6, 5] = "60";

            xlWorkSheet.Cells[7, 2] = "Term3";
            xlWorkSheet.Cells[7, 3] = "82";
            xlWorkSheet.Cells[7, 4] = "80";
            xlWorkSheet.Cells[7, 5] = "65";

            xlWorkSheet.Cells[8, 2] = "Term4";
            xlWorkSheet.Cells[8, 3] = "75";
            xlWorkSheet.Cells[8, 4] = "82";
            xlWorkSheet.Cells[8, 5] = "68";

            xlWorkSheet.Cells[9, 2] = "Total";
            xlWorkSheet.Cells[9, 3] = "315";
            xlWorkSheet.Cells[9, 4] = "299";
            xlWorkSheet.Cells[9, 5] = "238";

            xlWorkSheet.get_Range("b2", "e3").Merge(false);

            chartRange = xlWorkSheet.get_Range("b2", "e3");
            chartRange.FormulaR1C1 = "MARK LIST";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            chartRange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            chartRange.Font.Size = 20;

            chartRange = xlWorkSheet.get_Range("b4", "e4");
            chartRange.Font.Bold = true;
            chartRange = xlWorkSheet.get_Range("b9", "e9");
            chartRange.Font.Bold = true;

            chartRange = xlWorkSheet.get_Range("b2", "e9");
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkBook.SaveAs("", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            // releaseObject(xlApp);
            // releaseObject(xlWorkBook);
            //releaseObject(xlWorkSheet);

            MessageBox.Show("File created !");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Evaluacion_Shown(object sender, EventArgs e)
        {
            if (this.shouldExit)
                this.Close();
        }
    }
}
