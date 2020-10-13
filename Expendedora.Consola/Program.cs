using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            Libreria.Clases.MaquinaExpendedora maquina = new Libreria.Clases.MaquinaExpendedora("Coca Cola");

            string titulo = "Máquina expendedora:\n";

            string menu = "1) Ingresar lata\n2) Extraer lata\n3) Obtener balance\n4) Mostrar stock\nX) Apagar máquina\n";

            bool sigueActivo = true;

            do
            {
                Console.Clear();
                Console.WriteLine(titulo);
                Console.WriteLine(menu);
                try
                {
                    string opcionSeleccionada = ConsolaHelper.PedirString("una opción de la pantalla:");
                    if(ConsolaHelper.EsOpcionValida(opcionSeleccionada, "1234X"))
                    {
                        if(opcionSeleccionada.ToUpper() == "X")
                        {
                            sigueActivo = false;
                            continue;
                        }
                        switch (opcionSeleccionada)
                        {
                            case "1":
                                AgregarLata(maquina);
                                break;
                            case "2":
                                ExtraerLata(maquina);
                                break;
                            case "3":
                                ObtenerBalance(maquina);
                                break;
                            case "4":
                                MostrarStock(maquina);
                                break;
                            default:
                                throw new Exception("Opción inválida");
                        }

                        Console.ReadKey();

                    }
                    else
                    {
                        throw new Exception("Opción inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Ocurrió un error en la aplicación. {0} Intente nuevamente.", ex.Message));
                    Console.ReadKey();
                }
            } while (sigueActivo);

            Console.WriteLine("Se apagó la máquina.");
            Console.ReadKey();

        }

        private static void GetListadoLatas(Libreria.Clases.MaquinaExpendedora maquina)
        {
            foreach(Libreria.Clases.Lata lata in maquina.Latas)
            {
                if(lata.Precio == 0  && lata.Volumen == 0)
                {
                    Console.WriteLine(string.Format("({0}) {1} {2}", lata.Codigo, lata.Nombre, lata.Sabor));
                }
            }
        }

        private static void AgregarLata(Libreria.Clases.MaquinaExpendedora maquina)
        {
            try
            {
                GetListadoLatas(maquina);

                string c = ConsolaHelper.PedirString("código de la lata");

                Console.Clear();

                Libreria.Clases.Lata lata = maquina.BuscarPorCodigo(c);

                if (lata != null)
                {
                    Console.WriteLine(string.Format("({0}) {1} {2}", lata.Codigo, lata.Nombre, lata.Sabor));

                    double p = ConsolaHelper.PedirDouble("precio de la lata");
                    double v = ConsolaHelper.PedirDouble("volumen de la lata");

                    maquina.AgregarLata(c, p, v);

                    Console.WriteLine(string.Format("Se agregó con éxito la lata de {0} {1} a la máquina", lata.Nombre, lata.Sabor));
                }
                else
                {
                    throw new Libreria.Excepciones.CodigoInvalidoException(c);
                }
            }
            catch(Libreria.Excepciones.CodigoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Excepciones.CapacidadInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ExtraerLata(Libreria.Clases.MaquinaExpendedora maquina)
        {
            try
            {
                MostrarStock(maquina);

                string c = ConsolaHelper.PedirString("código de la lata");

                Console.Clear();

                Libreria.Clases.Lata lata = maquina.BuscarPorCodigo(c);

                if (lata != null)
                {
                    Console.WriteLine(string.Format("({0}) {1} {2}", lata.Codigo, lata.Nombre, lata.Sabor));

                    double p = ConsolaHelper.PedirDouble("dinero a ingresar");

                    maquina.RetirarLata(c, p);

                    Console.WriteLine(string.Format("Se retiró con éxito la lata de {0} {1} de la máquina, ingresando ${2}", lata.Nombre, lata.Sabor, p));
                }
                else
                {
                    throw new Libreria.Excepciones.CodigoInvalidoException(c);
                }
            }
            catch (Libreria.Excepciones.CodigoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Excepciones.SinStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ObtenerBalance(Libreria.Clases.MaquinaExpendedora maquina)
        {
            Console.WriteLine(string.Format("${0} - Capacidad restante: {1} lata/s", maquina.GetBalance, maquina.GetCapacidadRestante));
        }

        private static void MostrarStock(Libreria.Clases.MaquinaExpendedora maquina)
        {
            try
            {
                if (maquina.TieneLatas)
                {
                    foreach (Libreria.Clases.Lata lata in maquina.Latas)
                    {
                        if (lata.Precio != 0 || lata.Volumen != 0)
                        {
                            Console.WriteLine(lata.ToString());
                        }
                    }
                }
                else
                {
                    throw new Libreria.Excepciones.SinStockException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
