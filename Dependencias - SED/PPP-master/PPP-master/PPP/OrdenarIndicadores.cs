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


namespace PPP
{
    public partial class OrdenarIndicadores : Form
    {
        
        public ControlProcesos control { get; set; }
        private Experto expertoActual { get; set; }
        private int evaluacionToPonder { get; set; }
        private List<Indicador> indicadores { get; set; }
        private int indexExpertoActual { get; set; }
        private bool IE = false;
        private string indicador { get; set; }
        private bool ready { get; set; }
        private int IDG;
        public OrdenarIndicadores(int evaluacionID)
        {
            InitializeComponent();
            this.evaluacionToPonder = evaluacionID;
            indexExpertoActual = 0;
            ready = false;
            indicador = "";

            indicadores = new List<Indicador>();
        }

        public OrdenarIndicadores(int evaluacionID, bool IE, int ID, string indicador)
        {
            control = new ControlProcesos();
            indicadores = new List<Indicador>();
            InitializeComponent();
            this.evaluacionToPonder = evaluacionID;
            indexExpertoActual = 0;
            this.IE = IE;
            IDG = ID;
            this.indicador = indicador;
            this.label2.Text += indicador;
            this.label2.Visible = true;
        }

        public void setIndicadores(List<Indicador> i)
        {
            indicadores = i;
            //MessageBox.Show(indicadores.Count.ToString() +"dentro de setI O");
            //throw new Exception(control.indicadoresGID.Count.ToString());
        }

        private void loadIndicadores()
        {
            SqlConnection con = ConnectionsGetter.getConnection();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                //Llenar cb con Expertos
                DataTable dtExpertos = new DataTable();
                SqlCommand cmdExpertos = new SqlCommand();
                cmdExpertos.Connection = con;
                cmdExpertos.CommandType = CommandType.Text;
                cmdExpertos.CommandText = "SELECT ID_IND, NOMBRE FROM INDICADORES WHERE ID = " + evaluacionToPonder + " AND ID_GEN IS NULL";//"SELECT ID_IND, NOMBRE FROM INDICADORES WHERE ID = " + evaluacionToPonder; 
                SqlDataAdapter daExpertos = new SqlDataAdapter(cmdExpertos);
                DataSet dsExpertos = new DataSet();
                daExpertos.Fill(dsExpertos);
                dtExpertos = dsExpertos.Tables[0];

                int valorOrden = 1;
                foreach (DataRow dr in dtExpertos.Rows)
                {
                    control.indicadoresDeEvaluacion.Add(new Indicador((int) dr[0], valorOrden++, dr[1].ToString(), 0));
                    control.indicadoresGID.Add(new Indicador((int)dr[0], valorOrden++, dr[1].ToString(), 0));
                }
                ready = true;
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
        private void loadIndicadoresFromGeneral()
        {
            SqlConnection con = ConnectionsGetter.getConnection();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                //Llenar cb con Expertos
                DataTable dtExpertos = new DataTable();
                SqlCommand cmdExpertos = new SqlCommand();
                cmdExpertos.Connection = con;
                cmdExpertos.CommandType = CommandType.Text;
                cmdExpertos.CommandText = "SELECT ID_IND, NOMBRE FROM INDICADORES WHERE ID = " + evaluacionToPonder + " AND ID_GEN = "+IDG;//"SELECT ID_IND, NOMBRE FROM INDICADORES WHERE ID = " + evaluacionToPonder; 
                SqlDataAdapter daExpertos = new SqlDataAdapter(cmdExpertos);
                DataSet dsExpertos = new DataSet();
                daExpertos.Fill(dsExpertos);
                dtExpertos = dsExpertos.Tables[0];

                int valorOrden = 1;
                foreach (DataRow dr in dtExpertos.Rows)
                {
                    control.indicadoresDeEvaluacion.Add(new Indicador((int)dr[0], valorOrden++, dr[1].ToString(), 0));
                }
                //MessageBox.Show(control.indicadoresGID.Count.ToString());
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

        private void actualizarOrdenIndicadores()
        {
            lbIndicadores.DataSource = null;
            lbIndicadores.DataSource = expertoActual.indicadoresPonderedByExpert;
            lbIndicadores.ValueMember = "indicadorID";
            lbIndicadores.DisplayMember = "nombreIndicador";
            lbIndicadores.Refresh();
        }

        private void OrdenarIndicadores_Load(object sender, EventArgs e)
        {
            //Elegir los expertos (y de esta cantidad dependen los promedios) a ponderar
            ElegirExpertos electExpertFrm = new ElegirExpertos();
            if (IE)
            {
                electExpertFrm.setTextLabel2("Indicadores Especificos de "+indicador);
            }
            electExpertFrm.ShowDialog();
            control = new ControlProcesos();
            control.expertos = electExpertFrm.expertosToUse;
            foreach (Experto exp in control.expertos)
                Console.WriteLine(exp.nombreCompleto);

            lMensaje.Text = "Ordenar de mayor importancia\n(Muy Importante) a menor\n(Muy Poco Importante)";
            if(!IE)          
                loadIndicadores();
            else
            {
                loadIndicadoresFromGeneral();
            }
            loadExperto();
        }

        private void loadExperto()
        {
            expertoActual = control.expertos[indexExpertoActual++];
            lExperto.Text = "Experto: " + expertoActual.nombreCompleto;
            expertoActual.cloneList(control.indicadoresDeEvaluacion);
            actualizarOrdenIndicadores();
        }

        private void bIncrementar_Click(object sender, EventArgs e)
        {
            moveIndicador(1);
            actualizarOrdenIndicadores();
        }

        private void moveIndicador(int moveBy)
        {
            int indicIndexToMove = lbIndicadores.SelectedIndex;
            int newIndex = indicIndexToMove - moveBy;
            Indicador indicador = expertoActual.indicadoresPonderedByExpert[indicIndexToMove];

            if (newIndex == -1 || newIndex == control.indicadoresDeEvaluacion.Count)
            {
                MessageBox.Show("Ya está en un valor tope.");
                return;
            }
            expertoActual.indicadoresPonderedByExpert[newIndex].ordenDeImportancia += moveBy;//
            indicador.ordenDeImportancia -= moveBy;//4 - 1, 4 - (-1); 3, 5

            expertoActual.indicadoresPonderedByExpert =
                control.ordenarIndicadores(expertoActual.indicadoresPonderedByExpert);
        }

        private void bFinalizar_Click(object sender, EventArgs e)
        {
            if(indexExpertoActual == control.expertos.Count)
            {
                MessageBox.Show("Todos los expertos han terminado de determinar la importancia de los indicadores.");
                ordenarIndicadoresFinal();
                listarIndicadoresOrdenados();
                PonderarIndicadores ponderarFrm = new PonderarIndicadores(control);

                ponderarFrm.setIndicadores(indicadores);
                ponderarFrm.setEvaluacion(this.evaluacionToPonder);
                if (IE)
                {
                    ponderarFrm.setLabel2Text(indicador);    
                }
                this.Visible = false;
                ponderarFrm.ShowDialog();
                this.Close();
                return;
            }
            //continuar con el siguiente experto si no hemos terminado
            loadExperto();
        }

        private void listarIndicadoresOrdenados()
        {
            StringBuilder sb = new StringBuilder();
            string ordenadosMensaje = "Los indicadores de mayor a menor importancia son:\n";
            int lugar = 1;
            foreach(Indicador ind in control.indicadoresDeEvaluacion)            
                sb.Append(String.Format("\t{0}. Id: {1} Nombre: {2}\n", lugar++, ind.indicadorID, ind.nombreIndicador));
            
            MessageBox.Show(ordenadosMensaje + sb.ToString());
        }

        //Para dejar la lista final según la suma de la importancia de cada indicador según cada experto
        private void ordenarIndicadoresFinal()
        {
            foreach (Indicador ind in control.indicadoresDeEvaluacion)
                ind.ordenDeImportancia = 0;

            foreach(Experto exper in control.expertos)
            {
                for (int i = 0; i < control.indicadoresDeEvaluacion.Count; i++)
                {
                    Indicador indActual = control.indicadoresDeEvaluacion[i];
                     indActual.ordenDeImportancia += exper.indicadoresPonderedByExpert.//buscar con expresión lambda, variable interna si los IDs son iguales
                        Find(indBuscar => indBuscar.indicadorID == indActual.indicadorID).ordenDeImportancia;      
                }                       
            }
            Console.WriteLine("\n\n\n******IMPORTANCIAS FINALES******\n");
            control.indicadoresDeEvaluacion = control.ordenarIndicadores(control.indicadoresDeEvaluacion);
        }

        private void bDecrementar_Click(object sender, EventArgs e)
        {
            moveIndicador(-1);
            actualizarOrdenIndicadores();
        }
    }    
}
