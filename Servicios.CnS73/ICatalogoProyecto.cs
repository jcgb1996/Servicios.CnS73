using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios.CnS73
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICatalogoProyecto
    {
        [OperationContract]
        string GetData();
        [OperationContract]
        List<Catalogo> Datos();

        [OperationContract]
        List<TipoPelicula> ConsultarTipoPelicula();
        [OperationContract]
        List<Salas> ConsultarSala();
        [OperationContract]
        void saludar();

    }

    
}
