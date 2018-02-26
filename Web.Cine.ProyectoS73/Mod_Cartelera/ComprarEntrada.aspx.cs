using Nomina_SitioWeb.Reportes;
using Servicios.CnS73;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Cine.ProyectoS73;

namespace Web.Cine.ProyectoS73.Mod_Dashboard
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        Consumo consu = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("CatalogoPorId");
                Session.Remove("Catalogo");
                
            }
            CargarComboPelicula();
        }

        protected void ASPxCallbackReport_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            consu = new Consumo();
            try
            {
                string url = "";
                int idpelicula = Convert.ToInt32(cmbPelicula.Value);
                string nombrePelicula = cmbPelicula.Text;
                string nombre = txtNombre.Text;
                string NumeroEntradas = ASPxSpinEdit1.Text;
                if (idpelicula > 0 && nombre != "")
                {
                    List<Catalogo> datos = consu.CatalogoPorIdPelicula(idpelicula);
                    Session["CatalogoPorId"] = datos;
                    foreach (var a in datos)
                    {
                        url = Server.MapPath("~/Imagenes/") + a.URL + "";
                    }
                    this.RptComprarEntrada.Report = new ReporteComprarEntrada(idpelicula, url, datos, nombrePelicula, NumeroEntradas);
                   
                }
                else
                {
                    
                }
            }
            catch(Exception ex)
            {
               
            }
            
            
        }

        public void CargarComboPelicula()
        {
            consu = new Consumo();
            List<Catalogo> cata = null;
            try
            {
                cata = consu.ObtenerCatalogo();
                Session["Catalogo"] = cata.ToList();
                if (cata.Count > 0 && cata != null)
                {
                    cmbPelicula.DataSource = cata;
                    cmbPelicula.TextField = "NOMBRE";
                    cmbPelicula.ValueField = "IDPELICULA";
                    cmbPelicula.DataBind();

                    // foreach(var a in cata)
                    // {
                    //     txtDisponibles.Text = a.NUMEROENTRADASDISPO + "";
                    // }
                }
                else
                {
                    cmbPelicula.Enabled = false;
                }

            }
            catch (Exception ex)
            {

            }
        }
        public bool validarCampos()
        {
           
            int idpelicula = Convert.ToInt32(cmbPelicula.Value);
           
            string nombre = txtNombre.Text;
            string NumeroEntradas = ASPxSpinEdit1.Text;
            if (idpelicula > 0 && nombre != "" && NumeroEntradas != "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            consu = new Consumo();
            string mensaje = "";
            if (!validarCampos())
            {
                UcNotificaciones.Notificar(TipoNotificacion.Info, "Todos Los Campos Son Obligatorios!!");
            }
            else
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(); 
                string url = "";
                int idpelicula = Convert.ToInt32(cmbPelicula.Value);
                string nombrePelicula = cmbPelicula.Text;
                string nombre = txtNombre.Text;
                string NumeroEntradas = ASPxSpinEdit1.Text;
                if (idpelicula > 0 && nombre != "")
                {
                    
                    List<Catalogo> datos = (List<Catalogo>)Session["CatalogoPorId"]; 
                    (this.RptComprarEntrada.Report = new ReporteComprarEntrada(idpelicula, url, datos, nombrePelicula, NumeroEntradas)).ExportToPdf(stream);
                    string nombreDoc = "Entrada.pdf";
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Accept-Header", stream.Length.ToString());
                    Response.AddHeader("Content-Disposition", ("Attachment; filename=" + nombreDoc));
                    Response.AddHeader("Content-Length", stream.Length.ToString());
                    Response.ContentEncoding = System.Text.Encoding.Default;
                    Response.BinaryWrite(stream.ToArray());
                    Response.Flush();
                    mensaje = consu.IngrsarVentas(ventasDatos());
                    Response.End();

                   
                    
                    UcNotificaciones.Notificar(TipoNotificacion.Success, "El Reporte Se Genero Correctamente!");
                }
            }
        }

        public Ventas ventasDatos()
        {

            Ventas datosV = new Ventas();
            List<Catalogo> datos = (List<Catalogo>)Session["CatalogoPorId"];
            try
            {
                datosV.IDPELICULA = Convert.ToInt32(cmbPelicula.Value);
                datosV.NUMEROENTRADAS = Convert.ToInt32(ASPxSpinEdit1.Text);
                datosV.NOMBRECLIENTE = txtNombre.Text + ""; 
                foreach(var a in datos)
                {
                    if(a.IDPELICULA == datosV.IDPELICULA)
                    {
                        datosV.IDTIPOPELICULA = a.IDTIPOPELICULA;
                        datosV.ID_SALA = a.IDSALA;
                    }
                }
                
            }
            catch (Exception ex)
            {

            }

            return datosV;
        }

        protected void idActualizarCombo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            List<Catalogo> Catalogo = (List<Catalogo>)Session["Catalogo"];
            var IdPelicula = cmbPelicula.Value;
             foreach (var a in Catalogo)
             {
                if(a.IDPELICULA == Convert.ToInt32(IdPelicula))
                {
                    txtDisponibles.Text = a.NUMEROENTRADASDISPO + "";
                    txtSala.Text = a.SALA + "";
                    TipoPelicula.Text = a.TIPOPELICULA + "";
                }
             }
        }
    }
}