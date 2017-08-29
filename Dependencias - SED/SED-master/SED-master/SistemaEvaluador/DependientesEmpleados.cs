using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEvaluador
{
   public class DependientesEmpleados
    {
        public String Nombre_Dependiente;
        public String Parentesco;

        public DependientesEmpleados(String Nombre_Dependiente, String Parentesco)
        {           
            this.Parentesco = Parentesco;
            this.Nombre_Dependiente = Nombre_Dependiente;
        }
    }
}
