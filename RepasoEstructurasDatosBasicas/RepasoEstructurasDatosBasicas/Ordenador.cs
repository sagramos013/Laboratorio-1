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
        public static string Seleccion<Ditto>(ref List<Ditto> miListaDitto, string campo, bool EsAscendente, int n)
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
            int Intercambios = 0;
            int Comparacion = 0;

            //Se ejecuta el algortimo de Seleccion Ascendentemente
            if (EsAscendente)
            {
                for (i = 0; i < n - 1; i++)
                {
                    min = i;
                    for (j = i + 1; j < n; j++)
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
                        Intercambios++;
                    }
                    Comparacion++;
                }
            }
            else
            {
                for (i = 0; i < n - 1; i++)
                {
                    min = i;
                    for (j = i + 1; j < n; j++)
                    {
                        //Se inicializan las variables.
                        Ditto1 = informacionPropiedadDitto.GetValue(miListaDitto[j]);
                        Ditto2 = informacionPropiedadDitto.GetValue(miListaDitto[min]);

                        //Se valida el valor de referencia con otro 
                        //para saber quien es mayor.
                        IComparable comparar = Ditto1 as IComparable;
                        if (comparar.CompareTo(Ditto2) > 0)
                        {
                            min = j;
                        }
                    }
                    if (i != min)
                    {
                        auxDitto = miListaDitto[i];
                        miListaDitto[i] = miListaDitto[min];
                        miListaDitto[min] = auxDitto;
                        Intercambios++;
                    }
                    Comparacion++;
                }
            }
            return (Intercambios.ToString() + "," + Comparacion.ToString());
        }

        public static List<Ditto> BusquedaSecuencial<Ditto>(this List<Ditto> miListaDitto, string campoABuscar, string elementoABuscar, int inicio, int fin, ref int Comparaciones)
        {
            List<Ditto> considencias = new List<Ditto>();
            dynamic dittoBase = miListaDitto[0];
            PropertyInfo propiedadDitto = dittoBase.GetType().GetProperty(campoABuscar);
            dynamic ditto1;

            for (int i = 0; i < fin; i++)
            {
                //dito agarra un nuevo valor
                ditto1 = propiedadDitto.GetValue(miListaDitto[i], null).ToString();

                string elsplit = ditto1;
                string[] sp = elsplit.Split(' ');
                ///******************************************
                ///en esta parte se hace la comparacion 
                ///************Comparaciones++
                for (int j = 0; j < sp.Length; j++)
                {
                    //se verifica si ya encontro el elemento deseado
                    if (considencias.Count <= 0)
                    {
                        Comparaciones++;
                    }
                    //se valida que sea el elemento desado
                    if (sp[j].ToLower().Contains(elementoABuscar.ToLower()))
                    {
                        considencias.Add(miListaDitto[i]);
                    }
                }

            }
            return considencias;
        }
    }
}
