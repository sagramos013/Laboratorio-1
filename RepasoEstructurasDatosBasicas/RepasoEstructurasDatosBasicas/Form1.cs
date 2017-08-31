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
    public partial class Form1 : System.Windows.Forms.Form
    {
        List<Cancion> misCanciones;
        List<Cancion> listAux;
        int tamañoLista = 100;
        public Form1()
        {
            InitializeComponent();
            llenarLista();
            mostrarLista(misCanciones);
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
            auxc[9] = "God Rap";

            int posicion = 0;
            double duracion = 0;
            int categoria = 0;
            Random ran = new Random();

            for (int i = 0; i < tamañoLista; i++)
            {
                posicion = i / 10;
                posicion = posicion * 10;
                posicion = i - posicion;
                duracion = ran.NextDouble() + ran.Next(3, 5);
                categoria = (i / 10) + 1;
                misCanciones.Add(new Cancion(auxc[posicion] + " " + categoria, duracion));
            }
            listAux = misCanciones;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = comboBox1.SelectedIndex;
            switch (selected)
            {
                case 0:
                    {
                        Ordenador.Seleccion<Cancion>(ref listAux, "Nombre", listAux.Count);
                    } break;
                case 1:
                    {
                        Ordenador.Seleccion(ref listAux, "Duracion", listAux.Count);
                    } break;                   
            }
            mostrarLista(listAux);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox1.Clear();
            listAux = misCanciones;
            mostrarLista(listAux);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listAux = Ordenador.BusquedaSecuencial(misCanciones, textBox1.Text, misCanciones.Count);
            if (listAux.Count == 0)
            {
                MessageBox.Show("La canción buscada no existe.");
            }
            if (listAux.Exists(x => x.Nombre.Equals(textBox1.Text)))
            {
                Cancion bus = listAux.Find(x => x.Nombre.Equals(textBox1.Text));
                listAux.Clear();
                listAux.Add(bus);
            }
            else label2.Visible = true;
            mostrarLista(listAux);
        }

        private void mostrarLista(List<Cancion> lista)
        {
            dataGridView1.Rows.Clear();
            
            DataGridViewTextBoxColumn canciones = new DataGridViewTextBoxColumn();
            canciones.Width = 350;
            canciones.HeaderText = "Canción";
            dataGridView1.Columns.Add(canciones);

            DataGridViewTextBoxColumn duracion = new DataGridViewTextBoxColumn();
            duracion.Width = 70;
            duracion.HeaderText = "Duración";
            dataGridView1.Columns.Add(duracion);

            dataGridView1.Rows.Add(lista.Count);

            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = lista[i].Nombre;
                dataGridView1.Rows[i].Cells[1].Value = lista[i].Duracion;
            }
        }

    }
}
