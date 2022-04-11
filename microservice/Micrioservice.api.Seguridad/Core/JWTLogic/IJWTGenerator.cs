using Micrioservice.api.Seguridad.Core.Entities;

namespace Microservice.api.Seguridad.Core.JWTLogic
{
    public interface IJWTGenerator
    {
        string CreateToken(Usuario usuario);

    }
}
