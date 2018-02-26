using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.IO;
using System.Web;
using System.Drawing.Drawing2D;
using Servicios.CnS73;
using System.Collections.Generic;
using Web.Cine.ProyectoS73;

namespace Nomina_SitioWeb.Reportes
{
    public partial class ReporteComprarEntrada : DevExpress.XtraReports.UI.XtraReport
    {
        private Consumo consu = null;

        public ReporteComprarEntrada(int idpelicula, string url, List<Catalogo> datos, string nombrePelicula, string NumeroEntradas)
        {
            InitializeComponent();

            BarcodeLib.Barcode codigo = new BarcodeLib.Barcode();
            codigo.IncludeLabel = true;
            this.xrPictureBox2.Image = codigo.Encode(BarcodeLib.TYPE.CODE128, nombrePelicula, Color.Black, Color.White,400,100);




            AsignarValoresReport(datos, NumeroEntradas);

        }
        
        public void AsignarValoresReport(List<Catalogo> Catalogo, string NumeroEntradas)
        {
            consu = new Consumo();
            try
            {
                decimal PrecioU = 0;
                var datosCine = consu.ConsultarCine();
                if (datosCine != null)
                {
                    foreach (var a in datosCine)
                    {
                        xrNombreCine.Text = a.NOMBRECOMPLEJO + "";
                        xrNumRuc.Text = a.RUC + "";
                    }
                    
                    foreach(var a in Catalogo)
                    {
                        xrNombrePelicula.Text = a.NOMBRE + "";
                        xrPrecioUni.Text = a.PRECIO + "";
                        PrecioU = a.PRECIO ?? 0;
                        xrSala.Text = a.SALA; 
                    }
                    xrCantidad.Text = NumeroEntradas;
                    decimal numeroEntrada = Convert.ToDecimal(NumeroEntradas);
                    xrPrecioTotal.Text = Convert.ToString(Math.Round(PrecioU * numeroEntrada,2));
                    xrValorTotal.Text = xrPrecioTotal.Text;
                    xrJBeneficiencia.Text = "0,07";
                    xrImpuestoMuni.Text = "0,07";
                    xrIva.Text = "0,00";
                    decimal JBeneficiencia = Convert.ToDecimal(xrJBeneficiencia.Text);
                    decimal ImpuestoMuni = Convert.ToDecimal(xrImpuestoMuni.Text);
                    decimal Iva = Convert.ToDecimal(xrIva.Text);
                    decimal valorTo = Convert.ToDecimal(xrValorTotal.Text);
                    xrNetoPagar.Text = Convert.ToString(Math.Round(JBeneficiencia + ImpuestoMuni + Iva + valorTo, 2));
                }
            }
            catch (Exception ex)
            {

            }
        }



    }
}
