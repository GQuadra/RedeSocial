namespace RedeSocial.Core.Exceptions;

public class UsuarioException : Exception
{
    public UsuarioException()
    {
    }

    public UsuarioException(string message) : base(message)
    {
    }
}