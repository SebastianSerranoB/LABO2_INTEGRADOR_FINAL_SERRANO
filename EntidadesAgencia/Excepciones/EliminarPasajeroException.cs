using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Excepciones
{
    /// <summary>
    /// Excepción personalizada para errores relacionados con la eliminacion de un pasajero en una lista.
    /// </summary>
    public class EliminarPasajeroException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase  con un mensaje específico.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        public EliminarPasajeroException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase  con un mensaje de error específico
        /// y una referencia a la excepción interna que generó esta excepción.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        /// <param name="innerException">Excepción interna que causó esta excepción.</param>
        public EliminarPasajeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
