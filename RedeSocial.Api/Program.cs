using Microsoft.EntityFrameworkCore;
using RedeSocial.Api.Dados;
using RedeSocial.Api.DTOs;
using RedeSocial.Core.Entidades;
using RedeSocial.Core.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var stringConexao = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMySql<ApiContexto>(stringConexao, ServerVersion.AutoDetect(stringConexao));

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapGet("/status", () =>
{
    return Results.Ok(new
    {
        Status = "online"
    });
});

app.MapPost("/usuario", (CadastroUsuarioDto requisicao) =>
{
    try
    {
        var novoUsuario = new Usuario(requisicao.Nome, requisicao.Email, requisicao.Senha);
        return Results.Created(string.Empty, new
        {
            Usuario = requisicao
        });
    }
    catch (CoreException ex)
    {
        return Results.BadRequest(new { Mensagem = ex.Message });
    }
});

app.Run();