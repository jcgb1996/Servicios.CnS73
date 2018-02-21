using CnS73.Datos.Entidades;
using System;
using System.Collections.Generic;
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

        public List<Catalogo> Datos(){          
            try
            {
                using (Cn_S73Entities bd = new Cn_S73Entities())
                {
                    var datos = (from a in bd.EM_CATALOGO
                                 join b in bd.EM_TIPOPELICULA1 on a.IDTIPOPELICULA equals b.IDTIPOPELICULA
                                 where a.ESTADO == Estados.Estados.ACTIVO
                                 && b.ESTADO == Estados.Estados.ACTIVO
                                 select new Catalogo
                                 {
                                     IDPELICULA = a.IDPELICULA,
                                     APODO =  a.APODO,
                                     CODIGOPILI= a.CODIGOPILI,
                                     ESTADO= a.ESTADO,
                                     IDTIPOPELICULA = a.IDTIPOPELICULA ?? 0,
                                     TIPOPELICULA = b.DESCRIPCION,                                     
                                     NOMBRE = a.NOMBRE,
                                     URL = a.URL,
                                     IDSALA = a.IDSALA,
                                     FECHADESDE = a.FECHADESDE,
                                     FECHAHASTA = a.FECHAHASTA,
                                     HORADESDE= a.HORADESDE,
                                     HORAHASTA = a.HORAHASTA,
                                     NUMEROENTRADAS = a.NUMEROENTRADAS,
                                     NUMEROENTRADASDISPO = a.NUMEROENTRADASDISPO

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
    }
}
