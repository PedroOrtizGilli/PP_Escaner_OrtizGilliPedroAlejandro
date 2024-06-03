using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Esta clase se ocupa de recorrer la lista de documentos de los escaners para saber cuantos documentos hay
    /// y en que etapa estan, segun si son mapa o libro, devolviendo su respectiva extension.
    /// Cm cuadrados para los mapas y cantidad de paginas para libros.
    /// Ademas un resumen de los datos dentro.
    /// </summary>
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(escaner, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }
        public static void MostrarEnEscaner(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(escaner, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }
        public static void MostrarEnRevision(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(escaner, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }
        public static void MostrarTerminados(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(escaner, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
        /*
        Devuelve la cantidad de documentos segun el paso en el que estan.
        */
        private static void MostrarDocumentosPorEstado(Escaner escaner, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            List<Documento> listaDistribuidos = new List<Documento>();

            // Extension: el total de paginas en el caso de los libros y el total de cm2 en el caso de los
            // mapas.
            foreach (Documento doc in escaner.GetListaDocumentos)
            {
                if (doc.GetEstado == estado)
                {
                    if (doc is Libro)
                    {
                        Libro libro = (Libro)doc;
                        extension += libro.GetNumPaginas;
                    }
                    else
                    {
                        if (doc is Mapa mapa)
                        {
                            //Mapa mapa = (Mapa)doc;
                            extension += mapa.GetSuperficie;
                        }
                    }
                    cantidad++;
                    listaDistribuidos.Add(doc);
                    resumen += doc.ToString();
                }
            }

            if (listaDistribuidos.Count == 0)
            {
                resumen = "";
            }
        }
    }
}
