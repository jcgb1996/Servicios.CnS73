using Servicios.CnS73;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cine.ProyectoS73.Mod_Dashboard
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected List<Catalogo> consultarPeliculas() { return ConsultarPeliculas(); }

        Consumo consu = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ConsultarPeliculaCartelera();
            }
        }

        public List<Catalogo> ConsultarPeliculas()
        {
            List<Catalogo> Datos = null;
            consu = new Consumo();
            try
            {
                Datos = consu.ObtenerCatalogo().ToList();
                Session["Datos"] = consu;

            }
            catch(Exception ex)
            {

            }

            return Datos;
        }
    }
}