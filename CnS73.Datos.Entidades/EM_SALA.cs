//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CnS73.Datos.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class EM_SALA
    {
        public EM_SALA()
        {
            this.EM_CATALOGO = new HashSet<EM_CATALOGO>();
        }
    
        public int IDSALA { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }
    
        public virtual ICollection<EM_CATALOGO> EM_CATALOGO { get; set; }
    }
}