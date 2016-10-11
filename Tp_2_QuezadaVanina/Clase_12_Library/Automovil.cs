using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        #region "Constructores"
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base vehiculo
        /// </summary>
        /// <param name="marca"> marca del vehiculo</param>
        /// <param name="patente">patente del vehiculo</param>
        /// <param name="color">color del vehiculo</param>

        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// Propiedad get que retorna numero de ruedas de un automovil
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
            set { }
        }
        #endregion
        #region "Metodos"
        /// <summary>
        /// Metodo sobreescribe el metodo virtual de la clase base
        /// Llama al metodo Mostrar de la clase base y utiliza la StringBuilder para concatenar atributos de la clase automovil 
        /// </summary>
        /// <returns>retorna string con los atributos  de un automovil</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
