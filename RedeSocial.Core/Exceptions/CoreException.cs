namespace RedeSocial.Core.Exceptions;

public class CoreException : Exception
{
    public CoreException()
    {
    }

    // Metodo construtor que recebe uma mensagem e passa adiante para a classe Pai
    public CoreException(string message) : base(message)
    {
    }
}