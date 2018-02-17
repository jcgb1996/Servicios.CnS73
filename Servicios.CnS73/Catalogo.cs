using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.CnS73
{
    [DataContract]
    [Serializable]
    public class Catalogo
    {        
       [DataMember]
        public int IDPELICULA { get; set; }
        [DataMember]
        public string NOMBRE { get; set; }
        [DataMember]
        public string APODO { get; set; }
        [DataMember]
        public string CODIGOPILI { get; set; }
        [DataMember]
        public string ESTADO { get; set; }
        [DataMember]
        public string TIPOPELICULA { get; set; }
        [DataMember]
        public string URL { get; set; }
    }
}
