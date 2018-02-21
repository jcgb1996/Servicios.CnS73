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
           // int index = path.LastIndexOf('\');

            if (!IsPostBack)
            {
                Session.Remove("DataCatalogo");
                BloquearControles(false);
                LlenarComboSeleccion();
                CrearDirectorioImagenes();
                ConsultarTipoPelicula();
                ConsultarSalas();


            }
        }

        public void ConsultarSalas()
        {
            consu = new Consumo();
            List<Salas> sala = null;
            try
            {
                sala = consu.ConsultarSala().ToList();
                ViewState["Sala"] = sala;
                if (sala != null && sala.Count > 0)
                {
                    CmbSalas.DataSource = sala;
                    CmbSalas.ValueField = "IDSALA";
                    CmbSalas.TextField = "DESCRIPCION";
                    CmbSalas.DataBind();
                }

            }catch(Exception ex)
            {

            }
        }
        public void ConsultarTipoPelicula()
        {
            consu = new Consumo();
            List<TipoPelicula> TipoPelicula = new List<TipoPelicula>();
            try
            {
                TipoPelicula = consu.ConsultarTipoPelicula();
                if (TipoPelicula.Count > 0 && TipoPelicula != null)
                {
                    CmbTipoPeli.DataSource = TipoPelicula;
                    CmbTipoPeli.ValueField = "IDTIPOPELICULA";
                    CmbTipoPeli.TextField = "DESCRIPCION";
                    CmbTipoPeli.DataBind();
                }
                else
                {
                    CmbTipoPeli.DataSource = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void BloquearControles(bool EsBloquear, int Esnuevo = 0)
        {
            TextApodo.Enabled = EsBloquear;
            TextNombre.Enabled = EsBloquear;
            CmbTipoPeli.Enabled = EsBloquear;
            cmbEstado.Enabled = EsBloquear;
            LblLogo.Enabled = EsBloquear;
            //FupLogo.Enabled = EsBloquear;
            LblLogo.Visible = EsBloquear;
            //FupLogo.Visible = EsBloquear;
            ImgLogo.Visible = Esnuevo == 2 ? false : EsBloquear;
            CmbSelecPeli.Visible = Esnuevo != 2 ? true : false;
            LblSelecPeli.Visible = Esnuevo == 2 ? false : EsBloquear;
            LblFechaDesde.Visible = EsBloquear;
            FDesde.Visible = EsBloquear;
            LblFechaHasta.Visible = EsBloquear;
            Fhasta.Visible = EsBloquear;
            HDesde.Visible = EsBloquear;
            HoraDesde.Visible = EsBloquear;
            HHasta.Visible = EsBloquear;
            HoraHasta.Visible = EsBloquear;
            CmbSalas.Visible = EsBloquear;
            LblSalas.Visible = EsBloquear;
               
        }

        public void LimpiarControles()
        {
            TextApodo.Text = string.Empty ;
            TextNombre.Text = string.Empty;
            CmbTipoPeli.Text = string.Empty;
            cmbEstado.Text = string.Empty;
            FDesde.Text = string.Empty;
            Fhasta.Text = string.Empty;
            HoraHasta.Text = string.Empty;
            HoraDesde.Text = string.Empty;
            CmbSalas.Text = string.Empty;
            CmbSelecPeli.Text = string.Empty;
        }




        public void LlenarCamposCatalogo(int IdPelicula)
        {

            List<Catalogo> cata = (List<Catalogo>)ViewState["lala"];
           
            var DatosPorPeli = cata.Where(x => x.IDPELICULA == IdPelicula).Select(x => x).ToList();
            List<Salas> sala = (List<Salas>) ViewState["Sala"]; 
            if (DatosPorPeli != null)
            {
                foreach(var a in DatosPorPeli)
                {
                    TextApodo.Text =  a.APODO;
                    TextNombre.Text = a.NOMBRE;
                    CmbTipoPeli.Text = a.TIPOPELICULA;
                    cmbEstado.Text = a.ESTADO;
                    CmbSalas.Text = sala.Where(x => x.IDSALA == a.IDSALA).Select(x => x.DESCRIPCION).FirstOrDefault();
                    var lala = Environment.CurrentDirectory;
                    if (a.URL != null && a.URL != "")
                    {
                       this.ImgLogo.Src =@"..\Imagenes\"+a.URL;
                       
                    }
                    else
                    {
                        this.ImgLogo.Src = "";
                    }

                    FDesde.Date = Convert.ToDateTime(a.FECHADESDE +"");
                    Fhasta.Date = Convert.ToDateTime(a.FECHAHASTA + "");
                    HoraHasta.Text = a.HORAHASTA + "";
                    HoraDesde.Text = a.HORADESDE + "";
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

        public List<Catalogo> AgregarCampos()
        {
            List<Catalogo> IngresarCatalogo = null;
            try
            {
                IngresarCatalogo = new List<Catalogo>();
                foreach (var a in IngresarCatalogo)
                {
                    a.NOMBRE = TextNombre.Text;
                    a.APODO = TextApodo.Text;
                    a.TIPOPELICULA = CmbTipoPeli.Value +"";
                    a.ESTADO = cmbEstado.Value+"";
                    a.FECHADESDE = FDesde.Date;
                    a.FECHAHASTA = Fhasta.Date;
                    a.HORAHASTA = Convert.ToDecimal(HoraDesde.Text+"".Replace(':','.'));
                    a.HORAHASTA = Convert.ToDecimal(HoraHasta.Text+"".Replace(':', '.'));
                }
                
            }
            catch(Exception ex)
            {

            }
            return IngresarCatalogo;
        }
        public string GurdarPelicula()
        {

            string mensaje = "";
            try
            {
                String imagen = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower(); 
                String imagen1 = FileUpload1.FileName;
                string[] DatosImagen = imagen.Split('.');
                if (DatosImagen[1] == "jpg" )
                {
                    String ruta = Server.MapPath("~/Imagenes/") + imagen1;
                    if (!File.Exists(ruta))
                    {
                        FileUpload1.SaveAs(ruta);
                        //File.Create(ruta);
                        List<Catalogo>  Campos = AgregarCampos();
                    }
                    else
                    {
                        File.Delete(ruta);
                    }
                }
                else
                {
                    mensaje = "SOLO SE ACPTAN IMAGEN CON FORMATO (.JPG, .PENG, JPEG)";

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
           
            return mensaje;

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
        protected void PanelIngreso_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string Identificador = e.Parameter;
            switch (Identificador)
            {
                case "1":
                    {
                        BloquearControles(true);
                        var IdPelicula = CmbSelecPeli.Value;
                        LlenarCamposCatalogo(Convert.ToInt32(IdPelicula));
                    }
                    break;

                case "2":
                    {
                        int Esnuevo = 2;
                        BloquearControles(true,Esnuevo);
                        LimpiarControles();
                        ConsultarTipoPelicula();
                    }
                    break; 

            }
            
           

        }
        
        
        protected void registrar_Click2(object sender, EventArgs e)
        {
             GurdarPelicula();
        }
    }
}