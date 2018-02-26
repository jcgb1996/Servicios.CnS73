<%@ Page Title="" Language="C#" MasterPageFile="~/Mod_Dashboard/PrincipalMaster.Master" AutoEventWireup="true" CodeBehind="ComprarPelicula.aspx.cs" Inherits="Web.Cine.ProyectoS73.Mod_Dashboard.Formulario_web11" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        @import url(https://fonts.googleapis.com/css?family=Yanone+Kaffeesatz);
        @import 'https://fonts.googleapis.com/css?family=Open+Sans';

        * {
            box-sizing: border-box;
        }

        img {
            display: block;
            max-width: 100%;
        }



        h1, h2, h3, h4, h5, h6 {
            font-family: 'Yanone Kaffeesatz', sans-serif;
            letter-spacing: 1.5px;
        }

        .section__titulo {
            text-align: center;
            font-size: 40px;
            color: #FBA919;
        }

        .contenedor {
            margin: auto;
            /*width: 99%;*/
        }



        /*-------------------Estilos del header-------------------*/
        .header {
            height: 60px;
        }

            .header .contenedor {
                background-color: #B3C0F2;
                /*display: flex;*/
                justify-content: space-between;
            }

        .logo {
            margin: 5px;
            color: black;
        }

        .icon-menu {
            display: block;
            width: 40px;
            height: 40px;
            font-size: 30px;
            background: #FBA919;
            text-align: center;
            line-height: 45px;
            border-radius: 5px;
            margin-left: auto;
            cursor: pointer;
        }
        /*------------------Estilos del menu------------------*/

        .menu__link {
            border-radius: 10px;
            display: block;
            padding: 15px;
            background: #FBA919;
            text-decoration: none;
            color: black;
        }

            .menu__link:hover, .select {
                background: white;
                color: #FBA919;
            }

        /*--------------Estilos de banner--------------*/



        .banner .contenedor {
            position: absolute;
            top: 50%;
            /*left: 50%;*/
            transform: translateX(-50%) translateY(-50%);
            /*width: 100%;*/
            color: #fff;
            text-align: center;
        }

        .banner__txt {
            display: none;
        }


        /*-----------------Estilos de opciones-----------------*/
        .cursos {
            background-color: azure;
        }

        .cursos__columna {
            max-width: 350px;
            position: relative;
            padding: 16px;
        }

        .cursos__descripcion {
            position: absolute;
            top: 0;
            left: 0;
            width: 60%;
            height: 100%;
            padding: 5px;
        }

        .cursos__img {
            display: block;
            margin: auto;
            width: 200px;
            height: 250px;
        }
        /*-----------------Estilos de footer-----------------*/

        .footer {
            background: #333;
            color: #fff;
            padding: 10px;
            text-align: center;
        }

            .footer .social [class^="icon-"] {
                display: inline-block;
                color: #333;
                text-decoration: none;
                font-size: 30px;
                padding: 10px;
                background: white;
                border-radius: 50%;
                width: 50px;
                height: 50px;
                line-height: 40px;
            }

        /*------------------Estilos responsive------------------*/

        @media(min-width:480px) {
            .logo {
                font-size: 40px;
            }

            .info, .cursos {
                display: flex;
                /*justify-content: space-between;*/
                margin-top: -90px;
            }

            .section__titulo {
                width: 100%;
            }

            .cursos {
                flex-wrap: wrap;
                margin-top: 0;
            }

            .cursos__columna {
                width: 49%;
            }

            .footer .social [class^="icon-"] {
                margin: 0 10px;
            }
        }


        @media(min-width:1024px) {
            .contenedor {
                width: 80px;
            }

            .section__titulo {
                font-size: 50px;
                margin: 30px 0;
            }

            .nav {
                position: static;
                width: auto;
            }

            .menu__link {
                background: none;
                font-size: 20px;
            }

            .select {
                color: #fff;
                background: #FBA919;
            }
        }

        @media(min-width:1280px) {
            .contenedor {
                width: 1060px;
            }

            .logo {
                font-size: 60px;
            }

            .banner .contenedor {
                top: 20%;
            }

            .info {
                margin-top: -220px;
            }
        }

        .imagen_mantenimiento {
            width: 200px;
            margin: 0 auto;
        }

        /*----------------------estilos de la tabla------------------*/

        .columna_T {
            background-color: #A9FFD4;
        }

        .columna {
            background-color: #FFF1A9;
        }

        #tabla_pag {
            width: auto;
            max-width: 100%;
            padding: 16px;
            margin: 0 auto;
        }
    </style>

    <script type='text/javascript' src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function HacerClick() {
            alert("click");
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <main class="main">
        <div class="contenedor">
            <section class="cursos">
                <h2 class="section__titulo">Peliculas Disponibles</h2>


                <% var datos = consultarPeliculas();
                    if (datos != null)
                    {
                        foreach (var a in datos)
                        { %>
                <div class="cursos__columna">
                    <img src="../Imagenes/<% Response.Write(a.URL + ""); %>" id="imgPelicula" class="cursos__img">
                    <a href="ComprarEntrada.aspx">
                        <h2 style="text-align: center;">
                            <samp><% Response.Write(a.NOMBRE + ""); %></samp>

                        </h2>
                    </a>
                    <h3 style="text-align: center;">
                        <%
                            var HoraH = a.HORADESDE + "";
                            var HoraD = a.HORAHASTA + "";
                            var duracion = a.DURACION + "";
                            string hora = HoraH.Replace(',', ':');
                            string hora2 = HoraD.Replace(',', ':');
                            string Duracion = duracion.Replace(',', ':');

                        %>
                        <dx:ASPxLabel ID="lblHora" runat="server" Text="Horas: "></dx:ASPxLabel>
                        <samp><%Response.Write(hora + "" + " " + hora2 + ""); %> </samp>
                    </h3>

                    <h5 style="text-align: center;">
                        <dx:ASPxLabel ID="lblDescripcion" runat="server" Text="Descripcion: "></dx:ASPxLabel>
                        <strong>
                            <p><% Response.Write(a.DESCRIPCION + ""); %></p>
                        </strong>
                    </h5>
                    <h3 style="text-align: center;">
                        <dx:ASPxLabel runat="server" ID="lblDuracion" Text="Duracion: "></dx:ASPxLabel>
                        <strong>
                            <p><% Response.Write(Duracion); %></p>
                        </strong>
                    </h3>
                    <h3 style="text-align: center;">
                        <dx:ASPxLabel ID="lblSala" runat="server" Text="Sala: "></dx:ASPxLabel>
                        <strong><% Response.Write(a.IDSALA + ""); %> </strong>
                    </h3>
                    <h3 style="text-align: center;">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="# Entra.: "></dx:ASPxLabel>
                        <strong><% Response.Write(a.NUMEROENTRADASDISPO + ""); %> </strong>
                    </h3>
                </div>
                <%} %>
                <% }%>
            </section>

        </div>
    </main>


</asp:Content>
