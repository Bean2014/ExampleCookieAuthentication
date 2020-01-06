using System.Security.Claims;
using System.Threading.Tasks;
using MagicBean.Samples.CookieAuthentication.Models;

namespace MagicBean.Samples.CookieAuthentication.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> IsValidUserAsync(ApplicationUser credential)
        {
            return await Task.FromResult(credential?.Password == "abcd1234" && credential?.Username == "admin");
        }

        public ClaimsPrincipal GenerateClaimsPrincipal(ApplicationUser credential, string schema)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, credential.Username),
                new Claim(ClaimTypes.MobilePhone, credential.Password)
            };
            var identity = new ClaimsIdentity(claims, schema);
            return new ClaimsPrincipal(identity);
        }
    }
}