using System.Security.Claims;
using System.Threading.Tasks;
using MagicBean.Samples.CookieAuthentication.Models;

namespace MagicBean.Samples.CookieAuthentication.Services
{
    public interface IUserService
    {
         Task<bool> IsValidUserAsync(ApplicationUser credential);

         ClaimsPrincipal GenerateClaimsPrincipal(ApplicationUser credential, string schema);
    }
}