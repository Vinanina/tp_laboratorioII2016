using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
       protected string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try{
                using (StreamWriter writer = new StreamWriter(this.archivo))
                {
                    writer.WriteLine(datos);
                }

                return true;
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool leer(out List<string> datos)
        {
            try {

                using (StreamReader reader = new StreamReader(this.archivo))
                    {
                        List<string> lineas = new List<string>();

                        while (!(reader.ReadLine() == null))
                        {
                            lineas.Add(reader.ReadLine());
                        }

                        datos = lineas;
                    }
                        return true;
               }
            catch(Exception e)
            {
                  throw new Exception(e.Message);
            }
        }
    }
}
