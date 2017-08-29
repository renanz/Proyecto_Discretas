using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class grados_Arr
    {
        public int ID_IND;
        public int ID;
        public string nombre;
        public int valor;
        public grados_Arr(int ID_IND, int ID, string nombre, int valor)
        {
            this.ID_IND = ID_IND;
            this.ID = ID;
            this.nombre = nombre;
            this.valor = valor;
        }

    }
}
