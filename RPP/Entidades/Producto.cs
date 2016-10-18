using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
            protected int _codigoBarra;
            protected EMarcaProducto _marca;
            protected float _precio;
            
        #region Enumerados

        /// <summary>
        /// Enumerado de Marcas de los productos
        /// </summary>
            public enum EMarcaProducto
                {
                    Manaos,
                    Pitusas,
                    Naranjú,
                    Diversión,
                    Favorita,
                    Swift
                }
        /// <summary>
        /// Enum de tipos de productos 
        /// </summary>
            public enum ETipoProducto
                {
                    Galletita,
                    Gaseosa,
                    Jugo,
                    Harina,
                    Todos
                }
       #endregion

       #region Propiedades
        /// <summary>
        /// Retorna la marca del producto
        /// </summary>
            public EMarcaProducto Marca
            {
                get { return this._marca; }
            }

        /// <summary>
        /// Retorna el precio del producto
        /// </summary>
            public float Precio
            {
                get { return this._precio; }
            }

            public abstract float CalcularCostoDeProduccion
            {
                get;
            }

        #endregion
        #region Constructores

        /// <summary>
        /// Inicializa el producto con codigo de barras, marca y precio
        /// </summary>
            /// <param name="codigoBarra">Codigo de Barras del producto</param>
            /// <param name="marca">Marca del producto</param>
            /// <param name="precio">Precio del producto</param>
            public Producto(int codigoBarra, EMarcaProducto marca, float precio)
            {
                this._marca = marca;
                this._precio = precio;
                this._codigoBarra = codigoBarra;
            }

         #endregion
         #region Metodos

        /// <summary>
        /// Guarda la marca, cod de barras y precio del producto en un objeto  stringbuilder 
        /// </summary>
        /// <param name="prod">Producto</param>
        /// <returns>String generado a partir del stringbulder con los datos del producto</returns>
            private string MostrarProducto(Producto prod)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("MARCA: " + this._marca);
                sb.AppendLine("CÓDIGO DE BARRAS: "+ this._codigoBarra);
                sb.Append("PRECIO : " +  this._precio);

                return sb.ToString();
            }


        /// <summary>
        /// Retorna texto a ser modificado por las clases hijas
        /// </summary>
        /// <returns>string</returns>
            public virtual string Consumir()
            { 
                return "Parte de una mezcla.";
            }

        /// <summary>
        /// Sobreescritura metodo Equals(). Compara los tipos de dos productos
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns> bool</returns>
            public override bool Equals(object obj)
            {
               
                return this.GetType().Equals(obj.GetType());

               // return this.GetType().Name.ToString().Equals(obj.GetType().Name.ToString());
            }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara la marca de un Producto con un tipo de marca 
        /// </summary>
        /// <param name="prodUno">Producto</param>
        /// <param name="marca">Marca</param>
        /// <returns>bool, true el producto es de la misma marca, false si las marcas son diferentes</returns>
        public static bool operator ==(Producto prodUno, EMarcaProducto marca)
        {
            return prodUno._marca.Equals(marca);
        }
        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }
        /// <summary>
        /// Compara si dos Productos tienen la misma marca, cod. barras y si son del mismo tipo
        /// </summary>
        /// <param name="prodUno">Producto 1</param>
        /// <param name="prodDos">Producto 2</param>
        /// <returns>bool, true si tiene la misma marca, cod. barras y si son del mismo tipo, si son diferentes retorna false </returns>
        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            if (prodUno.Equals(prodDos) && prodUno == prodDos._marca && prodUno._codigoBarra.Equals(prodDos._codigoBarra))
           {
                return true;
           }
            return false;
         }

        /// <summary>
        /// Compara si dos Productos tienen la misma marca, cod. barras y si son del mismo tipo
        /// </summary>
        /// <param name="prodUno">Producto 1</param>
        /// <param name="prodDos">Producto 2</param>
        /// <returns>bool, false si tiene la misma marca, cod. barras y si son del mismo tipo, true si son diferentes </returns>
        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }
        
        /// <summary>
        /// Retorna el codigo de barras de un producto 
        /// </summary>
        /// <param name="prod">Producto</param>
        /// <returns>int</returns>
        public static explicit operator int(Producto prod)
        {
            return prod._codigoBarra;
        }

        /// <summary>
        /// llama al metodo MostrarProducto() que devuelve string con los datos del producto
        /// </summary>
        /// <param name="prod">Producto</param>
        /// <returns>string</returns>
        public static implicit operator string(Producto prod)
        {
            return prod.MostrarProducto(prod);
        }

        #endregion
    }
}
