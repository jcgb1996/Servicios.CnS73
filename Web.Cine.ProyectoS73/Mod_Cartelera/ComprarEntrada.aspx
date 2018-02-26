<%@ Page Title="" Language="C#" MasterPageFile="~/Mod_Dashboard/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="ComprarEntrada.aspx.cs" Inherits="Web.Cine.ProyectoS73.Mod_Dashboard.Formulario_web12" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Src="~/User Control/UcNotificaciones.ascx" TagPrefix="uc1" TagName="UcNotificaciones" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function ASPxCallbackReport_finish() {
            ASPxLoadingPanel1.Hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

     <uc1:UcNotificaciones runat="server" ID="UcNotificaciones" />
    <dx:ASPxCallbackPanel ID="idActualizarCombo" ClientInstanceName="idActualizarCombo" OnCallback="idActualizarCombo_Callback" runat="server" Width="100%">
        <PanelCollection>
            <dx:PanelContent>
                <table style="float: left; height: 100px;  padding-right: 8px;">
                    <tr style="margin-right: 4px; padding-top: 20px; padding-bottom: 30px;">

                       
                    </tr>
                    <tr>
                        <td style="margin-right: 4px;">Seleccione Pelicula:
                        </td>
                        <td>
                            <dx:ASPxComboBox ID="cmbPelicula" ClientInstanceName="cmbPelicula" runat="server" ValueType="System.String">
                                <ClientSideEvents SelectedIndexChanged="function Seleccion(){idActualizarCombo.PerformCallback(1);}" />
                            </dx:ASPxComboBox>
                        </td>
                        <td style="padding-left: 8px;">Ingrese Sus nombre: 
                        </td>
                        <td style="padding-left: 8px;">
                            <dx:ASPxTextBox ID="txtNombre" ClientInstanceName="txtNombre" runat="server" Width="120px"></dx:ASPxTextBox>
                        </td>
                        <td style="padding-left: 8px;">Ingrese # Entradas: 
                        </td>
                        <td style="padding-left: 8px;">
                            <dx:ASPxSpinEdit ID="ASPxSpinEdit1" runat="server" Width="90px" Number="0">
                            </dx:ASPxSpinEdit>
                        </td>
                        <td style="padding-left: 8px;">
                            <dx:ASPxButton ID="BtnVistaPrevia" AutoPostBack="false" runat="server" Text="Vista Previa">
                                <ClientSideEvents Click="function Click(){  
                        ASPxCallbackReport.PerformCallback();
                        ASPxLoadingPanel1.Show(); }" />
                            </dx:ASPxButton>
                        </td>

                        <td style="padding-left: 8px;">
                            <dx:ASPxButton ID="BtnComprar" AutoPostBack="false" runat="server" OnClick="BtnComprar_Click" Text="Comprar Entrada">
                            </dx:ASPxButton>
                        </td>
                    </tr>



                    <tr>
                        <td style="padding-left: 8px;">
                            # de Entradas Disp.
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtDisponibles" Enabled="false" runat="server" ClientInstanceName="txtDisponibles" Width="70px">
                            </dx:ASPxTextBox>
                        </td>
                        <td style="padding-left: 8px;">
                            Sala: 
                        </td>
                        <td style="padding-left: 8px;">
                            <dx:ASPxTextBox ID="txtSala" Enabled="false" runat="server" ClientInstanceName="txtSala" Width="70px"></dx:ASPxTextBox>
                        </td>
                        <td style="padding-left: 8px;">
                            Tipo: 
                        </td>
                        <td style="padding-left: 8px;">
                            <dx:ASPxTextBox ID="TipoPelicula" Enabled="false" runat="server" ClientInstanceName="TipoPelicula" Width="70px"></dx:ASPxTextBox>
                        </td>
                    </tr>

                </table>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>
    <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" ClientInstanceName="ASPxLoadingPanel1" runat="server" Modal="true">
        <Image Url="../Imagenes/Loading_icon.gif" Height="50px" Width="80px"></Image>
    </dx:ASPxLoadingPanel>

    <dx:ASPxCallbackPanel ID="ASPxCallbackReport" ClientInstanceName="ASPxCallbackReport" OnCallback="ASPxCallbackReport_Callback" runat="server">
        <ClientSideEvents EndCallback="ASPxCallbackReport_finish" />
        <SettingsLoadingPanel Enabled="false" />
        <PanelCollection>
            <dx:PanelContent>
                <dx:ASPxDocumentViewer ID="RptComprarEntrada" ClientInstanceName="RptComprarEntrada" runat="server" Height="500px" Visible="true">
                    <SettingsReportViewer UseIFrame="False" />
                    <SettingsSplitter RightPaneVisible="False" SidePaneVisible="False" />
                </dx:ASPxDocumentViewer>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

</asp:Content>
