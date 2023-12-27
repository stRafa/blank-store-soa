using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BS.WebAPI.Core.Usuario
{
    public interface IAspNetUser
    {
        string Name { get; }

        bool EstaAutenticado();
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
        string ObterUserEmail();
        Guid ObterUserId();
        string ObterUserRefreshToken();
        string ObterUserToken();
        bool PossuiClaim(string claimName, string claimValue);
        bool PossuiRole(string role);
    }
}
