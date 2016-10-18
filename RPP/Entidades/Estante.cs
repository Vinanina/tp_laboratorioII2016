using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
   public class Estante
    {
           protected sbyte _capacidad;
           protected List<Producto> _productos;

        #region Propiedades

       /// <summary>
           /// Retorna el valor total del estante que optiene de la llamada al metodo GetValorEstante()
       /// </summary>
           public float ValorEstanteTotal
           { 
                get{ return this.GetValorEstante();}
           }
        #endregion
          
        #region Constructores
       /// <summary>
       /// Constructor que inicializa la lista de Productos
       /// </summary>
           private Estante()
           {
               _productos = new List<Producto>();
           }
       /// <summary>
       /// Constructor que inicializa la capacidad del estante y llama al constructor que inicializa la  lista de productos
       /// </summary>
       /// <param name="capacidad">Capacidad de productos que guarda el estante</param>
           public Estante(sbyte capacidad):this()
           {
              this._capacidad= capacidad;
           }
        #endregion

        #region Metodos
       /// <summary>
       /// Retorna la lista de productos del objeto
       /// </summary>
      /// <returns>lista de productos</returns>
           public List<Producto> GetProductos()
           {
               return this._productos;
           }

           /// <summary>
           /// Sobrecarga del metodo GetValorEstante(), al cual llama con el enum Todos como parametro. 
           /// </summary>
           /// <returns> Suma total de los precios de los productos</returns>
           private float GetValorEstante()
           {
               return GetValorEstante(Producto.ETipoProducto.Todos);
           }


           /// <summary>
           /// Sobrecarga del metodo GetValorEstante(), Suma los precios del producto que reciba como parametro. 
           /// </summary>
           /// <returns> Suma de los precios de los productos que le envien como parametro</returns>
           public float GetValorEstante(Producto.ETipoProducto tipo)
           {
               float sum = 0;
               foreach (Producto p in this._productos)
               {
                   if (p.GetType().Name.ToString() == tipo.ToString() || tipo == Producto.ETipoProducto.Todos)
                   {
                       sum += p.Precio;
                      // sum += p.CalcularCostoDeProduccion;
                   }
                   
               }

               return sum;
           }

       /// <summary>
       /// Guarda en en un strinbuilder los datos los productos del Estante y los retorna.  
       /// </summary>
       /// <param name="e"></param>
       /// <returns>String con los datos del producto</returns>
            public static string MostrarEstante(Estante e)
            {
                StringBuilder sb = new StringBuilder();
                 sb.AppendLine("CAPACIDAD: " + e._capacidad);

                foreach (Producto p in e._productos)
                {
                    sb.AppendLine(p.ToString());
                }

                return sb.ToString();
            }

        #endregion
        #region Sobrecarga

       /// <summary>
       /// Revisa si un producto en especifico esta en la lista de productos de un estante
       /// </summary>
       /// <param name="e">Estante</param>
       /// <param name="prod">Producto </param>
       /// <returns>true si el producto esta esta en el estante, false si no lo encuentra</returns>
            public static bool operator ==(Estante e,Producto prod)
            {
                foreach (Producto p in e._productos)
                {
                    if(p == prod)
                    {
                        return true;
                    }
                }
                return false;
            }

       /// <summary>
            /// Revisa si un producto no esta en la lista de productos de un estante. Llama a la sobrecarga ==(Estante e,Producto prod)
        /// </summary>
            /// <param name="e">Estante</param>
            /// <param name="prod">Producto</param>
            /// <returns>true si el producto no esta en el estante , false si lo encuentra</returns>
            public static bool operator !=(Estante e,Producto prod)
            {
                return !(e == prod);
            }

       /// <summary>
       /// Revisa que el estante tenga capacida para almacenar un producto, si tiene capacidad agrega el producto pasado por parametro al Estante
       /// </summary>
       /// <param name="e">Estante</param>
       /// <param name="prod">Producto</param>
            /// <returns>true si el estante posee capacidad de almacenar algun producto, false sino tiene capacidad</returns>
            public static bool operator +(Estante e, Producto prod)
            {
                if ((e._productos.Count < e._capacidad && e != prod))
                {
                    e._productos.Add(prod);

                    return true;
                }
                return false;
                
             }
       /// <summary>
       /// Si el producto este en el Estante lo remueve y retorna el estante sin el producto
       /// </summary>
       /// <param name="e">Estante</param>
       /// <param name="prod">Producto</param>
       /// <returns>un objeto Estante</returns>
             public static Estante operator -(Estante e,Producto prod)
            {
                if (e == prod)
                {
                    e._productos.Remove(prod);
                }

                return e;
             }

       /// <summary>
       /// Remueve del Estante todos los productos que sean del mismo tipo del parametro recibido.
       /// </summary>
       /// <param name="e">Estante</param>
       /// <param name="tipo">Tipo de producto</param>
       /// <returns>Retorna el Estante con o sin productos removidos</returns>
             public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
            {
                for (int i = 0; i < e._productos.Count; i++)
                {   // if (e._productos[i].Equals(tipo))

                    if (e._productos[i].GetType().Name.ToString() == tipo.ToString() || tipo == Producto.ETipoProducto.Todos)
                    {
                        e -= e._productos[i];
                        i -= 1;
                    }
                }
                return e;
              }
        #endregion

    }
}
