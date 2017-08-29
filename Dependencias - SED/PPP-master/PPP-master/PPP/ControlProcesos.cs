using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP
{
    public class ControlProcesos
    {
        //private int cantidadExpertos;
        public List<Experto> expertos { get; set; }
        public List<Indicador> indicadoresDeEvaluacion { get; set; }
        public List<Indicador> indicadoresGID{ get; set; }
        //private List<Indicador> indicadores;

        public ControlProcesos()
        {
            //indicadores = new List<Indicador>();
            indicadoresDeEvaluacion = new List<Indicador>();
            indicadoresGID = new List<Indicador>();
        }

        public List<Indicador> ordenarIndicadores(List<Indicador> indicadores)
        {
            SortOnImportancia soi = new SortOnImportancia();

            indicadores.Sort(soi);
            foreach (Indicador i in indicadores)
                Console.WriteLine("Imp: " + i.ordenDeImportancia + " Nombre: " + i.nombreIndicador);

            return indicadores;
        }             

        public class SortOnImportancia : IComparer<Indicador>
        {
            public int Compare(Indicador a, Indicador b)
            {
                if (a.ordenDeImportancia > b.ordenDeImportancia)
                    return 1;
                if (a.ordenDeImportancia < b.ordenDeImportancia)
                    return -1;

                return 0;
            }
        }
    }
}
