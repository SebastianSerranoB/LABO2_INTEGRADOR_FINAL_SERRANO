using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Interfaces
{
    /// <summary>
    /// Define operaciones básicas para administrar elementos genéricos en una base de datos.
    /// </summary>
    /// <typeparam name="T">Tipo de elemento a administrar.</typeparam>
    public interface IAdministradorBaseDeDatos<T> 
    {
        /// <summary>
        /// Obtiene un elemento por su número de documento de identidad (DNI) y el paquete seleccionado(EPaquetesViaje).
        /// </summary>
        /// <param name="dniElemento">Número de documento de identidad del elemento.</param>
        /// <param name="paqueteSeleccionado">Paquete seleccionado relacionado con el elemento.</param>
        /// <returns>Retorna el elemento si coincide con dniElemento.</returns>
        T ObtenerElementoPorDNI(string dniElemento, string paqueteSeleccionado);

        /// <summary>
        /// Obtiene todos los elementos almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de todos los elementos almacenados.</returns>
        List<T> ObtenerTodosLosElementos();

        /// <summary>
        /// Agrega un nuevo elemento a la base de datos.
        /// </summary>
        /// <param name="elemento">Elemento a agregar.</param>
        /// <returns>True si se agregó correctamente; de lo contrario, False.</returns>
        bool AgregarNuevoElemento(T elemento);

        /// <summary>
        /// Elimina un elemento por su número de documento de identidad (DNI) y el paquete seleccionado.
        /// </summary>
        /// <param name="dniElemento">Número de documento de identidad del elemento a eliminar.</param>
        /// <param name="paqueteSeleccionado">Paquete seleccionado relacionado con el elemento.</param>
        /// <returns>True si se eliminó correctamente; de lo contrario, False.</returns>
        bool EliminarElementoPorDNI(string dniElemento, string paqueteSeleccionado);

    }

}
