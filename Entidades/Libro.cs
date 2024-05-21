using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        // Atributos:
        int numPaginas;

        // Constructor:
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        // Propiedades:
        public int GetNumPaginas
        {
            get => this.numPaginas;
        }
        public string GetISBN
        {
            get => this.GetNumNormalizado;
        }

        /* 
        Sobrecargas:
        Primera: Igualacion. Segunda: Diferencia.
        */
        public static bool operator ==(Libro libro1, Libro libro2)
        {
            return ((libro1.GetBarcode == libro2.GetBarcode) ||
                (libro1.GetISBN == libro2.GetISBN) ||
                ((libro1.GetTitulo == libro2.GetTitulo) && (libro1.GetAutor == libro2.GetAutor)));
        }
        public static bool operator !=(Libro libro1, Libro libro2)
        {
            return !(libro1 == libro2);
        }

        /*
        Sobrecargo el StringBuilder de la clase padre y le agrego datos a mostrar
        */
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.ToString());
            datos.AppendLine($"ISBN: {this.GetISBN}");
            datos.AppendLine($"Cod. de barras: {this.GetBarcode}");
            datos.AppendLine($"Número de páginas: {this.GetNumPaginas}.");
            return datos.ToString();
        }
    }
}
