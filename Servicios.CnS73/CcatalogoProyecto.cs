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
                                 select new Catalogo
                                 {
                                     IDPELICULA = a.IDPELICULA,
                                     APODO =  a.APODO,
                                     CODIGOPILI= a.CODIGOPILI,
                                     ESTADO= a.ESTADO,
                                     NOMBRE= a.NOMBRE,
                                     TIPOPELICULA= a.TIPOPELICULA,
                                     URL = a.URL
                                 }).ToList();
                    return datos;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

           

            }
       

      
    }
}
