using Microsoft.AspNetCore.Identity;

namespace Micrioservice.api.Seguridad.Core.Entities
{
    public class Usuario: IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }

    }
}
