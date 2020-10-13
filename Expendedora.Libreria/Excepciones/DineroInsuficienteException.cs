using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Libreria.Excepciones
{
    public class DineroInsuficienteException : Exception
    {
        public DineroInsuficienteException(string codigo, double dineroNecesario): base(string.Format("El dinero ingresado no alcanza para comprar la lata de código {0}. Hacen falta ${1}", codigo, dineroNecesario))
        {

        }
    }
}
