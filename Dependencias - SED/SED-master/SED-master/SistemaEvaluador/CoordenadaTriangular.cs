using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
    public class CoordenadaTriangular
    {
        public List<NumeroTriangular> NumeroBorrosoTriangular;
        public List<string> NombreCoordenada ;
        public float cantidadGrados;
        public string Indicador;
        private List<string> cols;

        public CoordenadaTriangular(List<string> NombreCoordenada, float cg,string Indicador, List<string> cols)
        {
        
            this.NombreCoordenada = NombreCoordenada;
            this.cantidadGrados = cg;
            this.Indicador = Indicador;
            this.cols = cols;
            this.NumeroBorrosoTriangular = new List<NumeroTriangular>();
            GenerarBorroso();
        }

        public void GenerarBorroso()
        {
            
            for (int i = 0; i < cantidadGrados ; i++)
            {
                
                for (int j = 0; j < NombreCoordenada.Count; j++)
                {
                    
                    
                    if (i == 0 && NombreCoordenada[j] == cols[i] )
                    {
                        NumeroTriangular nt = new NumeroTriangular();
                        nt.x = 0;
                        nt.y = 0;
                        nt.z = (i + 1)/(cantidadGrados - 1);
                        NumeroBorrosoTriangular.Add(nt);
                       
                    }
                    else if (i != cantidadGrados - 1 && NombreCoordenada[j] == cols[i])
                    {
                        NumeroTriangular nt = new NumeroTriangular();
                        nt.x = (i - 1)/(cantidadGrados - 1);
                        nt.y = i/(cantidadGrados - 1);
                        nt.z = (i + 1)/(cantidadGrados - 1);
                        NumeroBorrosoTriangular.Add(nt);
                        
                    }
                    else if(i == cantidadGrados- 1 && NombreCoordenada[j] == cols[i])
                    {
                        NumeroTriangular nt = new NumeroTriangular();
                        nt.x = (i - 1)/(cantidadGrados - 1);
                        nt.y = 1;
                        nt.z = 1;
                        NumeroBorrosoTriangular.Add(nt);
                        
                    }
                   
                   
                }
            }
        }

    }
}
