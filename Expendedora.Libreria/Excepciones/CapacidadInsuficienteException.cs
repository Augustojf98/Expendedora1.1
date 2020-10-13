using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Libreria.Excepciones
{
    public class CapacidadInsuficienteException: Exception
    {
        public CapacidadInsuficienteException(string codigo) : base(string.Format("No hay más capacidad para la lata de código {0}", codigo))
        {

        }
    }
}
