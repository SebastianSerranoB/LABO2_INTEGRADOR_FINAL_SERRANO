using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Interfaces
{
    public interface IAdministradorBaseDeDatos<T> 
    {
        T ObtenerElementoPorDNI(string dniElemento, string paqueteSeleccionado);

        List<T> ObtenerTodosLosElementos();

        bool AgregarNuevoElemento(T elemento);

        bool EliminarElementoPorDNI(string dniElemento, string paqueteSeleccionado);

      

    }

}
