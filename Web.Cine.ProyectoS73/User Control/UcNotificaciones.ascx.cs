using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;
using System.Collections.Generic;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Layout;
using DevExpress.ExpressApp.Templates.ActionContainers;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using System.Web.UI;

namespace Web.Cine.ProyectoS73
{
    public enum TipoNotificacion
    {
        Success = 0,
        Error = 1,
        Warning = 2,
        Info = 3
    }
    public partial class UcNotificaciones : System.Web.UI.UserControl
    {
        public String SuccessMessage = "Los datos fueron guardados correctamente";
        public String ErrorMessage = "Ha ocurrido un error por favor vuelva a cargar la página.";
        public String WarningMessage = "Debe ingresar todos los datos..";
        public String InfoMessage = "Se le informa que el proceso fue ejecutado.";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        public void Notificar(TipoNotificacion tipo, String mensaje, UpdatePanel up)
        {
            //pnlNotificacion.Visible = true;
            Boolean setearMensaje = false;
            if (!String.IsNullOrEmpty(mensaje))
                setearMensaje = true;
            if (tipo == TipoNotificacion.Error)
            {
                lblTipo.Text = "Error";
                this.pnlNotificacion.CssClass = "alert alert-error";
                this.lblMensaje.Text = setearMensaje ? mensaje : ErrorMessage;
            }
            else if (tipo == TipoNotificacion.Success)
            {
                lblTipo.Text = "Exito";
                this.pnlNotificacion.CssClass = "alert alert-success";
                this.lblMensaje.Text = setearMensaje ? mensaje : SuccessMessage;
            }
            else if (tipo == TipoNotificacion.Warning)
            {
                lblTipo.Text = "Advertencia";
                this.pnlNotificacion.CssClass = "alert";
                this.lblMensaje.Text = setearMensaje ? mensaje : WarningMessage;
            }
            else if (tipo == TipoNotificacion.Info)
            {
                lblTipo.Text = "Aviso";
                this.pnlNotificacion.CssClass = "alert alert-info";
                this.lblMensaje.Text = setearMensaje ? mensaje : InfoMessage;
            }

            //procedo a ocultar el mensaje
            OcultarNotificacion("divNotificacion", up);
        }
        public void Notificar(TipoNotificacion tipo, String mensaje)
        {
            Notificar(tipo, mensaje, null);
        }

        private void OcultarNotificacion(string div, UpdatePanel up)
        {
            string javaScript = String.Format(" ocultarMensajesNotificaciones('{0}'); ", div);
            String jsFunction = "ocultarMensajesNotificaciones";
            if (up != null)
            {
                ScriptManager.RegisterStartupScript(up, up.GetType()
                                                     , jsFunction, javaScript, true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), jsFunction, javaScript, true);
            }
        }
    }
}
