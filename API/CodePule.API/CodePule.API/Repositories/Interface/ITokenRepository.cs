using Microsoft.AspNetCore.Identity;

namespace CodePule.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
