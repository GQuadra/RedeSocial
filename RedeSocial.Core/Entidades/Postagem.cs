using RedeSocial.Core.Exceptions;

namespace RedeSocial.Core.Entidades;

public class Postagem
{
    protected Postagem()
    {
        
    }

    public Postagem(string conteudo, Usuario usuario)
    {
        ValidarConteudo(conteudo);
        Usuario = usuario;
        UsuarioId = usuario.Id;
        PostadoEm = DateTime.UtcNow;
    }
    
    public int Id { get; private set; }
    public string Conteudo { get; private set; }
    public DateTime PostadoEm { get; private set; }
    
    // Fazer referencia de usuario dentro das postagem
    public int UsuarioId { get; private set; }
    // Propriedade de navegação
    public Usuario Usuario { get; private set; }

    private void ValidarConteudo(string conteudo)
    {
        if (string.IsNullOrWhiteSpace(conteudo))
            throw new PostagemException("O conteudo da postagem não pode ser nulo ou estar vazio!");

        Conteudo = conteudo;
    }
}