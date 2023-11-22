namespace Excepciones
{
    public class ElementoNoEncontradoException : Exception
    {
        public ElementoNoEncontradoException(string? message) : base(message)
        {
        }

        public ElementoNoEncontradoException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}