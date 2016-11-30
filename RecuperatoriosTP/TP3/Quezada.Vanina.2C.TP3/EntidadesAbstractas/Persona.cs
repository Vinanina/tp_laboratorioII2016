using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;
using Archivos;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {

        protected string _nombre;
        protected string _apellido;
        protected ENacionalidad _nacionalidad;
        protected int _dni;

        public enum ENacionalidad 
        {
            Argentino,
            Extranjero
        }

        #region Propiedades
        public string Apellido
        {
            set { this._apellido = this.ValidarNombreApellido(value); }
            get { return this._apellido; }
        }
        public int DNI
        {
            set { this._dni = value; }
            get { return this._dni; }
        }
        public string Nombre
        {
            set { this._nombre = this.ValidarNombreApellido(value); }
            get { return this._nombre; }
        }
        public string StringToDNI
        {
            set { this._dni = ValidarDNI(this.Nacionalidad,value); }
        }
        public ENacionalidad Nacionalidad
        {
            set { this._nacionalidad = value; }
            get { return this._nacionalidad; }
        }
        #endregion

        #region Constructores
        public Persona()
            {}
        public Persona(string nombre,string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre= nombre;
            this.Nacionalidad = nacionalidad;
        
        
        }
        public Persona(string nombre,string apellido,int dni, ENacionalidad nacionalidad):this (nombre,apellido,nacionalidad )
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
            {
                this.StringToDNI = dni;
        }
        #endregion
        #region Metodos y sobrecargas de Metodos
		public override string ToString()
		{
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " +this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);
           // sb.Append(this._dni);
            return sb.ToString();

        }
		private int ValidarDNI(ENacionalidad nacionalidad,int dato)
		{
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato >= 89999999))
                 throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");

            else if (nacionalidad == ENacionalidad.Extranjero && dato < 89999999)
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");

             else  
                return dato;  
         }
  
		private int ValidarDNI(ENacionalidad nacionalidad,string dato)
		{
            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return this.ValidarDNI(nacionalidad, numeroDni);
        }

		private string ValidarNombreApellido(string dato)
		{
            Regex regex = new Regex(@"[a-zA-Z]*");
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        
        }

        #endregion


    }
}
