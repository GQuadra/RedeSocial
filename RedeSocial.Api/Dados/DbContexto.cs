using Microsoft.EntityFrameworkCore;
using RedeSocial.Core.Entidades;

namespace RedeSocial.Api.Dados;

public class DbContexto(DbContextOptions<DbContexto> opcoesContexto) : DbContext(opcoesContexto)
{
    public DbSet<Usuario> Usuarios { get; set; }
}