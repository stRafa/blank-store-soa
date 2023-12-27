namespace BS.WebAPI.Core.Usuario
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this System.Security.Claims.ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));
            var claim = principal.FindFirst("sub");
            return claim?.Value;
        }
        public static string GetUserEmail(this System.Security.Claims.ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));
            var claim = principal.FindFirst(System.Security.Claims.ClaimTypes.Email);
            return claim?.Value;
        }
        public static string GetUserToken(this System.Security.Claims.ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));
            var claim = principal.FindFirst("JWT");
            return claim?.Value;
        }
        public static string GetUserRefreshToken(this System.Security.Claims.ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentException(nameof(principal));
            var claim = principal.FindFirst("RefreshToken");
            return claim?.Value;
        }
    }
}
