using Servicios.CnS73;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Cine.ProyectoS73.Mod_Cartelera
{
    public partial class IngresarPelicula : System.Web.UI.Page
    {
        Consumo consu = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Session.Remove("DataCatalogo");
                BloquearControles(false);
                LlenarComboSeleccion();
                CrearDirectorioImagenes();


            }
        }

        public void BloquearControles(bool EsBloquear)
        {
            TextApodo.Enabled = EsBloquear;
            TextNombre.Enabled = EsBloquear;
            CmbTipoPeli.Enabled = EsBloquear;
            cmbEstado.Enabled = EsBloquear;
            LblLogo.Enabled = EsBloquear;
            FupLogo.Enabled = EsBloquear;
            LblLogo.Visible = EsBloquear;
            FupLogo.Visible = EsBloquear;
            ImgLogo.Visible = EsBloquear;
        }

       

        public void LlenarCamposCatalogo(int IdPelicula)
        {

            List<Catalogo> cata = (List<Catalogo>)ViewState["lala"];
            var imagen = ViewState["Directorio"];
            var DatosPorPeli = cata.Where(x => x.IDPELICULA == IdPelicula).Select(x => x).ToList();
            if (DatosPorPeli != null)
            {
                foreach(var a in DatosPorPeli)
                {
                    TextApodo.Text =  a.APODO;
                    TextNombre.Text = a.NOMBRE;
                    CmbTipoPeli.Text = a.TIPOPELICULA;
                    cmbEstado.Text = a.ESTADO;
                    string imagenValidar = imagen+""+a.URL;
                    if (File.Exists(imagenValidar))
                    {
                        ImgLogo.Src = imagenValidar;
                        ImgLogo.Width = 266;
                        ImgLogo.Height = 250;
                    }
                    else
                    {

                    }


                }

                CrearDirectorioImagenes();
            }
            else
            {
                BloquearControles(false);
            }
            
        }

        public void CrearDirectorioImagenes()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                string Directorio = ConfigurationManager.AppSettings["Directorio"];
                Directorio = Directorio + @"\Imagenes";
                ViewState["Directorio"] = Directorio;
                if (!Directory.Exists(Directorio))
                {
                    Directory.CreateDirectory(Directorio);
                }
                else { }
            }
            catch (Exception e)
            {

            }
    }

        public void LlenarComboSeleccion()
        {
            consu = new Consumo();
            List<Catalogo> cata = null;
            try
            {
                cata = consu.ObtenerCatalogo();
                ViewState["lala"] = cata.ToList(); 
                if (cata.Count> 0 && cata != null)
                {

                    
                    CmbSelecPeli.DataSource = cata;
                    CmbSelecPeli.TextField = "NOMBRE";
                    CmbSelecPeli.ValueField = "IDPELICULA";
                    CmbSelecPeli.DataBind();
                }
                else
                {
                    CmbSelecPeli.Enabled = false;
                }

            }catch(Exception ex)
            {

            }
            //CmbSelecPeli
        }
        
        protected void ASPxCallbackIngresarPelicula_Callback1(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

        }

        protected void PanelIngreso_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            BloquearControles(true);
            var IdPelicula = CmbSelecPeli.Value;
            LlenarCamposCatalogo(Convert.ToInt32(IdPelicula));

        }
    }
}