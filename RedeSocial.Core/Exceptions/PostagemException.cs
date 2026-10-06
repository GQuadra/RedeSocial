namespace RedeSocial.Core.Exceptions;

public class PostagemException : Exception
{
    public PostagemException()
    {
    }

    // Metodo construtor que recebe uma mensagem e passa adiante para a classe Pai
    public PostagemException(string message) : base(message)
    {
    }
}