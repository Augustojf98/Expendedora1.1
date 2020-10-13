using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Libreria.Excepciones
{
    public class SinStockException: Exception
    {
        public SinStockException() : base(string.Format("No hay stock de la latas"))
        {

        }
        public SinStockException(string codigo):base(string.Format("No hay stock de la lata de código {0}", codigo))
        {

        }
    }
}
