using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
           protected float _litros;
           protected static bool DeConsumo;

        #region Propiedades

           /// <summary>
           ///Propiedad get Calcula el 42% del precio del producto y lo retorna como  costo de produccion
           /// </summary>
           public override float CalcularCostoDeProduccion
           {
               get { return this.Precio * 0.42f; }
           }

        #endregion
        #region Constructores
           /// <summary>
           /// Inicializa Deconsumo en true
           /// </summary>
             static Gaseosa()
            {
                    DeConsumo = true;  
             }

           /// <summary>
           /// Inicializa los datos del producto
           /// </summary>
           /// <param name="codigoBarra">codigo de Barra</param>
           /// <param name="precio">precio</param>
           /// <param name="marca">marca</param>
           /// <param name="litros">litros</param>
           /// 
             public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros)
                 : base(codigoBarra, marca, precio)
             {
                 this._litros = litros;
             }

        /// <summary>
        /// Incializa una gaseosa recibiendo un objeto Producto y llamando a la sobrecarga del constructor
        /// </summary>
        /// <param name="p">Producto</param>
        /// <param name="litros">litros</param>
             public Gaseosa(Producto p, float litros)
                 : this((int)p, p.Precio, p.Marca, litros)
             { }

        #endregion
        #region Metodos

             /// <summary>
             /// Inicializa Deconsumo en true
             /// </summary>
             public override string Consumir()
             {
                 return "Bebible" ; 
             }

             /// <summary>
             /// Guarda los datos de la gaseosa(incluidos los de la clase base) en un string,
             /// </summary>
             /// <returns>string</returns>
             private string MostrarGaseosa()
             {
                 StringBuilder sb = new StringBuilder();
                 sb.AppendLine(this);
                 sb.AppendLine("LITROS: " + this._litros);

                 return sb.ToString();
             }

             /// <summary>
             /// Sobreescritura metodo ToString() para que al llamarlo muestre los datos de la gaseosa
             /// </summary>
             /// <returns></returns>
             public override string ToString()
             {
                 return this.MostrarGaseosa();
             }

        #endregion
    }
}
