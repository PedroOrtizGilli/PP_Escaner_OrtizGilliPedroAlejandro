using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class TipoIncorrectoExcepcion : Exception
    {
        string nombreClase;
        string nombreMetodo;

        public string NombreClase
        {
            get => this.nombreClase;
        }
        public string NombreMetodo
        {
            get => this.nombreMetodo;
        }
        public TipoIncorrectoExcepcion(string mensaje, string nombreClase, string nombreMetodo) 
            : base(mensaje)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }
        public TipoIncorrectoExcepcion(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Excepcion en el metodo {nombreMetodo} de la clase {nombreClase}");
            sb.AppendLine($"Algo salió mal, revisa los detalles");
            sb.AppendLine($"Detalles: {Message}");
            return sb.ToString();
        }
    }
}
