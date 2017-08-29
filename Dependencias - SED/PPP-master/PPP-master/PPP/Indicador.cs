using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP
{
    public class Indicador
    {
        public int indicadorID { get; set; }
        public string nombreIndicador { get; set; }
        public int ordenDeImportancia;
        public float peso;

        public Indicador(int id, int orden, string nombre, float weight)
        {
            this.indicadorID = id;
            this.nombreIndicador = nombre;
            this.ordenDeImportancia = orden;
            this.peso = weight;
        }
    }
}
