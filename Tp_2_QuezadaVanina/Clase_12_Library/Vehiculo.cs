using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
       
        protected EMarca _marca;
        protected  string _patente;
        protected ConsoleColor _color;
        #region "Propiedades"
        /// <summary>
        /// Propiedaded get retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadRuedas { get; set; }
        #endregion
        #region "Constructores"
        /// <summary>
        /// Contructor inicializa atributos de la clase
        /// </summary>
        /// <param name="marca"> marca del vehiculo</param>
        /// <param name="patente">patente del vehiculo</param>
        /// <param name="color">color del vehiculo</param>
        public Vehiculo(string patente, EMarca marca, ConsoleColor color)
        {
            this._patente = patente;
            this._marca = marca;
            this._color = color;
        }
        #endregion
        #region "Metodos"
        /// <summary>
        /// Metodo virtual 
        /// Utiliza StringBuilder para concatenar atributos de un vehiculo 
        /// </summary>
        /// <returns>retorna string con los atributos  de un Vehiculo</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
        #region "Sobrecarga Operadores"
        /// <summary>
        ///Sobrecarga Operador  ==.Compara dos vehículos, si comparten la misma patente retorna true 
        /// </summary>
        /// <param name="v1"> parametro de tipo vehiculo</param>
        /// <param name="v2"> parametro de tipo vehiculo</param>
        /// <returns>Retorna bool, true si las patentes son iguales,false si son diferentes</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1._patente == v2._patente)
            { return true; }

            return false;
        }
        /// <summary>
        /// Sobrecarga Operador  !=
        /// Compara dos vehículos, si tienen patentes diferentes retorna true 
        /// </summary>
        /// <param name="v1"> parametro de tipo vehiculo</param>
        /// <param name="v2"> parametro de tipo vehiculo</param>
        /// <returns>Retorna bool, true si las patentes son diferentes,false si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
