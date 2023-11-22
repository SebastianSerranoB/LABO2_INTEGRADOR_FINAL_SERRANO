using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Excepciones
{
    public class ManejoDeArchivosException : Exception
    {
        public ManejoDeArchivosException(string? message) : base(message)
        {
        }

        public ManejoDeArchivosException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
