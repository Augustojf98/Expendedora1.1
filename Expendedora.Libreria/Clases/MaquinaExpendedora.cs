using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Libreria.Clases
{
    public class MaquinaExpendedora
    {
        private List<Lata> _latas;
        private string _proveedor;
        private int _capacidad;
        private double _dinero;
        private bool _encendida;

        public bool TieneLatas
        {
            get
            {
                return this._latas.Count - 6 > 0;
            }
        }

        public List<Lata> Latas
        {
            get
            {
                return this._latas;
            }
        }

        public MaquinaExpendedora(string proveedor)
        {
            this._proveedor = proveedor;
            this._encendida = true;
            this._latas = new List<Lata>();
            this._latas.Add(new Lata("CO1", "Coca Cola", "Regular", 0, 0));
            this._latas.Add(new Lata("CO2", "Coca Cola", "Zero", 0, 0));
            this._latas.Add(new Lata("SP1", "Sprite", "Regular", 0, 0));
            this._latas.Add(new Lata("SP2", "Sprite", "Zero", 0, 0));
            this._latas.Add(new Lata("FA1", "Fanta", "Regular", 0, 0));
            this._latas.Add(new Lata("FA2", "Fanta", "Zero", 0, 0));
            this._capacidad = _latas.Count();
        }

        public void AgregarLata(string codigo, double precio, double volumen)
        {
            Lata lataModelo = BuscarPorCodigo(codigo);
            Lata lata = BuscarStockPorCodigo(codigo);

            if (lata == null)
            {
                this._latas.Add(new Lata(codigo, lataModelo.Nombre, lataModelo.Sabor, precio, volumen));
            }
            else
            {
                throw new Excepciones.CapacidadInsuficienteException(codigo);
            }
        }

        public int GetCapacidadRestante
        {
            get
            {
                return this._capacidad - CantidadStock;
            }
        }

        public double GetBalance
        {
            get
            {
                return this._dinero;
            }
        }

        public void RetirarLata(string codigo, double dineroIngresado)
        {
            Lata lata = BuscarStockPorCodigo(codigo);

            if(lata != null)
            {
                if(lata.Precio <= dineroIngresado)
                {
                    this._latas.Remove(lata);
                    this._dinero = this._dinero + lata.Precio;
                }
                else
                {
                    throw new Excepciones.DineroInsuficienteException(codigo, lata.Precio);
                }
            }
            else
            {
                throw new Excepciones.SinStockException(codigo);
            }
        }

        public int CantidadStock
        {
            get
            {
                List<Lata> lista = new List<Lata>();
                foreach(Lata lata in _latas)
                {
                    if(lata.Precio != 0 ||lata.Volumen != 0)
                    {
                        lista.Add(lata);
                    }
                }

                return lista.Count;
            }
        }

        public Lata BuscarPorCodigo(string codigo)
        {
            foreach (Lata lata in _latas)
            {
                if(lata.Codigo == codigo.ToUpper() && lata.Precio == 0 && lata.Volumen == 0)
                {
                    return lata;
                }
                return null;
            }
            return null;
        }

        public Lata BuscarStockPorCodigo(string codigo)
        {
            foreach (Lata lata in _latas)
            {
                if (lata.Codigo == codigo.ToUpper() && (lata.Volumen != 0 || lata.Precio != 0))
                {
                    return lata;
                }
            }
            return null;
        }
    }
}
