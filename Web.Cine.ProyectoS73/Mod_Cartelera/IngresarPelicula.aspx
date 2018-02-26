<%@ Page Title="" Language="C#" MasterPageFile="~/Mod_Dashboard/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="IngresarPelicula.aspx.cs" Inherits="Web.Cine.ProyectoS73.Mod_Cartelera.IngresarPelicula" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/User Control/UcNotificaciones.ascx" TagPrefix="uc1" TagName="UcNotificaciones" %>


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
    <script type='text/javascript' src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        function PanelIngreso_Callback_Finish(s, e) {
            LoadingPanel.Hide();
        }

        function GuardarPeli() {
            PanelIngreso.PerformCallback(2);
            LoadingPanel.Show();

        }

        $(document).ready(function () {
            $('.capaModal').css("display", "none");
        });


        function Ingresar() {
            // var lala = LblLogo.val();
            // alert(lala);

            ASPxCallbackGuardar.PerformCallback();
            LoadingPanel.Show();
            if (TextNombre.GetText().trim() != ""
              && TextApodo.GetText().trim() != ""
              && CmbTipoPeli.GetText().trim() != ""
              && cmbEstado.GetText().trim() != ""
              && FDesde.GetText().trim() != ""
              && Fhasta.GetText().trim() != ""
              && HoraDesde.GetText().trim() != ""
              && HoraHasta.GetText().trim() != "") {
            } else {
                $('.capaModal').css("display", "block");
                $('.capaModal').show();
            }


        }
        function CallbckGuardar() {
            LoadingPanel.Hide();
        }

        function OnKeyPress(s, e) {
            var theEvent = e.htmlEvent || window.event;
            var key = theEvent.keyCode || theEvent.which;
            var txt = s.GetText();
            if (key != 8 || key != 13)
                txt += String.fromCharCode(key);
            if (key == 13)
                theEvent.returnValue = false
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container">
        <div class="form_top">
            <h2 id="titulo">CREAR <span>PELICULA</span></h2>
            <br>
            <br>
            <uc1:UcNotificaciones runat="server" ID="UcNotificaciones" />
            <table>
                <tr>
                    <dx:ASPxButton ID="IngresarNuevo" AutoPostBack="false" CssClass="input" runat="server" Text="Ingresar Una Nueva Pelicula">
                        <ClientSideEvents Click="function IngresarNuevo(){
                           PanelIngreso.PerformCallback(2);
                           LoadingPanel.Show();
                           }" />
                    </dx:ASPxButton>
                </tr>
            </table>


            <dx:ASPxCallbackPanel ID="PanelIngreso" OnCallback="PanelIngreso_Callback" ClientInstanceName="PanelIngreso" CssClass="" runat="server">
                <ClientSideEvents EndCallback="PanelIngreso_Callback_Finish" />
                <SettingsLoadingPanel Enabled="false" />
                <PanelCollection>
                    <dx:PanelContent>
                        <table>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="LblSelecPeli" Visible="true" CssClass="input" runat="server" Text="Peliculas: "></dx:ASPxLabel>

                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="CmbSelecPelicula" CssClass="input" AutoPostBack="false" NullText="- SELECCIONE -" runat="server" ValueType="System.String">
                                        <ClearButton Visibility="True">
                                        </ClearButton>
                                        <ClientSideEvents SelectedIndexChanged="function Seleccion(){
                                LoadingPanel.Show();
                                PanelIngreso.PerformCallback(1);
                                }" />

                                    </dx:ASPxComboBox>


                                </td>
                            </tr>
                        </table>
                        <div class="control-group">
                            <%--<asp:Image ID="Image1" runat="server" />--%>
                            <img alt="" visible="true" style="width: 266px; height: 250px; border: 3px solid #32C2CD;"
                                runat="server" id="ImgLogo" />
                        </div>
                        <div class="control-group">
                            <asp:Label ID="LblLogo" Visible="true" runat="server" Text="Logo:" CssClass="control-label"></asp:Label>

                            <div class="">
                                <div>
                                    <asp:FileUpload accept="jpg" ID="FileUpload1" runat="server" maxlength="3" />
                                </div>
                            </div>

                        </div>
                        <br />
                        <br />
                        <table>
                            <tr>

                                <td>
                                    <dx:ASPxLabel ID="LblSalas" Visible="true" CssClass="input" runat="server" Text="Salas: "></dx:ASPxLabel>


                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="CmbSala" ClientInstanceName="CmbSala" CssClass="input" NullText="- SELECCIONE -" AutoPostBack="false" runat="server" ValueType="System.String"></dx:ASPxComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="lablNombre" runat="server" CssClass="input" Text="Nombre"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox1" CssClass="input" Visible="true" Enabled="true" AutoPostBack="false" runat="server" Width="170px"></dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="lblApodo" CssClass="input" runat="server" Text="Apodo:"></dx:ASPxLabel>
                                </td>

                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox2" CssClass="input" Visible="true" Enabled="true" AutoPostBack="false" runat="server" Width="150px"></dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="lblTipoPeli" Visible="true" CssClass="input" runat="server" Text="Tipo Pelicula"></dx:ASPxLabel>

                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="CmbTipoPelicula" CssClass="input" Visible="true" Enabled="true" NullText="- SELECCIONE -" runat="server" ValueType="System.String"></dx:ASPxComboBox>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" Visible="true" CssClass="input" runat="server" Text="Estado"></dx:ASPxLabel>

                                </td>

                                <td>
                                    <dx:ASPxComboBox ID="CmbEstados" CssClass="input" Visible="true" Enabled="true" ClientInstanceName="CmbEstados" Width="98%" Height="30" NullText="- SELECCIONE -" runat="server" ValueType="System.String">
                                        <ClearButton Visibility="True">
                                        </ClearButton>
                                        <Items>
                                            <dx:ListEditItem Text="ACTIVO" Value="A" />
                                            <dx:ListEditItem Text="INACTIVO" Value="I" />
                                        </Items>

                                    </dx:ASPxComboBox>

                                </td>
                                <td></td>

                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel Visible="true" ID="LblFechaDesde" CssClass="input" runat="server" Text="Desde"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit Visible="true" NullText="__/__/__" ID="FDesde" CssClass="input" ClientInstanceName="FDesde" AutoPostBack="false" runat="server"></dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <dx:ASPxLabel Visible="true" ID="LblFechaHasta" CssClass="input" runat="server" Text="Hasta"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit Visible="true" NullText="__/__/__" ID="Fhasta" CssClass="input" ClientInstanceName="Fhasta" AutoPostBack="false" runat="server"></dx:ASPxDateEdit>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <dx:ASPxLabel Visible="true" ID="HDesde" ClientInstanceName="HDesde" CssClass="input" runat="server" Text="H. Desde"></dx:ASPxLabel>

                                </td>

                                <td>
                                    <dx:ASPxTimeEdit ID="HoraDesdes2" DateTime="2009-11-01 00:00" ClientSideEvents-KeyDown="OnKeyPress" CssClass="input" Enabled="true" AutoPostBack="false" Width="170px" runat="server"></dx:ASPxTimeEdit>
                                    <%--<dx:ASPxTextBox ID="HoraDesdes" CssClass="input" Enabled="true" AutoPostBack="false" NullText="00:00" runat="server" Width="170px"></dx:ASPxTextBox>--%>
                                </td>
                                <td>
                                    <dx:ASPxLabel Visible="true" ID="HHasta" CssClass="input" runat="server" Text="H.Hasta"></dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTimeEdit ID="HoraHastas1" ClientSideEvents-KeyDown="OnKeyPress" AutoPostBack="false" CssClass="input" runat="server" Width="170px" DateTime="2009-11-01 00:00"></dx:ASPxTimeEdit>
                                    <%--<dx:ASPxTextBox ID="HoraHastas" ClientSideEvents-KeyDown="OnKeyPress" CssClass="input" Enabled="true" NullText="00:00" AutoPostBack="false" runat="server" Width="170px"></dx:ASPxTextBox>--%>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel Visible="true" ID="ASPxLabel2" CssClass="input" runat="server" Text="N. Entradas"></dx:ASPxLabel>
                                </td>
                                <td>

                                    <dx:ASPxTextBox ID="NumeroEntradas" CssClass="input" Enabled="true" NullText="0" AutoPostBack="false" runat="server" Width="170px"></dx:ASPxTextBox>

                                </td>
                                <td>
                                    <dx:ASPxLabel runat="server" ID="lblDuracion" ClientInstanceName="lblDuracion" CssClass="input" Text="Duracion: ">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTimeEdit ID="Duracion1" ClientSideEvents-KeyDown="OnKeyPress" AutoPostBack="false" CssClass="input" runat="server" Width="170px" DateTime="2009-11-01 00:00"></dx:ASPxTimeEdit>
                                    <%-- <dx:ASPxDateEdit ID="Duracion" ClientInstanceName="Duracion" AutoPostBack="false" runat="server" Width="170px" DateTime="2009-11-01 00:00"></dx:ASPxDateEdit>--%>
                                </td>
                            </tr>
                            
                            <tr>
                                
                                <td>
                                    
                                <dx:ASPxLabel ID ="lblPrecioPelicula" runat="server" CssClass="input" Text="Pre. U.:" >
                                    
                                </dx:ASPxLabel>
                                </td>
                                <td>
                                    
                                <dx:ASPxSpinEdit ID="SpinValor" runat="server" CssClass="input" Number="0">
                                 </dx:ASPxSpinEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel Visible="true" ID="lblDescrip" ClientInstanceName="lblDescrip" CssClass="input" runat="server" Text="Descripcion: "></dx:ASPxLabel>
                                </td>
                                <td>
                                    <textarea id="Descripcion" class="input" runat="server" style="width: 170px; height: 170px;" cols="20" rows="2"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxButton ID="registrar" OnClick="registrar_Click2" ClientInstanceName="registrar" AutoPostBack="false" CssClass="input" runat="server" Text="REGISTRAR">
                                    </dx:ASPxButton>
                                </td>
                                <%--<td>
                                    <dx:ASPxButton ID="cancelar" AutoPostBack="false" CssClass="input" runat="server" Text="CANCELAR">
                                    </dx:ASPxButton>
                                </td>--%>
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

        <dx:ASPxLoadingPanel ID="LoadingPanel" Visible="true" runat="server" ClientInstanceName="LoadingPanel" Modal="true" HorizontalAlign="Center" VerticalAlign="Middle">
            <Image Url="../Imagenes/Loading_icon.gif" Height="50px" Width="80px"></Image>
        </dx:ASPxLoadingPanel>
    </div>
</asp:Content>
