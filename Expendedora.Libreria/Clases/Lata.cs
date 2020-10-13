using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora.Libreria.Clases
{
    public class Lata
    {
        private string _codigo;
        private string _nombre;
        private string _sabor;
        private double _precio;
        private double _volumen;

        public Lata(string codigo, string nombre, string sabor, double precio, double volumen)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._sabor = sabor;
            this._precio = precio;
            this._volumen = volumen;
        }

        public string Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }

        public string Sabor
        {
            get
            {
                return this._sabor;
            }
            set
            {
                this._sabor = value;
            }
        }

        public double Precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
            }
        }

        public double Volumen
        {
            get
            {
                return this._volumen;
            }
            set
            {
                this._volumen = value;
            }
        }

        public override bool Equals(object obj)
        {
            Lata lataExterna = (Lata)obj;

            return this._codigo == lataExterna._codigo && (this._precio != 0 || this._volumen != 0);
        }

        public double GetPrecioPorLitro
        {
            get
            {
                return this._precio * 1000 / this._volumen;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} $ {2} / $/L {3} ({4})", this._nombre, this._sabor, this._precio, this.GetPrecioPorLitro, this._codigo);
        }
    }
}
