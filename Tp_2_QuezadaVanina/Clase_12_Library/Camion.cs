using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
       
        #region "Constructores" 
        /// <summary>
        /// Constructor que inicializa los atributos de la clase base vehiculo
        /// </summary>
        /// <param name="marca"> marca del vehiculo</param>
        /// <param name="patente">patente del vehiculo</param>
        /// <param name="color">color del vehiculo</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// Propiedad get que retorna numero de ruedas de un camion. Los camiones tienen 8 ruedas
        /// </summary>
        
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
            set { }
        }
        #endregion
        #region "Metodos"
        /// <summary>
        /// Metodo sobreescribe el metodo virtual de la clase base
        /// Llama al metodo Mostrar de la clase base y le concatena atributos de la clase camion
        /// </summary>
        /// <returns>retorna string con los atributos  de un camion</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
         #endregion
    }
}
