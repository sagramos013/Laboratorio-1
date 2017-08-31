using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoEstructurasDatosBasicas
{
    public class Cancion
    {
        public Cancion(string name, double duracion)
        {
            this.name = name;
            this.duracion = duracion;
        }

        string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        double duracion;
        public double Duracion
        {
            set { duracion = value; }
            get { return Math.Round(duracion, 2); }
        }

        
    }
}
