using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    [Serializable]
   public class Jornada
    {
        protected List<Alumno> _alumnos;
        protected Gimnasio.EClases _clase;
        protected Instructor _instructor;

        #region Propiedades
            public Jornada this[int i]
            {
                get
                {
                    if (i >= 0 && i < this._alumnos.Count)
                        return this[i];
                    else
                        return null;
                }
            }
        #endregion

        #region Constructores
        public Jornada()
        {
           _alumnos= new List<Alumno>();
        }
        public Jornada(Gimnasio.EClases clase, Instructor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Sobrecargas Operadores


        public static bool operator ==(Jornada j,Alumno a)
        {
           
           if(j._alumnos != null)
           {
                foreach (Alumno item in j._alumnos)
                {
                    if (item == a)
                    return true;
                }
           }
            return false;
        }

        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j==a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a )
                j._alumnos.Add(a);

            return j;
        }
        #endregion
       #region Metodos
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            

            sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            //sb.AppendLine(.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
                    
            }
            return sb.ToString();
        }
        public static bool Guardar(Jornada jornada)
        {
           try{
                Texto t = new Archivos.Texto();

                return t.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\jornada.txt", jornada.ToString());
            } catch (Exception e)
               {
                   throw new ArchivosException(e);
                  
               }        
        }
        public static bool Leer(Jornada jornada)
        {
            try{ 
                Texto t = new Archivos.Texto();
                string datos;
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\jornada.txt";
                bool s = t.Leer(archivo, out datos);;
                Console.WriteLine(datos);
                return s;
          }catch (Exception e)
               {
                   throw new ArchivosException(e);
                  
               }
        }
       #endregion

    }
}
