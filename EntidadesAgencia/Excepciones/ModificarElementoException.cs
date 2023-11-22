using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Excepciones
{
    public class ModificarElementoException : Exception
    {
        public ModificarElementoException(string? message) : base(message)
        {
        }

        public ModificarElementoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
