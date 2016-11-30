using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    [Serializable]
   public sealed class Instructor : PersonaGimnasio
    {
       protected Queue<Gimnasio.EClases> _clasesDelDia;
       protected static Random _random;

        #region Constructores
           static Instructor()
           {
               Instructor._random = new Random();
           }
           public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
               : base(id, nombre, apellido, dni, nacionalidad)
           { 
                this._clasesDelDia = new Queue<Gimnasio.EClases>();

                this._randomClases();
                
           }
        #endregion
        #region Metodos
           protected override string MostrarDatos()
           {
               StringBuilder sb = new StringBuilder();
               sb.AppendLine(base.ToString());
               sb.AppendLine(this.ParticiparEnClase());

               return sb.ToString();

           }
           public override string ToString()
           {
               return this.MostrarDatos();
           }
           protected override string ParticiparEnClase()
           {
               StringBuilder sb = new StringBuilder();
               sb.AppendLine("CLASE DEL DIA: " );
               foreach (Gimnasio.EClases item in this._clasesDelDia)
               {
                  sb.AppendLine(item.ToString());
               }
               return sb.ToString();
           }

           private void _randomClases()
           {
               this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 2));
               this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(0, 2));
           }

        #endregion
        #region Sobrecargas

               public static bool operator ==(Instructor i, Gimnasio.EClases clase)
               {
                   foreach (Gimnasio.EClases item in i._clasesDelDia)
                   {
                       if (item == clase)
                           return true;
                   }

                   return false;
       
               }

               public static bool operator !=(Instructor i, Gimnasio.EClases clase)
               {
                   return !(i == clase);
               }
        #endregion
    }
}
