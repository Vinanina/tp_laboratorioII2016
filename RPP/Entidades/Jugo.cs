using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Jugo : Producto
    {
      
       protected ESaborJugo _sabor;
       protected static bool DeConsumo;

        #region Propiedades
       /// <summary>
       /// Propiedad get Calcula el 40% del precio del producto y lo retorna como  costo de produccion
       /// </summary>
       public override float CalcularCostoDeProduccion
          {
                get{return this._precio * 0.40f;}
          }

        #endregion
       #region Enum
       /// <summary>
       /// Enum con los sabores del jugo
       /// </summary>
           public enum ESaborJugo
           {
               Asqueroso,
               Pasable,
               Rico
           }
       #endregion
       #region Constructores
       /// <summary>
           /// Inicializa Deconsumo en true
       /// </summary>
           static Jugo()
              {
                 DeConsumo = true;
              }
          /// <summary>
          /// Inicializa los datos del producto
          /// </summary>
           /// <param name="codigoBarra">codigo de Barra</param>
          /// <param name="precio">precio</param>
          /// <param name="marca">marca</param>
          /// <param name="sabor">sabor</param>
           public Jugo(int codigoBarra,float precio,EMarcaProducto marca, ESaborJugo sabor): base (codigoBarra, marca, precio)
             {
                 this._sabor = sabor;
             }

       #endregion
       #region Metodos

       /// <summary>
       /// Sobreescribe metodo de la clase base
       /// </summary>
       /// <returns>string</returns>
          public override string Consumir()
          {
              return "Bebible";
          }
       /// <summary>
       /// Guarda los datos del jugo(incluidos los de la clase base) en un string,
       /// </summary>
       /// <returns>string</returns>
          private string MostrarJugo()
          {
              StringBuilder sb = new StringBuilder();
              sb.AppendLine(this);
              sb.AppendLine("SABOR: " + this._sabor);

              return sb.ToString();
          }
       /// <summary>
       /// Sobreescritura metodo ToString() para que al llamarlo muestre los datos del jugo
       /// </summary>
       /// <returns></returns>
          public override string ToString()
          {
            return this.MostrarJugo();
          }
                
        #endregion
    }
}
