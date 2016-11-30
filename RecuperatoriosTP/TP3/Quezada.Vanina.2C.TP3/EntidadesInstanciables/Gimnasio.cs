using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
namespace EntidadesInstanciables
{
    [Serializable]
    public class Gimnasio
    {

        protected List<Alumno> _alumnos;
        protected List<Instructor> _intructor;
        protected List<Jornada> _jornada; 

       public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }

       public List<Alumno> alumnos
       {
           get  { return this._alumnos; }
       }

       public List<Instructor> Instructores
       {
           get { return this._intructor; }

       }
 
       public List<Jornada> Jornada
       {
           get {return this._jornada;}
       }

       public Jornada this[int index]
       {
           get
           {
               if (index < this._jornada.Count || index > this._jornada.Count)
                   return this._jornada[index];
               else
                   return null;
           }
       }


       #region Constructores
           public Gimnasio()
           { 
                this._alumnos= new List<Alumno>();
                this._intructor = new List<Instructor>();
                this._jornada = new  List<Jornada>(); 
           }

       #endregion

       #region Metodos
           public static bool Guardar(Gimnasio gim)
           {
               try
               {
                   Xml<Gimnasio> guardar = new Xml<Gimnasio>();

                   string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\gimnasio.xml";

                   return guardar.Guardar(archivo, gim);
               }
               catch (Exception e)
               {
                   throw new ArchivosException(e);
                  
               }
           }
           public static bool Leer(Gimnasio gim)
           {
              try{
                   Xml<Gimnasio> leer = new Xml<Gimnasio>();
                   string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\gimnasio.xml";
                   Gimnasio datos;
                   bool s = leer.Leer(archivo, out datos); 
                   Console.WriteLine(datos);
                   return s;
                              }
               catch (Exception e)
               {
                   throw new ArchivosException(e);
                  
               }
           }
           private static string MostrarDatos(Gimnasio gim)
           {
               StringBuilder sb = new StringBuilder();
               sb.AppendLine("JORNADA: ");
               foreach (Jornada j in gim.Jornada)
               {
                   sb.Append(j.ToString());
                   sb.AppendLine("<-------------------------------------------->");
               }
               
               return sb.ToString();

           }
           public override string ToString()
           {
               return MostrarDatos(this);
           }
       #endregion
       #region Sobrecargas
           public static bool operator ==( Gimnasio g, Alumno a)
           { 
                foreach(Alumno alumno in g._alumnos)
                {
                    if(alumno == a)
                        return true;
                }
               return false;
           }
           public static bool operator !=(Gimnasio g, Alumno a)
           {
               return !(g == a);
           }
           public static Instructor operator ==(Gimnasio g, EClases clase)
           {
               foreach (Instructor i in g._intructor)
               {
                   if (i == clase)
                       return i;
               }
               throw new Excepciones.SinInstructorException("No hay instrucctor para la clase");
                
           }
           public static Instructor operator !=(Gimnasio g, EClases clase)
           {
               try
               {
                   foreach (Instructor i in g._intructor)
                   {
                       if (i != clase)
                           return i;
                   }
               }
               catch (Exception e)
               {
                   throw new Excepciones.SinInstructorException("No hay instrucctor para la clase");
               }
               throw new Excepciones.SinInstructorException("No hay instrucctor para la clase");
           }
           public static bool operator ==(Gimnasio g, Instructor i)
           {
               foreach (Instructor inst in g._intructor)
               {
                   if (inst == i)
                       return true;
               }
               return false;
           
           }
           public static bool operator !=(Gimnasio g, Instructor i)
           {
                return !(g == i);
           }
           public static Gimnasio operator +(Gimnasio g, Alumno a)
           {
               if (g == a)
                   throw new AlumnoRepetidoException("Alumno repetido");
               else
                   g._alumnos.Add(a);

               return g;
                
           }
           public static Gimnasio operator +(Gimnasio g, EClases clase)
           {
               Jornada j = new Jornada(clase, g == clase);

               foreach (Alumno a in g._alumnos)
               {
                   if (a == clase)
                       j += a;
               }
               g._jornada.Add(j);
               return g;
           }
           public static Gimnasio operator +(Gimnasio g, Instructor i)
           {
               if (g._intructor == null || g != i)
                   g._intructor.Add(i);
               return g;
           }
       #endregion
    }
}
