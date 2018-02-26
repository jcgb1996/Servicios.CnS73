<%@ Control Language="C#" CodeBehind="UcNotificaciones.ascx.cs" ClassName="UcNotificaciones" Inherits="Web.Cine.ProyectoS73.UcNotificaciones"%>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2" Namespace="DevExpress.ExpressApp.Web.Templates.ActionContainers"
    TagPrefix="cc2" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2" Namespace="DevExpress.ExpressApp.Web.Controls"
    TagPrefix="cc4" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2" Namespace="DevExpress.ExpressApp.Web.Templates"
    TagPrefix="cc3" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div class="divNotificacion" style="display: none" tabindex='1'>
            <asp:Panel ID="pnlNotificacion" runat="server" CssClass="alert paneles">
                <button class="close" data-dismiss="alert">×</button>
                <strong>
                    <asp:Label ID="lblTipo" CssClass="tipoMensaje" runat="server" Text=""></asp:Label>!</strong>
                <asp:Label ID="lblMensaje" CssClass="mensaje" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>


<script type="text/javascript"> 
    var tiempoMensaje = 18000;//8000
    function mostrarNotificaciones(tipo_param, mensaje_param) {
        var div = "divNotificacion";
        var pnl = ".paneles";
        var tipo = ".tipoMensaje";
        var mensaje = ".mensaje";
        $(mensaje).html(mensaje_param);

        //if ($(pnl).hasClass('alert-success'))
        //    $(pnl).removeClass('alert-success');
        //if ($(pnl).hasClass('alert-error'))
        //    $(pnl).removeClass('alert-error');

        if (tipo_param == 0) {
            $(tipo).html("Exito :");
            $(pnl).attr("class", "alert alert-success paneles");
        } else if (tipo_param == 1) {
            $(tipo).html("Error :");
            $(pnl).attr("class", "alert alert-error paneles");
        } else if (tipo_param == 2) {
            $(tipo).html("Advertencia :");
            $(pnl).attr("class", "alert alert-warning paneles");
        }
        else if (tipo_param == 3) {
            $(tipo).html("Aviso : ");
            $(pnl).attr("class", "alert alert-info paneles");
        }
        $('.' + div).show();
        ocultarMensajesNotificaciones("divNotificacion");
    }
    function ocultarMensajesNotificaciones(div) {
        $('.' + div).focus();
        $('.' + div).show();
        setTimeout(function () {
            $('.' + div).fadeOut(2000);
        }, tiempoMensaje);
    }
</script>

