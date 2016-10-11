using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Clase_12_Library
{
   
    public class Moto :Vehiculo
    {
        #region "Constructores"
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base vehiculo
        /// </summary>
        /// <param name="marca"> marca del vehiculo</param>
        /// <param name="patente">patente del vehiculo</param>
        /// <param name="color">color del vehiculo</param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// Propiedad get que retorna numero de ruedas de una moto
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
            set { }
        }
        #endregion
        #region "Metodos"
        /// <summary>
        /// Metodo sobreescribe el metodo virtual de la clase base
        /// Llama al metodo Mostrar de la clase base y y utiliza la StringBuilder para concatenar atributos de la clase Moto 
        /// </summary>
        /// <returns>retorna string con los atributos  de un Moto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
