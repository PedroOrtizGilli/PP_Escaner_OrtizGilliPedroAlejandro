using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Documento
    {
        //Atributos:
        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        int anio;
        string autor;
        string barcode;
        string numNormalizado;
        string titulo;
        Paso estado = Paso.Inicio;

        // Propiedades:
        public int GetAnio
        {
            get => this.anio;
        }
        public string GetAutor
        {
            get => this.autor;
        }
        public string GetBarcode
        {
            get => this.barcode;
        }
        public Paso GetEstado
        {
            get => this.estado;
        }
        protected string GetNumNormalizado
        {
            get => this.numNormalizado;
        }
        public string GetTitulo
        {
            get => this.titulo;
        }

        // Constructor:
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
        }

        /*
        Chequea el estado del documento, 
        si esta Terminado devuelve false,
        si no esta Terminado, avanza el estado al proximo y devuelve un true.
        */
        public bool AvanzarEstado()
        {
            if (this.estado == Paso.Terminado)
            {
                return false;
            }
            else
            {
                this.estado += 1;
                return true;
            }
        }

        /*
        Con StringBuilder creo la cadena de datos que muestro en consola.
        */
        public virtual string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"Título: {this.titulo}");
            datos.AppendLine($"Autor: {this.autor}");
            datos.AppendLine($"Año: {this.anio}");
            return datos.ToString();
        }
    }
}
