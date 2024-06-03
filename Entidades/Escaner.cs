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
            if ((d == null) || (e == null))
            {
                return false;
            }
            foreach (Documento documento in e.listaDocumentos)
            {
                if (documento is Libro && d is Libro)
                {
                    if ((Libro)d == (Libro)documento)
                    {
                        retorno = true;
                        break;
                    }
                }
                else if (documento is Mapa && d is Mapa)
                {
                    if ((Mapa)d == (Mapa)documento)
                    {
                        retorno = true;
                        break;
                    }
                }
                else
                {
                    throw new TipoIncorrectoExcepcion("Este escáner no acepta este tipo de documento", "Escaner", "==");
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
            try
            {
                if ((d == null) || (e == null))
                {
                    return false;
                }
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
                            throw new TipoIncorrectoExcepcion("El documento no se pudo añadir a la lista",
                                "Escaner", "+");
                        }
                    }
                }
            }
            catch(TipoIncorrectoExcepcion ex)
            {
                throw new TipoIncorrectoExcepcion("El documento no se pudo añadir a la lista", "Escaner", "+", ex);
            }
            return retorno;
        }

        /*
        Metodo:
            Avanza el estado del documento desde la lista. // Validar que no este el documento en la lista.
        */
        public bool CambiarEstadoDeDocumento(Documento doc)
        {
            try
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
