using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Excepciones
{
    public class EliminarPasajeroException : Exception
    {
        public EliminarPasajeroException(string? message) : base(message)
        {
        }

        public EliminarPasajeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
