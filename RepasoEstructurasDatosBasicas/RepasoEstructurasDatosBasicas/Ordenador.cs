using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RepasoEstructurasDatosBasicas
{
    public static class Ordenador
    {
        public static void Seleccion<T>(ref List<T> miListaDitto, string campo, int tamañoLista)
        {
            //Variables locales
            dynamic dittoBase = miListaDitto[0];
            dynamic Ditto1;
            dynamic Ditto2;
            PropertyInfo informacionPropiedadDitto = dittoBase.GetType().GetProperty(campo);
            dynamic auxDitto;

            //Variables locales
            int i = 0;
            int j = 0;
            int min = 0;

            //Se ejecuta el algortimo de Seleccion Ascendentemente
            for (i = 0; i < tamañoLista - 1; i++)
            {
                min = i;
                for (j = i + 1; j < tamañoLista; j++)
                {
                    //Se inicializan las variables.
                    Ditto1 = informacionPropiedadDitto.GetValue(miListaDitto[j]);
                    Ditto2 = informacionPropiedadDitto.GetValue(miListaDitto[min]);
                    //Se valida el valor de referencia con otro 
                    //para saber quien es mayor.
                    IComparable comparar = Ditto1 as IComparable;
                    if (comparar.CompareTo(Ditto2) < 0)
                    {
                        min = j;
                    }
                }
                if (i != min)
                {
                    auxDitto = miListaDitto[i];
                    miListaDitto[i] = miListaDitto[min];
                    miListaDitto[min] = auxDitto;
                }
            }
        }

        public static List<T> BusquedaSecuencial<T>(this List<T> miListaDitto, string elementoABuscar, int tamañoLista)
        {
            List<T> considencias = new List<T>();
            dynamic dittoBase = miListaDitto[0];
            PropertyInfo propiedadDitto = dittoBase.GetType().GetProperty("Nombre");
            dynamic ditto1;

            for (int i = 0; i < tamañoLista; i++)
            {
                //dito agarra un nuevo valor
                ditto1 = propiedadDitto.GetValue(miListaDitto[i], null).ToString();

                string elemento = ditto1;
                if (elemento.ToLower().Contains(elementoABuscar.ToLower()))
                {
                    considencias.Add(miListaDitto[i]);
                }
            }
            return considencias;
        }
    }
}
