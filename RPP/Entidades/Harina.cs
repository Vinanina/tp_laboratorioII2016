using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
       private ETipoHarina _tipo; 
       protected static bool DeConsumo;

       
       #region Enumerado
        /// <summary>
        /// Enum con tipos de harina
        /// </summary>
            public enum ETipoHarina
           {
               Integral,
               CuatroCeros
           }
       #endregion
       #region Propiedades

            /// <summary>
            ///Propiedad get Calcula el 60% del precio del producto y lo retorna como  costo de produccion
            /// </summary>
           public override float CalcularCostoDeProduccion
                {
                    get { return this.Precio * 0.60f; }
                 }
            
        #endregion
        #region Constructores

            /// <summary>
            /// Inicializa Deconsumo en false
            /// </summary>
           static Harina()
            {
                DeConsumo = false;  
            }

           /// <summary>
           /// Inicializa los datos del producto
           /// </summary>
           /// <param name="codigoBarra">codigo de Barra</param>
           /// <param name="precio">precio</param>
           /// <param name="marca">marca</param>
           /// <param name="tipo">tipo</param>
            public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo)
                : base(codigoBarra, marca, precio)
            {
                this._tipo = tipo;
            }
        #endregion
        #region Metodos

            /// <summary>
            /// Guarda los datos de Harina(incluidos los de la clase base) en un string,
            /// </summary>
            /// <returns>string</returns>
            private string MostrarHarina()
            {
                StringBuilder sb = new StringBuilder();
                
                sb.AppendLine(this);
                sb.AppendLine("TIPO: " + this._tipo);

                return sb.ToString();
            }

            /// <summary>
            /// Sobreescritura metodo ToString() para que al llamarlo muestre los datos de la harina
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return this.MostrarHarina();
            }
        #endregion

    }
}
