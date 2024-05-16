using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        /*
        
        */
        public static void MostrarDistribuidos(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            foreach (Documento doc in escaner.GetListaDocumentos)
            {
                if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                {
                    if (doc.GetEstado == Documento.Paso.Distribuido)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie; // Valor devuelto en cm cuadrados
                            resumen += doc.GetTitulo;
                        }
                    }
                }
                else
                {
                    if (doc.GetEstado == Documento.Paso.Distribuido)
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas; // Valor devuelto en cantidad de paginas 
                            resumen += doc.GetTitulo;  
                        }
                    }
                }
            }
        }
        public static void MostrarEnEscaner(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            foreach (Documento doc in escaner.GetListaDocumentos)
            {
                if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                {
                    if (doc.GetEstado == Documento.Paso.EnEscaner)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie; // Valor devuelto en cm cuadrados
                            resumen += doc.GetTitulo;
                        }
                    }
                }
                else
                {
                    if (doc.GetEstado == Documento.Paso.EnEscaner)
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas; // Valor devuelto en cantidad de paginas 
                            resumen += doc.GetTitulo;
                        }
                    }
                }
            }
        }
        public static void MostrarEnRevision(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            foreach (Documento doc in escaner.GetListaDocumentos)
            {
                if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                {
                    if (doc.GetEstado == Documento.Paso.EnRevision)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie; // Valor devuelto en cm cuadrados
                            resumen += doc.GetTitulo;
                        }
                    }
                }
                else
                {
                    if (doc.GetEstado == Documento.Paso.EnRevision)
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas; // Valor devuelto en cantidad de paginas 
                            resumen += doc.GetTitulo;
                        }
                    }
                }
            }
        }
        public static void MostrarTerminados(Escaner escaner, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            foreach (Documento doc in escaner.GetListaDocumentos)
            {
                if (escaner.GetTipoDocumento == Escaner.TipoDoc.mapa)
                {
                    if (doc.GetEstado == Documento.Paso.Terminado)
                    {
                        if (doc is Mapa mapa)
                        {
                            cantidad++;
                            extension += mapa.GetSuperficie; // Valor devuelto en cm cuadrados
                            resumen += doc.GetTitulo;
                        }
                    }
                }
                else
                {
                    if (doc.GetEstado == Documento.Paso.Terminado)
                    {
                        if (doc is Libro libro)
                        {
                            cantidad++;
                            extension += libro.GetNumPaginas; // Valor devuelto en cantidad de paginas 
                            resumen += doc.GetTitulo;
                        }
                    }
                }
            }
        }
        private static void MostrarDocumentosPorEstado(Escaner escaner, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            if (estado == Documento.Paso.Distribuido)
            {
                MostrarDistribuidos(escaner,out extension,out cantidad,out resumen);
            }
            else if (estado == Documento.Paso.EnEscaner)
            {
                MostrarEnEscaner(escaner, out extension, out cantidad, out resumen);
            }
            else if (estado == Documento.Paso.EnRevision)
            {
                MostrarEnRevision(escaner, out extension, out cantidad, out resumen);
            }
            else if (estado == Documento.Paso.Terminado)
            {
                MostrarTerminados(escaner, out extension, out cantidad, out resumen);
            }
        }
    }
}
