using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        // Atributos:
        int alto;
        int ancho;

        // Constructor:
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho, int alto)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.alto = alto;
            this.ancho = ancho;
        }

        // Propiedades:
        public int GetAlto
        {
            get => this.alto;
        }
        public int GetAncho
        {
            get => this.ancho;
        }
        public int GetSuperficie
        {
            get => ancho * alto;
        }

        /* 
        Sobrecargas:
        Primera: Igualacion. Segunda: Diferencia.
        */
        public static bool operator ==(Mapa mapa1, Mapa mapa2)
        {
            return ((mapa1.GetBarcode == mapa2.GetBarcode) ||
                (mapa1.GetTitulo == mapa2.GetTitulo) && (mapa1.GetAutor == mapa2.GetAutor) &&
                (mapa1.GetAnio == mapa2.GetAnio) && (mapa1.GetSuperficie == mapa2.GetSuperficie));
        }
        public static bool operator !=(Mapa mapa1, Mapa mapa2)
        {
            return !(mapa1 == mapa2);
        }

        /*
        Sobrecargo el StringBuilder de la clase padre y le agrego datos a mostrar
        */
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.ToString());
            datos.AppendLine($"Cod. de barras: {this.GetBarcode}");
            datos.AppendLine($"Superficie: {this.ancho} * {this.alto} = {this.GetSuperficie} cm2.");
            return datos.ToString();
        }
    }
}
