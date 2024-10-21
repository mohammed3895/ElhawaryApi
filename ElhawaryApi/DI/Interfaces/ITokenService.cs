using Microsoft.AspNetCore.Identity;

namespace ElhawaryApi.DI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
