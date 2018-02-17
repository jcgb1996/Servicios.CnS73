<%@ Page Title="" Language="C#" MasterPageFile="~/Mod_Dashboard/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="IngresarPelicula.aspx.cs" Inherits="Web.Cine.ProyectoS73.Mod_Cartelera.IngresarPelicula" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        html {
            font-size: 16px;
            font-family: 'lato',sans-serif;
        }

        /*body {
            background-color: #C6E4F3;
        }*/

        .container {
            max-width: 525px;
            height: auto;
            background-color: #EFEFEF;
            /*margin: 5% auto;*/
            padding-bottom: 1rem;
        }

        .form_top {
            width: 100%;
            text-align: center;
            border-top: solid .4rem #F39B53;
            padding: 2rem 0 1rem;
            margin-bottom: 1rem;
        }

            .form_top h2 {
                font-weight: bold;
                color: #CAC8C8;
                font-size: 18px;
            }

        h2 span {
            color: #F39B53;
        }

        .form_reg {
            padding: 0.2rem;
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

        .btn_form {
            display: flex;
            justify-content: space-around;
            margin-top: 1rem;
        }

        .input, .btn_registrar, .btn_cancelar {
            border-bottom: #EFEFEF !important;
            padding: .5rem !important;
            margin: .5rem 0 !important;
            border: none !important;
            border-bottom: solid #C8C8C8 !important;
            transition: all .5S !important;
        }

            .input:focus {
                border-bottom: solid #F39B53 .2rem;
            }

        .btn_registrar, .btn_cancelar {
            width: 40%;
            border-bottom: none;
            background-color: #31B1E5;
            color: white;
        }

            .btn_cancelar:hover {
                border-bottom: #4C9ED9;
            }

            .btn_registrar:hover {
                border-bottom: #FA9535;
            }
    </style>
    <script type="text/javascript">
        function PanelIngreso_Callback_Finish(s, e) {
            LoadingPanel.Hide();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form_top">
            <h2 id="titulo">CREAR <span>PELICULA</span></h2>
            <br>
            <br>
            <table>
                <tr>
                    <dx:ASPxButton ID="IngresarNuevo" AutoPostBack="false" CssClass="input" runat="server" Text="Ingresar Una Nueva Pelicula"></dx:ASPxButton>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="LblSelecPeli" CssClass="input" runat="server" Text="Seleccionar Pelicula"></dx:ASPxLabel>

                    </td>
                    <td>
                        <dx:ASPxComboBox NullText="- Seleccione -"  ID="CmbSelecPeli" AutoPostBack="false" runat="server" CssClass="input" ValueType="System.String">
                            <ClientSideEvents SelectedIndexChanged="function Seleccion(){
                                LoadingPanel.Show();
                                PanelIngreso.PerformCallback();
                                }" />

                        </dx:ASPxComboBox>


                    </td>
                </tr>
            </table>

            <dx:ASPxCallbackPanel ID="PanelIngreso" OnCallback="PanelIngreso_Callback" ClientInstanceName="PanelIngreso" CssClass="" runat="server">
                <ClientSideEvents EndCallback="PanelIngreso_Callback_Finish" />
                <SettingsLoadingPanel Enabled="false" />
                <PanelCollection>
                    <dx:PanelContent>
                        <div class="control-group">
                            <%--<asp:Image ID="Image1" runat="server" />--%>
                            <img alt="" visible="true" style="width: 266px; height: 250px; border: 3px solid #32C2CD;"
                                runat="server" id="ImgLogo" />
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LblLogo" Visible="true" runat="server" Text="Logo:" CssClass="control-label"></asp:Label>
                            <div class="">
                                <div>
                                    <asp:FileUpload ID="FupLogo" runat="server" class="" TabIndex="2"
                                        accept="jpg" AllowMultiple="false" Visible="true" Enabled="true" maxlength="3" />
                                </div>
                            </div>

                        </div>
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="lablNombre" runat="server" CssClass="input" Text="Nombre"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TextNombre" AutoPostBack="false" CssClass="input" runat="server" Width="170px"></dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="lblApodo" CssClass="input" runat="server" Text="Apodo:"></dx:ASPxLabel>
                                </td>

                                <td>
                                    <dx:ASPxTextBox ID="TextApodo" AutoPostBack="false" CssClass="input" runat="server" Width="170px"></dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="lblTipoPeli" CssClass="input" runat="server" Text="Tipo Pelicula"></dx:ASPxLabel>

                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="CmbTipoPeli" ClientInstanceName="CmbTipoPeli" AutoPostBack="false" runat="server" 
                                        CssClass="input" NullText="- Seleccione -" TabIndex="24"  Width="170px" ValueType="System.String"></dx:ASPxComboBox>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" CssClass="input" runat="server" Text="Estado"></dx:ASPxLabel>

                                </td>
                                <td>
                                    <dx:ASPxComboBox Width="98%" Height="30" NullText="-Seleccione-" ID="cmbEstado" ClientInstanceName="cmbEstado"
                                        AutoPostBack="false"  CssClass="input" runat="server" ValueType="System.String" TabIndex="24">
                                        <ClearButton Visibility="True">
                                        </ClearButton>
                                        <Items>
                                            <dx:ListEditItem Text="ACTIVO" Value="A" />
                                            <dx:ListEditItem Text="INACTIVO" Value="I" />
                                        </Items>
                                    </dx:ASPxComboBox>

                                    
                                </td>

                            </tr>
                            <tr style="float: unset;">
                                <td>
                                    <dx:ASPxButton ID="registrar" AutoPostBack="false" CssClass="input" runat="server" Text="REGISTRAR"></dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="cancelar" AutoPostBack="false" CssClass="input" runat="server" Text="CANCELAR"></dx:ASPxButton>
                                </td>
                            </tr>

                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxCallbackPanel>



        </div>

        <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Modal="true" HorizontalAlign="Center" VerticalAlign="Middle">
            <Image Url="../Imagenes/Loading_icon.gif" Height="50px" Width="80px"></Image>
        </dx:ASPxLoadingPanel>

    </div>
</asp:Content>
