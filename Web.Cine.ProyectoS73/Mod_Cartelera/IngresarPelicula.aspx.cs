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
                    CmbSala.DataSource = sala;
                    CmbSala.ValueField = "IDSALA";
                    CmbSala.TextField = "DESCRIPCION";
                    CmbSala.DataBind();
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
                    CmbTipoPelicula.DataSource = TipoPelicula;
                    CmbTipoPelicula.ValueField = "IDTIPOPELICULA";
                    CmbTipoPelicula.TextField = "DESCRIPCION";
                    CmbTipoPelicula.DataBind();
                }
                else
                {
                    CmbTipoPelicula.DataSource = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void BloquearControles(bool EsBloquear, int Esnuevo = 0)
        {
            registrar.Enabled = Esnuevo!= 0 ? true: false;
            ImgLogo.Visible = Esnuevo == 2 ? false : true;
            CmbSelecPelicula.Visible = Esnuevo == 2 ? true : false;
            CmbSelecPelicula.Visible = Esnuevo == 2 ? false : true;
            LblSelecPeli.Visible = Esnuevo == 2 ? false : true;
        }

        public void LimpiarControles()
        {
            ASPxTextBox1.Text = string.Empty;
            ASPxTextBox2.Text = string.Empty;
            CmbTipoPelicula.Text = string.Empty;
            CmbEstados.Text = string.Empty;
            FDesde.Text = string.Empty;
            Fhasta.Text = string.Empty;
           //HoraHastas.Text = string.Empty;
           //HoraDesdes.Text = string.Empty;
            CmbSala.Text = string.Empty;
            CmbSelecPelicula.Text = string.Empty;
            NumeroEntradas.Text = string.Empty;
            HoraHastas1.Text = "00:00";
            HoraDesdes2.Text = "00:00";
            Duracion1.Text = "00:00";
            Descripcion.InnerText = string.Empty;
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
                    ASPxTextBox2.Text =  a.APODO;
                    ASPxTextBox1.Text = a.NOMBRE;
                    CmbTipoPelicula.Text = a.TIPOPELICULA;
                    CmbEstados.Text = a.ESTADO;
                    CmbSala.Text = sala.Where(x => x.IDSALA == a.IDSALA).Select(x => x.DESCRIPCION).FirstOrDefault();
                    NumeroEntradas.Text = a.NUMEROENTRADASDISPO + "";
                    var lala = Environment.CurrentDirectory;
                    if (a.URL != null && a.URL != "")
                    {
                       this.ImgLogo.Src =@"..\Imagenes\"+a.URL;
                       
                    }
                    else
                    {
                        this.ImgLogo.Src = "";
                    }
                    SpinValor.Text = a.PRECIO + "";
                    Descripcion.InnerText = a.DESCRIPCION;
                    FDesde.Date = Convert.ToDateTime(a.FECHADESDE +"");
                    Fhasta.Date = Convert.ToDateTime(a.FECHAHASTA + "");
                    var HoraH = Convert.ToString(a.HORAHASTA); 
                    var HoraD = Convert.ToString(a.HORADESDE);
                    var duracion = Convert.ToString(a.DURACION);
                    string durac = duracion.Replace(',',':');
                    string hora = HoraH.Replace(',', ':');
                    string hora2 = HoraD.Replace(',', ':');
                    HoraHastas1.Text = hora;
                    HoraDesdes2.Text = hora2;
                    Duracion1.Text = durac;
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

        public Catalogo AgregarCampos()
        {
            Catalogo IngresarCatalogo = null;
            try
            {
                IngresarCatalogo = new Catalogo();

                
                IngresarCatalogo.NUMEROENTRADAS = Convert.ToInt32(NumeroEntradas.Text);
                IngresarCatalogo.ESTADO = Convert.ToString(CmbEstados.Value);
                IngresarCatalogo.IDSALA = Convert.ToInt32(CmbSala.Value);
                IngresarCatalogo.URL = FileUpload1.FileName + "";
                IngresarCatalogo.NOMBRE = ASPxTextBox1.Text+"";
                IngresarCatalogo.APODO = ASPxTextBox2.Text;
                IngresarCatalogo.IDTIPOPELICULA = Convert.ToInt32(CmbTipoPelicula.Value +"");
                IngresarCatalogo.ESTADO = CmbEstados.Value+"";
                IngresarCatalogo.FECHADESDE = FDesde.Date;
                IngresarCatalogo.FECHAHASTA = Fhasta.Date;
                IngresarCatalogo.PRECIO = Convert.ToDecimal(SpinValor.Text + "");
                var HoraD = Convert.ToString(HoraDesdes2.Text);
                var HoraH = Convert.ToString(HoraHastas1.Text);
                var duracion = Convert.ToString(Duracion1.Text);
                string hora = HoraH.Replace(':', ',');
                string hora2 = HoraD.Replace(':', ',');
                string durac = duracion.Replace(':', ',');
                IngresarCatalogo.HORAHASTA = Convert.ToDecimal(hora);
                IngresarCatalogo.HORADESDE = Convert.ToDecimal(hora2);
                IngresarCatalogo.DURACION = Convert.ToDecimal(durac);
                IngresarCatalogo.DESCRIPCION = Descripcion.InnerText;
            }
            catch (Exception ex)
            {

            }
            return IngresarCatalogo;
        }
        public string GurdarPelicula()
        {
            consu = new Consumo();
            string mensaje = "";
            try
            {
               var text = Descripcion.InnerText; 
                String imagen = FileUpload1.FileName;
                string ExtencionImg = System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper();

                if (ASPxTextBox1.Text + "" == "" && ASPxTextBox2.Text + "" == "" && CmbTipoPelicula.Value + "" == "" && CmbEstados.Value + "" == "" && FDesde.Date == Convert.ToDateTime("01/01/0001 0:00:00") && Fhasta.Date == Convert.ToDateTime("01/01/0001 0:00:00"))
                {

                    mensaje = "TODOS LOS CAMPOS SON OBLIGATORIOS";
                    UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);
                }
                else
                {
                    if (Fhasta.Date < DateTime.Today)
                    {
                        mensaje = "LA FECHA HASTA NO PUEDE SER MAYOR A LA FECHA DESDE";
                        UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);
                    }                    
                else
                    {
                        if(FDesde.Date < DateTime.Today)
                        {
                            mensaje = "LA FECHA DESDE NO PUEDE SER MENOR A LA FECHA ACTUAL DEL SISTEMA";
                            UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);
                        }
                        else
                        {
                            var HoraD = Convert.ToString(HoraDesdes2.Text);
                            var HoraH = Convert.ToString(HoraHastas1.Text);
                            var HDuracion = Convert.ToString(Duracion1.Text);
                            decimal hora = Convert.ToDecimal(HoraH.Replace(':', ','));
                            decimal hora2 = Convert.ToDecimal(HoraD.Replace(':', ','));
                            decimal durac = Convert.ToDecimal(HDuracion.Replace(':', ','));
                            
                            if (HoraH != "" && HoraD != "")
                            {
                                if (hora2 > hora  )
                                {
                                    mensaje = "LA HORA DESDE NO PUEDE SER MAYOR A LA HORA HASTA";
                                    UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);
                                }
                                
                                else
                                {
                                    if (Convert.ToDecimal(SpinValor.Text) > 0)
                                    {
                                        if (ExtencionImg.ToUpper() == ".JPG")
                                        {
                                            String ruta = Server.MapPath("~/Imagenes/") + imagen;
                                            if (!File.Exists(ruta))
                                            {
                                                FileUpload1.SaveAs(ruta);
                                                mensaje = consu.IngresarPelicula(AgregarCampos());
                                            }
                                            else
                                            {
                                                File.Delete(ruta);
                                                if (!File.Exists(ruta))
                                                {
                                                    FileUpload1.SaveAs(ruta);
                                                    mensaje = consu.IngresarPelicula(AgregarCampos());
                                                    if (mensaje == "")
                                                    {

                                                        UcNotificaciones.Notificar(TipoNotificacion.Success, "La pelicula fue registrada con exito!");
                                                        LimpiarControles();
                                                        LlenarComboSeleccion();
                                                    }
                                                    else
                                                    {
                                                        UcNotificaciones.Notificar(TipoNotificacion.Error, mensaje);
                                                        LimpiarControles();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            mensaje = "SOLO SE ACPTAN IMAGEN CON FORMATO (.JPG, .PENG, JPEG)";
                                            UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);

                                        }
                                    }
                                    else
                                    {
                                        mensaje = "INGRESE EL PRECIO UNITARIO DE LA PELICULA";
                                        UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);
                                    }
                                    
                                }
                                
                            }
                            else
                            {
                                mensaje = "LAS HORAS SON CAMPOS OBLIGATORIOS";
                                UcNotificaciones.Notificar(TipoNotificacion.Info, mensaje);
                            }
                        }
                        
                    }
                
                }

            }

            catch (Exception ex)
            {
                UcNotificaciones.Notificar(TipoNotificacion.Error, ex.Message);
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


                    CmbSelecPelicula.DataSource = cata;
                    CmbSelecPelicula.TextField = "NOMBRE";
                    CmbSelecPelicula.ValueField = "IDPELICULA";
                    CmbSelecPelicula.DataBind();
                }
                else
                {
                    CmbSelecPelicula.Enabled = false;
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
                        var IdPelicula = CmbSelecPelicula.Value;
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