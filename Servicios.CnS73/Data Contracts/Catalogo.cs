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
        public int IDTIPOPELICULA { get; set; }
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
        [DataMember]
        public Nullable<int> IDSALA { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FECHADESDE { get; set; }
        [DataMember]
        public Nullable<System.DateTime> FECHAHASTA { get; set; }
        [DataMember]
        public Nullable<decimal> HORADESDE { get; set; }
        [DataMember]
        public Nullable<decimal> HORAHASTA { get; set; }
        [DataMember]
        public Nullable<int> NUMEROENTRADAS { get; set; }
        [DataMember]
        public Nullable<int> IDFUNCION { get; set; }
        [DataMember]
        public Nullable<int> NUMEROENTRADASDISPO { get; set; }
    }

    [DataContract]
    [Serializable]
    public class Salas
    {
        [DataMember]
        public int IDSALA { get; set; }
        [DataMember]
        public string DESCRIPCION { get; set; }
        [DataMember]
        public string ESTADO { get; set; }

    }

    [DataContract]
    [Serializable]
    public class TipoPelicula
    {
        [DataMember]
        public int IDTIPOPELICULA { get; set; }
        [DataMember]
        public string DESCRIPCION { get; set; }
        [DataMember]
        public string ESTADO { get; set; }
    }
}
