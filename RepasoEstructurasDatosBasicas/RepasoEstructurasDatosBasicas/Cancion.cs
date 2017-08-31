using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoEstructurasDatosBasicas
{
    public class Cancion
    {
        public Cancion(string nombre, double duracion)
        {
            this.nombre = nombre;
            this.duracion = duracion;
        }

        string nombre;
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        double duracion;
        public double Duracion
        {
            set { duracion = value; }
            get { return Math.Round(duracion, 2); }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Cancion other = obj as Cancion;
            if (other == null) return false;
            else return this.nombre.Equals(other.nombre);
        }
    }
}
