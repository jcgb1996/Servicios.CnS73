using Servicios.CnS73;
using System;
using System.Collections.Generic;
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



    }
}