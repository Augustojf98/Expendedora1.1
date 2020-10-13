using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Libreria.Excepciones
{
    public class CodigoInvalidoException:Exception
    {
        public CodigoInvalidoException(string codigo):base(string.Format("El código {0} es inválido.", codigo))
        {

        }
    }
}
