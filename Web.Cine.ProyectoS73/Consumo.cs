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
        

       
    }
}