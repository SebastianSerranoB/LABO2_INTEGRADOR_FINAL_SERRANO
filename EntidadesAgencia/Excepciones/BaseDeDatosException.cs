using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAgencia.Excepciones
{
    public class BaseDeDatosException : Exception
    {
        public BaseDeDatosException(string? message) : base(message)
        {

        }

        public BaseDeDatosException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
   
    
    }
}
