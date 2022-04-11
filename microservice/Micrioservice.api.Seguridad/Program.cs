using Micrioservice.api.Seguridad.Core.Entities;
using Micrioservice.api.Seguridad.Core.Persistence;
using Microservice.api.Seguridad.Core.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micrioservice.api.Seguridad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var hostServer = CreateHostBuilder(args).Build();
            using (var contexto = hostServer.Services.CreateScope())
            {
                var services = contexto.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var _contextEF = services.GetRequiredService<SeguridadContexto>();

                    SeguridadData.InsertarUsuario(_contextEF, userManager).Wait();
                }catch (Exception ex)
                {
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(ex, "error cuando registra usuario");
                }
                hostServer.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
