using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PPP
{
    public partial class PonderarIndicadores : Form
    {
        private ControlProcesos control { get; set; }
        private Experto expertoActual { get; set; }
        private List<Indicador> indicadores { get; set; }
        private int evaluacionToPonder { get; set; }
        //empezar en la columna 2 porque las primeras dos son de nombre y ID respectivamente  
        private static int indexDeControl = 2;

        public PonderarIndicadores(ControlProcesos control)
        {
            InitializeComponent();
            this.control = control;
            indicadores = new List<Indicador>();
        }

        public void setLabel2Text(string texto)
        {
            this.label2.Text += texto;
            this.label2.Visible = true;
        }
        public void setEvaluacion(int i)
        {
            this.evaluacionToPonder = i;
        }

        public void setIndicadores(List<Indicador> indicadores)
        {
            this.indicadores = indicadores;
        }
        private void PonderarIndicadores_Load(object sender, EventArgs e)
        {
            setOwnDataTable();
        }

        private void setOwnDataTable()
        {
            //Personalización de columnas del DGV
            dgvIndicadores.Columns.Add("indicadores", "Indicadores");
            //Definir el de ids sólo para tener datos, pero esconderlo de vista porque el usuario no lo ocupa
            dgvIndicadores.Columns.Add("indicadorID", "IDs");
            dgvIndicadores.Columns[1].Visible = false;
            for (int i = 0; i < control.expertos.Count; i++)
                dgvIndicadores.Columns.Add(string.Format("experto{0}", i), control.expertos[i].nombreCompleto);

            fillDatosDGV();
        }

        private void fillDatosDGV()
        {
            //Arreglo personalizado para contener el nombre del indicador, su ID y sus tres scores
            object[] valores = new object[control.expertos.Count + 2];
            foreach (Indicador ind in control.indicadoresDeEvaluacion)
            {
                valores[0] = ind.nombreIndicador;
                valores[1] = ind.indicadorID;
                for (int i = 2; i < valores.Length; i++)
                {//llenar cada lugar restante con el peso que cada experto le dio a este indicador en la iteración
                    valores[i] = control.expertos[i - 2].indicadoresPonderedByExpert.
                        Find(indToFind => indToFind.indicadorID == ind.indicadorID).peso;
                }
                dgvIndicadores.Rows.Add(valores);
            }
        }

        private void bFinalizar_Click(object sender, EventArgs e)
        {
            //Update DB with new pesos for indicadores
            if (validateSums() && validateImportancias())
            {
                promediarPesos();
                updatePesos();
                MessageBox.Show("Se han actualizado los pesos de los indicadores ponderados.");
                this.Visible = false;
                if (indicadores.Count>0)
                {
                    OrdenarIndicadores o = new OrdenarIndicadores(evaluacionToPonder, true,
                        indicadores[0].indicadorID, indicadores[0].nombreIndicador);
                indicadores.RemoveAt(0);
                    o.setIndicadores(indicadores);
                    o.MdiParent = this.MdiParent;
                    o.Show();
                }
                this.Close();
            }
        }

        //valida que las sumas de todos los indicadores den 100; si no, indica quién lo tiene mal(primera ocurrencia)
        private bool validateSums()
        {
            for (int columnIndex = indexDeControl; columnIndex < control.expertos.Count + indexDeControl; columnIndex++)
            {
                float sumaPesos = 0;
                for (int i = 0; i < control.indicadoresDeEvaluacion.Count; i++)
                    sumaPesos += float.Parse(dgvIndicadores.Rows[i].Cells[columnIndex].Value.ToString());

                if (sumaPesos != 100)
                {
                    MessageBox.Show("La suma de indicadores es distinta de 100 para el experto: "
                        + control.expertos[columnIndex - indexDeControl].nombreCompleto);
                    return false;
                }
            }

            return true;
        }

        //valida que los valores estén de mayor a menor; si no, indica quién lo tiene mal (primera ocurrencia)
        private bool validateImportancias()
        {
            for (int columnIndex = indexDeControl;
                columnIndex < control.expertos.Count + indexDeControl;
                columnIndex++)//columnIndex, alias el expert
            {
                //compara todos los expertos, y agrega un arreglo para cada uno para comparar sus pesos
                float[] pesosIndicadores = new float[control.indicadoresDeEvaluacion.Count];
                int indexComparador = 0;

                //compara los indicadores, para ver si siguen el peso de importancia indicado
                for (int i = 0; i < control.indicadoresDeEvaluacion.Count; i++)
                    pesosIndicadores[i] = (float.Parse(dgvIndicadores.Rows[i].Cells[columnIndex].Value.ToString()));
                do
                {   //se compara un índice arriba del indicador que se está comparando actualmente
                    for (int i = indexComparador + 1; i < control.indicadoresDeEvaluacion.Count; i++)
                    {
                        if (pesosIndicadores[indexComparador] < pesosIndicadores[i])
                        {
                            MessageBox.Show("La suma de los pesos está mal para el experto: " +
                                control.expertos[columnIndex - indexDeControl].nombreCompleto
                                + "\nSiga el orden de importancia de mayor a menor según el mensaje ya indicado.");
                            return false;
                        }
                    }
                    indexComparador++;
                } while (indexComparador < control.indicadoresDeEvaluacion.Count);
            }

            return true;
        }

        private void promediarPesos()
        {
            int cantidadExpertos = control.expertos.Count;

            for(int fila = 0; fila < control.indicadoresDeEvaluacion.Count; fila++)
            {
                float pesoSumado = 0;
                for(int columna = indexDeControl; columna < cantidadExpertos + indexDeControl; columna++)
                {
                    pesoSumado += float.Parse(dgvIndicadores.Rows[fila].Cells[columna].Value.ToString());
                }

                control.indicadoresDeEvaluacion[fila].peso = pesoSumado / cantidadExpertos;
            }
        }

        private void updatePesos()
        {
            SqlConnection con = ConnectionsGetter.getConnection();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                for (int i = 0; i < control.indicadoresDeEvaluacion.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("", con);
                    Indicador indToUpdate = control.indicadoresDeEvaluacion[i];
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_UPDATE_INDICADOR";

                    cmd.Parameters.Add("@ID_IND", SqlDbType.Int).Value = indToUpdate.indicadorID;
                    cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = indToUpdate.nombreIndicador;
                    cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = indToUpdate.peso;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();                   
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

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
