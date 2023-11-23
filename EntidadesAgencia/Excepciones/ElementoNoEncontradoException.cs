using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Excepciones
{
    /// <summary>
    /// Excepción personalizada para errores relacionados con la busqueda de un elemento en una lista.
    /// </summary>
    public class ElementoNoEncontradoException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase  con un mensaje específico.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        public ElementoNoEncontradoException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase  con un mensaje de error específico
        /// y una referencia a la excepción interna que generó esta excepción.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        /// <param name="innerException">Excepción interna que causó esta excepción.</param>
        public ElementoNoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
