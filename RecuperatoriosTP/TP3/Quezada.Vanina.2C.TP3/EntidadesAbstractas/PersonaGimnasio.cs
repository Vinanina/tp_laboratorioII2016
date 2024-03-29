﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio : Persona
    {
        protected int _identificador;


        public PersonaGimnasio()
        { }

        public PersonaGimnasio(int id,string nombre,string apellido,string dni, ENacionalidad nacionalidad) :base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;

        }

        public override bool Equals(object obj) 
        {
            bool  same = false;
            if (this.GetType().Equals(obj.GetType()))
            {
                same = true;
            }
            return same;
        }

       protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(this._identificador);
           
           return sb.ToString();
       }
        protected abstract string ParticiparEnClase();

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return ((pg1.Equals(pg2) && (pg1.DNI == pg2.DNI)) || (pg1.Equals(pg2) && (pg1._identificador == pg2._identificador))); 
		}
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        { 
            return !(pg1 == pg2);
        }
		
    }
}
