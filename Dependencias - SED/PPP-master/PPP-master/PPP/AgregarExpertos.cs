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
    public partial class AgregarExpertos : Form
    {
        private Point startPoint;

        public AgregarExpertos(int parentWidth, int parentHeight)
        {
            InitializeComponent();
            startPoint = new Point(parentWidth / 2 - this.Width / 2, 
                parentHeight / 2 - this.Height / 2);           
        }

        private void AgregarExpertos_LocationChanged(object sender, EventArgs e)
        {
            this.Location = startPoint;
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAgregar_Click(object sender, EventArgs e)
        {
            SqlCommand cmdAgregar = null;
            SqlConnection con = ConnectionsGetter.getConnection();
            if(String.IsNullOrEmpty(tNombre.Text) || String.IsNullOrEmpty(tApellido.Text))
            {
                MessageBox.Show("Ingrese un nombre o apellido.");
                return;
            }
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                cmdAgregar = new SqlCommand();
                cmdAgregar.Connection = con;
                cmdAgregar.CommandType = CommandType.StoredProcedure;
                cmdAgregar.CommandText = "sp_insert_experto";
                cmdAgregar.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tNombre.Text;
                cmdAgregar.Parameters.Add("@apellido", SqlDbType.VarChar).Value = tApellido.Text;
                cmdAgregar.ExecuteNonQuery();
                cmdAgregar.Dispose();
                MessageBox.Show("Se agregó correctamente.");
                limpiar();
            }
            catch (Exception ene)
            {
                MessageBox.Show("No se logró agregar el experto."+ ene.ToString());
                Console.WriteLine(ene.ToString());
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
        }

        private void limpiar()
        {
            tNombre.Clear();
            tApellido.Clear();
        }
    }
}
