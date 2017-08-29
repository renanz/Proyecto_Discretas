using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPP
{
    public class Experto
    {
        public int expertoID { get; set; }
        public string nombreCompleto { get; set; }
        public List<Indicador> indicadoresPonderedByExpert { get; set; } //copia propia de los indicadores
        public bool checkedImportancia;

        public Experto()
        {
            this.checkedImportancia = false;
            indicadoresPonderedByExpert = new List<Indicador>();
        }

        //Para utilizar una lista propia y que la global no se toque hasta el final
        public void cloneList(List<Indicador> listaToClone)
        {
            foreach(Indicador i in listaToClone)
            {
                indicadoresPonderedByExpert.Add(new Indicador(i.indicadorID, 
                    i.ordenDeImportancia, i.nombreIndicador, i.peso));
            }
        }
    }
}
