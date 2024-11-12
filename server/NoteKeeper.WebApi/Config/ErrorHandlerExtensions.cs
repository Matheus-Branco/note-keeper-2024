using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace NoteKeeper.WebApi.Config
{
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(builder =>
            {
                builder.Run(async httpContent =>
                {
                    var gerenciadorExcecoes = httpContent.Features.Get<IExceptionHandlerFeature>();

                    if (gerenciadorExcecoes is null) return;

                    httpContent.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContent.Response.ContentType = "application/json";

                    var objeto = new
                    {
                        Sucesso = false,
                        Erros = new string[] { "Erro interno do servidor" }
                    };

                    var respostaJson = JsonSerializer.Serialize(objeto);

                    await httpContent.Response.WriteAsync(respostaJson);
                });
            });
        }
    }
}
