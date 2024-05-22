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
            MostrarDocumentosPorEstado(escaner, Documento.Paso.Distribuido,out extension,out cantidad,out resumen);
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
            StringBuilder datos = new StringBuilder();
            foreach (Documento doc in escaner.GetListaDocumentos)
            {
                if (estado == Documento.Paso.Inicio)
                {
                    if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie;
                            datos.AppendLine(mapa.ToString());
                        }
                    }
                    else
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas;
                            datos.AppendLine(libro.ToString());
                        }
                    }
                }
                else if (estado == Documento.Paso.Distribuido)
                {
                    if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie;
                            datos.AppendLine(mapa.ToString());
                        }
                    }
                    else
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas;
                            datos.AppendLine(libro.ToString());
                        }
                    }
                }
                else if (estado == Documento.Paso.EnEscaner)
                {
                    if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie;
                            datos.AppendLine(mapa.ToString());
                        }
                    }
                    else
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas;
                            datos.AppendLine(libro.ToString());
                        }
                    }
                }
                else if (estado == Documento.Paso.EnRevision)
                {
                    if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie;
                            datos.AppendLine(mapa.ToString());
                        }
                    }
                    else
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas;
                            datos.AppendLine(libro.ToString());
                        }
                    }
                }
                else if (estado == Documento.Paso.Terminado)
                {
                    if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie;
                            datos.AppendLine(mapa.ToString());
                        }
                    }
                    else
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas;
                            datos.AppendLine(libro.ToString());
                        }
                    }
                }
            }
            resumen += datos;
        }
    }
}
