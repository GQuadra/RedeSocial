namespace RedeSocial.Core.Exceptions;

/// <summary>
/// Exceção customizada para a entidade usuário. Ela foi criada para facilitar a identificação de erros que darão apenas na validação da entidade usuário.
/// </summary>
public class UsuarioException : Exception
{
    public UsuarioException()
    {
    }

    // Metodo construtor que recebe uma mensagem e passa adiante para a classe Pai
    public UsuarioException(string message) : base(message)
    {
    }
}