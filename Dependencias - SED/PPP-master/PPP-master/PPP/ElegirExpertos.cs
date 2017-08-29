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
    public partial class ElegirExpertos : Form
    {

        private DataTable dtExpertos;
        public List<Experto> expertosToUse { get; set; }

        public ElegirExpertos()
        {
            InitializeComponent();
            expertosToUse = new List<Experto>();
        }

        public void setTextLabel2(string text)
        {
            this.label2.Text = text;
        }

        private void ElegirExpertos_Load(object sender, EventArgs e)
        {
            SqlConnection con = ConnectionsGetter.getConnection();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                //Llenar cb con Expertos
                dtExpertos = new DataTable();
                SqlCommand cmdExpertos = new SqlCommand();
                cmdExpertos.Connection = con;
                cmdExpertos.CommandType = CommandType.Text;
                cmdExpertos.CommandText = "SELECT expertoID, (nombre + ' ' + apellido) AS Nombre FROM Expertos";
                SqlDataAdapter daExpertos = new SqlDataAdapter(cmdExpertos);
                DataSet dsExpertos = new DataSet();
                daExpertos.Fill(dsExpertos);
                dtExpertos = dsExpertos.Tables[0];

                lbExpertosDisponibles.DataSource = dtExpertos;
                lbExpertosDisponibles.DisplayMember = "Nombre";
                lbExpertosDisponibles.ValueMember = "expertoID";                                
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

        private void bFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bMoveToUsar_Click(object sender, EventArgs e)
        {
            if (lbExpertosDisponibles.SelectedIndex < 0)
                return;

            Experto expert = new Experto();
            expert.expertoID = (int)dtExpertos.Rows[lbExpertosDisponibles.SelectedIndex][0];
            expert.nombreCompleto = (string)dtExpertos.Rows[lbExpertosDisponibles.SelectedIndex][1];

            expertosToUse.Add(expert);
            actualizarExpertosToUse();

            dtExpertos.Rows.RemoveAt(lbExpertosDisponibles.SelectedIndex);
        }

        private void actualizarExpertosToUse()
        {
            lbExpertosUsar.DataSource = null;
            lbExpertosUsar.DataSource = expertosToUse;
            lbExpertosUsar.ValueMember = "expertoID";
            lbExpertosUsar.DisplayMember = "nombreCompleto";
            lbExpertosDisponibles.Refresh();
        }

        private void bMoveToDisponibles_Click(object sender, EventArgs e)
        {
            if (lbExpertosUsar.SelectedIndex < 0)
                return;

            DataRow expertoRetornar = dtExpertos.NewRow();
            expertoRetornar[0] = expertosToUse[lbExpertosUsar.SelectedIndex].expertoID;
            expertoRetornar[1] = expertosToUse[lbExpertosUsar.SelectedIndex].nombreCompleto;
            dtExpertos.Rows.Add(expertoRetornar);
                                
            expertosToUse.RemoveAt(lbExpertosUsar.SelectedIndex);
            actualizarExpertosToUse();
        }
    }
}
