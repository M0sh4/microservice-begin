using Micrioservice.api.Seguridad.Core.Entities;
using Micrioservice.api.Seguridad.Core.Persistence;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.api.Seguridad.Core.Persistence
{
    public class SeguridadData
    {
        public static async Task InsertarUsuario(SeguridadContexto context, UserManager<Usuario> userManager)
        {
            if (! userManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre ="moshin",
                    Apellido = "moshin",
                    Direccion = "Av. La Madrid 369",
                    UserName = "moshin",
                    Email = "moshin@gmail.com"
                };
                await userManager.CreateAsync(usuario, "Password123$");
            }
        }
    }
}
