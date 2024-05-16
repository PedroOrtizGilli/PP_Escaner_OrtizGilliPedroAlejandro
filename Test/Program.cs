﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantidadDocumentos;
            int extensionDocumento;
            string resumen;

            Libro libro1 = new Libro("Dune", "Herbert, Frank", 1956, "1111", "000000", 784);
            Mapa mapa1 = new Mapa("America", "Colon, Cristobal", 1400, "000001", 100, 50);

            Escaner escanerMapas = new Escaner("Sony", Escaner.TipoDoc.mapa);
            Escaner escanerLibros = new Escaner("Samsung", Escaner.TipoDoc.libro);

            bool agregarDocumento = escanerLibros + libro1;
            bool agregarOtroDocumento = escanerMapas + mapa1;

            Informes.MostrarDistribuidos(escanerMapas,out extensionDocumento,out cantidadDocumentos,out resumen);
            Console.WriteLine($"Escaner Mapas:\n\tCantidad: {cantidadDocumentos}\n" +
                              $"\tExtension: {extensionDocumento}\n" +
                              $"\tResumen: {resumen}");
            Console.ReadKey();
        }
    }
}