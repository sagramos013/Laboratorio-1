using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoEstructurasDatosBasicas
{
    public partial class Form1 : Form
    {
        List<Cancion> misCanciones;

        public Form1()
        {
            InitializeComponent();
            llenarLista();        
        }

        private void llenarLista()
        {
            misCanciones = new List<Cancion>();
            string[] auxc = new string[10];
            auxc[0] = "Bomborom";
            auxc[1] = "Cañon";
            auxc[2] = "Loca";
            auxc[3] = "Gordita";
            auxc[4] = "Fuego Fuego";
            auxc[5] = "Mi peor vicio";
            auxc[6] = "Un millon de cicatrices";
            auxc[7] = "Amor con hielo";
            auxc[8] = "Loca";
            auxc[9] = "Bomborom";

            int posicion = 0;
            double duracion = 0;
            Random ran = new Random();

            for (int i = 0; i < 100; i++)
            {
                posicion = i / 10;
                posicion = posicion * 10;
                posicion = i - posicion;
                duracion = ran.NextDouble() + ran.Next(3, 5);
                misCanciones.Add(new Cancion(auxc[posicion] + " " + (posicion + 1), duracion));
            }
        }


    }
}
