using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Numero
    {
        private double _numero;

        #region constructores
        /// <summary>
        /// constructores de instancia 
        /// </summary>
        public Numero():this(0)
        { }
        public Numero(double numero)
        {
            this._numero = numero;  
        }
        public Numero(string numero)
        {
            setNumero(numero);
        }
        #endregion   
        #region Metodos
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }
        private double validarNumero(string numeroS)
        {
            double salida = 0;

            if (double.TryParse(numeroS, out salida))
                return salida;
            else
                return 0;
        }
        public double getNumero()
        {
            return this._numero;
        }
    }
        #endregion
}
