using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        protected Gimnasio.EClases _claseQueToma;
        protected EEstadoCuenta _estadoCuenta;

        #region Enum EEstadoCuenta
        public enum EEstadoCuenta
        { 
            MesPrueba,
            AlDia,
            Deudor
        }
        #endregion

        public Alumno(int id,string nombre, string apellido,string dni, ENacionalidad nacionalidad,Gimnasio.EClases claseQueToma): base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id,string nombre, string apellido,string dni, ENacionalidad nacionalidad,Gimnasio.EClases claseQueToma,EEstadoCuenta estadoCuenta): base(id,nombre, apellido, dni, nacionalidad)
       {
                    this._claseQueToma = claseQueToma;
                    this._estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("CARNET NúMERO: " + this._identificador);
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());

            return sb.ToString();
        }
         public override string ToString()
		{
            return this.MostrarDatos();
         }
         protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }
        public static bool operator == (Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;

            return false;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return !(a == clase);
        }
    }
}
