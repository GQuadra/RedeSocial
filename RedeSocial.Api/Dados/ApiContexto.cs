using Microsoft.EntityFrameworkCore;
using RedeSocial.Core.Entidades;

namespace RedeSocial.Api.Dados;

public class ApiContexto(DbContextOptions<ApiContexto> opcoesContexto) : DbContext(opcoesContexto)
{
    public DbSet<Usuario> Usuarios { get; set; }
}