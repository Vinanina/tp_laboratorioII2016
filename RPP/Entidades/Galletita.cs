using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
       protected float _peso;
       protected static bool DeConsumo;

        #region Propiedades

       /// <summary>
       ///Propiedad get Calcula el 33% del precio del producto y lo retorna como  costo de produccion
       /// </summary>
       public override float CalcularCostoDeProduccion
       {
           get { return this.Precio * 0.33f; }
       }

        #endregion
        #region Constructores

       /// <summary>
       /// Inicializa Deconsumo en true
       /// </summary>
         static Galletita()
         {
             DeConsumo = true;   
         }

         /// <summary>
         /// Inicializa los datos del producto
         /// </summary>
         /// <param name="codigoBarra">codigo de Barra</param>
         /// <param name="precio">precio</param>
         /// <param name="marca">marca</param>
         /// <param name="peso">peso</param>
         public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso)
             : base(codigoBarra, marca, precio)
         {
             this._peso = peso;
         }

        #endregion
        #region Metodos

         /// <summary>
         /// Guarda los datos de la galletita(incluidos los de la clase base) en un string,
         /// </summary>
         /// <returns>string</returns>
             private string MostrarGalletita(Galletita g)
             {
                 StringBuilder sb = new StringBuilder();
                 sb.AppendLine(this);
                 sb.AppendLine("PESO: " + this._peso);

                 return sb.ToString();
             }

             /// <summary>
             /// Sobreescritura metodo ToString() para que al llamarlo muestre los datos del galletita
             /// </summary>
             /// <returns></returns>
             public override string ToString()
             {
                 return MostrarGalletita(this);
             }

             /// <summary>
             /// Sobreescribe metodo de la clase base
             /// </summary>
             /// <returns>string</returns>
             public override string Consumir()
             {
                 return "Comestible";
             }

        #endregion
    }
}
