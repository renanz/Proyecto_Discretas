using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPP
{
    public partial class Menu : Form
    {
        private int evaluacionToPonder;

        public Menu(string [] args)
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            evaluacionToPonder = args.Length == 0 ? 4 : Convert.ToInt16(args[0]);
        }

        private void listarExpertosItem_Click(object sender, EventArgs e)
        {
            ListarExpertos frm = new ListarExpertos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void agregarExpertosItem_Click(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            AgregarExpertos frm = new AgregarExpertos(this.Width, this.Height);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ponderarIndicadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenarIndicadores ordFrm = new OrdenarIndicadores(evaluacionToPonder);           
            ordFrm.MdiParent = this;
            ordFrm.Show();
            List<Indicador> indicadores;
            indicadores = ordFrm.control.indicadoresDeEvaluacion;
            ordFrm.setIndicadores(indicadores);
            //for (int i = 0; i < ordFrm.control.indicadoresGID.Count; i++)
            //{
            //    //throw new Exception(ordFrm.control.indicadoresGID.Count.ToString());
            //    OrdenarIndicadores o = new OrdenarIndicadores(evaluacionToPonder, true, indicadores[i].indicadorID,indicadores[i].nombreIndicador);
            //    o.MdiParent = this;
            //    o.Show();
            //}
        }
    }
}
