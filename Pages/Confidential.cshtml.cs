using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicBean.Samples.CookieAuthentication.Pages
{
    [Authorize]
    public class ConfidentialModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
