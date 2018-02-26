using Servicios.CnS73;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.Cine.ProyectoS73.CatalogoServicesClient;

namespace Web.Cine.ProyectoS73
{
    public class Consumo
    {

        public List<Catalogo> ObtenerCatalogo()
        {
            List<Catalogo> cata = null;
            CatalogoProyectoClient catalgo = null;

            try
            {
                catalgo = new CatalogoProyectoClient();
                cata = catalgo.Datos().ToList(); 
            }
            catch
            {
                cata = null;
                catalgo.Close();
            }

            return cata;
        }

        public List<Catalogo> CatalogoPorIdPelicula(int idPelicula)
        {
            List<Catalogo> cata = null;
            CatalogoProyectoClient catalgo = null;
            try
            {
                catalgo = new CatalogoProyectoClient();
                cata = catalgo.CatalogoPorIdPelicula(idPelicula).ToList();

            }
            catch
            {
                catalgo.Close();
                cata = new List<Catalogo>();
            }
            return cata;
        }

        public List <TipoPelicula> ConsultarTipoPelicula()
        {
            List<TipoPelicula> cata = null;
            CatalogoProyectoClient catalgo = null;
            try
            {
                catalgo = new CatalogoProyectoClient(); 
                cata = catalgo.ConsultarTipoPelicula().ToList();


            }catch(Exception ex)
            {
                catalgo.Close();
                cata = null;
            }
            return cata;
        }

        public List<Salas> ConsultarSala()
        {
            CatalogoProyectoClient salasClient = null;
            List<Salas> sala = null;
            try
            {
                salasClient = new CatalogoProyectoClient();
                sala = salasClient.ConsultarSala().ToList();
            }
            catch(Exception ex)
            {
                salasClient.Close();
            }
            

            return sala;
        }


        public string IngresarPelicula(Catalogo CatalogoPelicula)
        {
            string mensaje = "";
            CatalogoProyectoClient ingresar = null;
            try
            {
                ingresar = new CatalogoProyectoClient();
                mensaje = ingresar.IngresarPelicula(CatalogoPelicula);
            }
            catch(Exception ex)
            {
                ingresar.Close();
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public List<Servicios.CnS73.Cine> ConsultarCine()
        {
            List<Servicios.CnS73.Cine> datosCine = null;
            CatalogoProyectoClient DatosCine = null;
            try
            {
                DatosCine = new CatalogoProyectoClient();
                datosCine = DatosCine.ConsultarCine().ToList();
            }
            catch (Exception ex)
            {
                datosCine = null;
                DatosCine.Close();
            }

            return datosCine;
        }

        public string IngrsarVentas(Ventas datos)
        {
            CatalogoProyectoClient DatosCine = null;
            string mensaje = "";
            try
            {
                DatosCine = new CatalogoProyectoClient();
                mensaje = DatosCine.IngrsarVentas(datos);
                
            }
            catch(Exception ex)
            {
                mensaje = ex.Message;
                DatosCine.Close();
            }
            return mensaje;
        }
    }
}