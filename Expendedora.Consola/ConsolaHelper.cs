using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Consola
{
    public static class ConsolaHelper
    {
        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            string s = Console.ReadLine();

            return s;
        }

        public static double PedirDouble(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            double s = double.Parse(Console.ReadLine());

            return s;
        }

        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
            try
            {
                if(string.IsNullOrEmpty(input) || input.Length > 1 || !opcionesValidas.Contains(input.ToUpper()))
                {
                    return false; 
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
