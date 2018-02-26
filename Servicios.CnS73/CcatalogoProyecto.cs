using CnS73.Datos.Entidades;
using Servicios.CnS73.Data_Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios.CnS73
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class CcatalogoProyecto : ICatalogoProyecto
    {
        public string GetData()
        {
            return string.Format("You entered: {0}");
        }

        public List<Catalogo> CatalogoPorIdPelicula(int IdPelicula)
        {
            try
            {
                using (Cn_S73Entities bd = new Cn_S73Entities())
                {
                    var datos = (from a in bd.EM_CATALOGO.AsNoTracking()
                                 join b in bd.EM_TIPOPELICULA1 on a.IDTIPOPELICULA equals b.IDTIPOPELICULA
                                 join c in bd.EM_SALA on a.IDSALA equals c.IDSALA
                                 where a.ESTADO == Estados.Estados.ACTIVO
                                 && b.ESTADO == Estados.Estados.ACTIVO
                                 && a.IDPELICULA == IdPelicula
                                 select new Catalogo
                                 {
                                     IDPELICULA = a.IDPELICULA,
                                     APODO = a.APODO,
                                     CODIGOPILI = a.CODIGOPILI,
                                     ESTADO = a.ESTADO,
                                     IDTIPOPELICULA = a.IDTIPOPELICULA ?? 0,
                                     TIPOPELICULA = b.DESCRIPCION,
                                     NOMBRE = a.NOMBRE,
                                     URL = a.URL,
                                     IDSALA = a.IDSALA,
                                     FECHADESDE = a.FECHADESDE,
                                     FECHAHASTA = a.FECHAHASTA,
                                     HORADESDE = a.HORADESDE,
                                     HORAHASTA = a.HORAHASTA,
                                     NUMEROENTRADAS = a.NUMEROENTRADAS,
                                     NUMEROENTRADASDISPO = a.NUMEROENTRADASDISPO,
                                     DESCRIPCION = a.DESCRIPCION,
                                     DURACION = a.DURACION,
                                     PRECIO = a.PRECIO,
                                     SALA = c.DESCRIPCION,

                                 }).ToList();
                    return datos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Catalogo> Datos(){          
            try
            {
                using (Cn_S73Entities bd = new Cn_S73Entities())
                {
                    var datos = (from a in bd.EM_CATALOGO
                                 join b in bd.EM_TIPOPELICULA1 on a.IDTIPOPELICULA equals b.IDTIPOPELICULA
                                 join c in bd.EM_SALA on a.IDSALA equals c.IDSALA
                                 where a.ESTADO == Estados.Estados.ACTIVO
                                 && b.ESTADO == Estados.Estados.ACTIVO
                                 select new Catalogo
                                 {
                                     IDPELICULA = a.IDPELICULA,
                                     APODO = a.APODO,
                                     CODIGOPILI = a.CODIGOPILI,
                                     ESTADO = a.ESTADO,
                                     IDTIPOPELICULA = a.IDTIPOPELICULA ?? 0,
                                     TIPOPELICULA = b.DESCRIPCION,
                                     NOMBRE = a.NOMBRE,
                                     URL = a.URL,
                                     IDSALA = a.IDSALA,
                                     FECHADESDE = a.FECHADESDE,
                                     FECHAHASTA = a.FECHAHASTA,
                                     HORADESDE = a.HORADESDE,
                                     HORAHASTA = a.HORAHASTA,
                                     NUMEROENTRADAS = a.NUMEROENTRADAS,
                                     NUMEROENTRADASDISPO = a.NUMEROENTRADASDISPO,
                                     DESCRIPCION = a.DESCRIPCION,
                                     DURACION = a.DURACION,
                                     PRECIO = a.PRECIO,
                                     SALA = c.DESCRIPCION,

                                 }).ToList();
                    return datos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

           

            }

        public List<TipoPelicula> ConsultarTipoPelicula() {
            try
            {
                using (Cn_S73Entities bd = new Cn_S73Entities())
                {
                    var TipoPelicula = (from a in bd.EM_TIPOPELICULA1
                                        where a.ESTADO == Estados.Estados.ACTIVO
                                        select new TipoPelicula
                                        {
                                           DESCRIPCION = a.DESCRIPCION,
                                           IDTIPOPELICULA = a.IDTIPOPELICULA
                                        }
                                      ).ToList();
                    return TipoPelicula;
                }

            }
            catch
            {
                return null;
            }
        }

        public List<Salas> ConsultarSala()
        {
            List<Salas> cata = null;
            try
            {
                using (Cn_S73Entities bd = new Cn_S73Entities())
                {
                    var salas = (from a in bd.EM_SALA
                                 where a.ESTADO == Estados.Estados.ACTIVO 
                                 select new Salas
                                 {
                                   IDSALA=  a.IDSALA,
                                     DESCRIPCION=  a.DESCRIPCION,
                                     ESTADO =a.ESTADO
                                 }).ToList();
                    cata = salas;
                }
            }catch(Exception ex)
            {

            }

            return cata;
        }

        public void saludar()
        {
            
        }

        public string IngresarPelicula(Catalogo NuevaPelicula)
        {
            string mensaje = "";
            try
            {
                using (Cn_S73Entities db = new Cn_S73Entities())
                {
                    EM_CATALOGO datos = new EM_CATALOGO();
                    datos.APODO = NuevaPelicula.APODO;
                    datos.NOMBRE = NuevaPelicula.NOMBRE;
                    datos.HORADESDE = NuevaPelicula.HORADESDE;
                    datos.HORAHASTA = NuevaPelicula.HORAHASTA;
                    datos.IDSALA = NuevaPelicula.IDSALA;
                    datos.IDTIPOPELICULA = NuevaPelicula.IDTIPOPELICULA;
                    datos.ESTADO = NuevaPelicula.ESTADO;
                    datos.NUMEROENTRADAS = NuevaPelicula.NUMEROENTRADAS;
                    datos.NUMEROENTRADASDISPO = NuevaPelicula.NUMEROENTRADAS;
                    datos.URL = NuevaPelicula.URL;
                    datos.FECHADESDE = NuevaPelicula.FECHADESDE;
                    datos.FECHAHASTA = NuevaPelicula.FECHADESDE;
                    datos.DESCRIPCION = NuevaPelicula.DESCRIPCION;
                    datos.DURACION = NuevaPelicula.DURACION;
                    db.EM_CATALOGO.Add(datos);
                    db.SaveChanges();
                    mensaje = "";
                }
            }
            catch(Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public List<Cine> ConsultarCine()
        {

            List<Cine> Consultar = null;
            try
            {
                
                using (Cn_S73Entities db = new Cn_S73Entities())
                {
                    Consultar = (from a in db.EM_CINE.AsNoTracking()
                                 where a.ESTADO == Estados.Estados.ACTIVO
                                 select new Cine
                                 {
                                     NOMBRECOMPLEJO = a.NOMBRECOMPLEJO,
                                     ESTADO = a.ESTADO,
                                     IDCINE = a.IDCINE,
                                     RUC = a.RUC,
                                 }).ToList();
                   
                }
            }
            catch
            {
                Consultar = new List<Cine>();
            }

            return Consultar;
        }

        public string ActualizarTablaCatalogo(int numeroEntradas, int idPelicula)
        {
            string mensaje = "";
            try
            {
                using (Cn_S73Entities db = new Cn_S73Entities())
                {
                    int EntradasDispo = db.EM_CATALOGO.Where(x => x.IDPELICULA == idPelicula).Select(x => x.NUMEROENTRADASDISPO).FirstOrDefault() - numeroEntradas ?? 0;
                    //int EntradasDisponibles = EntradasDispo ?? 0 - numeroEntradas;
                    EM_CATALOGO catalogo = new EM_CATALOGO();
                    catalogo.IDPELICULA = idPelicula;
                    catalogo.NUMEROENTRADASDISPO = EntradasDispo;
                    db.EM_CATALOGO.Add(catalogo);
                    db.SaveChanges();
                    mensaje = "ok";

                }
            }catch(Exception ex)
            {
                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string IngrsarVentas(Ventas Datos)
        {
            string mensaje = "";
            try
            {
               

                using (Cn_S73Entities db = new Cn_S73Entities())
                {
                    EM_TABLAVENTAS ventas = new EM_TABLAVENTAS();
                    ventas.NOMBRECLIENTE = Datos.NOMBRECLIENTE;
                    ventas.NUMEROENTRADAS = Datos.NUMEROENTRADAS;
                    ventas.IDPELICULA = Datos.IDPELICULA;
                    ventas.ID_SALA = Datos.ID_SALA;
                    ventas.TOTALPAGAR = Datos.TOTALPAGAR;
                    ventas.IDTIPOPELICULA = Datos.IDTIPOPELICULA;
                    db.EM_TABLAVENTAS.Add(ventas);
                    db.SaveChanges();
                    mensaje = "";
                      
                }

               mensaje =  ActualizarTablaCatalogo(Datos.NUMEROENTRADAS ?? 0, Datos.IDPELICULA ?? 0);
                if (mensaje == "ok")
                {
                    mensaje = "";
                }
                else
                {
                    mensaje = "La entrada se registro, pero la no se actualizo el numero de entradas Disponibles favor Revisar";
                }
               
            }
            catch(Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }

    }
}
