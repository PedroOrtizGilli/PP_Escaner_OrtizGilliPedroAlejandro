using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        // Atributos:
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }
        public enum TipoDoc
        {
            libro,
            mapa
        }

        List<Documento> listaDocumentos;
        Departamento locacion;
        string marca;
        TipoDoc tipo;

        // Constructor:
        public Escaner(string marca, TipoDoc tipo)
        {
            this.listaDocumentos = new List<Documento>();
            this.marca = marca;
            this.tipo = tipo;
            if (tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.mapoteca;
            }
        }

        public List<Documento> GetListaDocumentos
        {
            get => this.listaDocumentos;
        }
        public Departamento GetDepartamento
        {
            get => this.locacion;
        }
        public string GetMarca
        {
            get => this.marca;
        }
        public TipoDoc GetTipoDocumento
        {
            get => this.tipo;
        }

        /*
        Sobrecargas:
            Primera: Revisa si el documento esta en un escaner.
            Segunda: Contraparte de la primera.
            Tercera: Si el documento no esta en la lista de documentos y
                        esta en estado = Inicio, agrega el documento a la lista.
        */
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;
            foreach (Documento documento in e.listaDocumentos)
            {
                if (documento == d)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;
            if (e != d)
            {
                if (d.GetEstado == Documento.Paso.Inicio)
                {
                    if ((e.tipo == Escaner.TipoDoc.mapa) && (d is Mapa))
                    {
                        d.AvanzarEstado();
                        e.listaDocumentos.Add(d);
                        retorno = true;
                    }
                    else if ((e.tipo == Escaner.TipoDoc.libro) && (d is Libro))
                    {
                        d.AvanzarEstado();
                        e.listaDocumentos.Add(d);
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
            }
            return retorno;
        }

        /*
        Metodo:
            Avanza el estado del documento desde la lista.
        */
        public bool CambiarEstadoDeDocumento(Documento doc)
        {
            bool retorno = false;
            foreach (Documento documento in this.listaDocumentos)
            {
                if (doc == documento)
                {
                    retorno = true;
                    doc.AvanzarEstado();
                    break;
                }
            }
            return retorno;
            /*
             if (this == doc)
            {
                retorno = true;
                doc.AvanzarEstado();
            }
            */
        }
    }
}
