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
    public partial class ListarExpertos : Form
    {
        public ListarExpertos()
        {
            InitializeComponent();
        }

        private void ListarExpertos_Load(object sender, EventArgs e)
        {
            SqlConnection con = ConnectionsGetter.getConnection();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmdExpertos = new SqlCommand("", con);
                cmdExpertos.CommandType = CommandType.Text;
                cmdExpertos.CommandText = "SELECT * FROM v_Expertos";
                SqlDataAdapter da = new SqlDataAdapter(cmdExpertos);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dgvExpertos.DataSource = dt;
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

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
