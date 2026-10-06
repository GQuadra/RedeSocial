using System.Text.RegularExpressions;
using RedeSocial.Core.Exceptions;

namespace RedeSocial.Core.Entidades;

public class Usuario
{
    public Usuario(string nome, string email, string senha )
    {
        ValidarNome(nome);
        ValidarEmail(email);
        ValidarSenha(senha);
    }

    public const int MINIMO_TAMANHO_NOME = 3;
    public const int MINIMO_TAMANHO_SENHA = 8;

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string HashSenha { get; private set; }

    private void ValidarSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            throw new UsuarioException("A senha do usuário não pode ser nula ou estar vazia!");

        senha = senha.Trim();

        if (senha.Length < MINIMO_TAMANHO_SENHA)
            throw new UsuarioException($"A senha do usuário precisa conter no mínimo {MINIMO_TAMANHO_SENHA} caracteres!");

        HashSenha = senha;
    }

    private void ValidarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new UsuarioException("O email do usuário não pode ser nulo ou estar vazio!");
        
        email = email.Trim();
        
        if (!Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", RegexOptions.IgnoreCase))
            throw new UsuarioException("O email do usuário está inválido!");

        Email = email;
    }

    private void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new UsuarioException("O nome do usuário não pode ser nulo ou estar vazio!");
        
        nome = nome.Trim();
        
        if (Regex.IsMatch(nome, "/[^A-Za-zÀ-ÿ\\s]/gm", RegexOptions.IgnoreCase))
            throw new UsuarioException("O nome do usuário possui caracteres inválidos!");

        if (nome.Length < MINIMO_TAMANHO_NOME)
            throw new UsuarioException($"O nome do usuário deve conter no mínimo {MINIMO_TAMANHO_NOME} caracteres!");
        
        Nome = nome;
    }
}