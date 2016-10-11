using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Concecionaria 
    {
        private List<Vehiculo> _vehiculos;
        private int _espacioDisponible;
       

        #region "Constructores"
        /// <summary>
        ///Constructos que inicializa la la lista _vehiculos
        /// </summary>
        private Concecionaria()
        {
           this._vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        ///Constructos que inicializa el atributo _espacioDisponible  y llama al constructor privado que inicializa la lista _vehiculos
        /// </summary>
        /// <param name="espacioDisponible"> espacio disponible en la lista</param>
        public Concecionaria(int espacioDisponible):this ()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos
        /// </summary>
        /// <returns> string con los vehiculos de todos los tipos </returns>
        public override string ToString()
        {
            return Concecionaria.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer</param>
        /// <param name="tipoDeVehiculo">Tipos de Vehiculos a mostrar</param>
        /// <returns>retorna string con los vehiculos del Etipo tipoDeVehiculo existentes en concecionaria </returns>
        public static string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil :
                        if(v is Automovil)
                         sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if (v is Moto)
                         sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Camion:
                        if (v is Camion)
                        sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns>retorna objeto concecionaria con la lista de vehiculos actualizada si es que se modifico</returns>
        public static Concecionaria operator +(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            if (concecionaria._vehiculos.Count >= concecionaria._espacioDisponible)
                return concecionaria;

            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                if (v == vehiculo)
                    return concecionaria;
            }

            concecionaria._vehiculos.Add(vehiculo);
            return concecionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar</param>
        /// <returns>retorna objeto concecionaria con la lista de vehiculos actualizada </returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
                for (int i = 0; i < concecionaria._vehiculos.Count; i++)
                {
                    if (concecionaria._vehiculos[i] == vehiculo)
                        {
                            concecionaria._vehiculos.Remove(concecionaria._vehiculos[i]);
                            break;
                        }
                }

            return concecionaria;
        }
        #endregion
    }

}
