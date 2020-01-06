using MagicBean.Samples.CookieAuthentication.Models;
using MagicBean.Samples.CookieAuthentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MagicBean.Samples.CookieAuthentication.Pages
{
    public class AuthorizeModel : PageModel
    {
        private readonly IUserService _authService;
        private const string CredentialErrorMessage = "Invalid username or password!";
        
        public const string CredentialErrorKey = "CredentialError";

        [BindProperty]
        public ApplicationUser Credential { get; set; }

        public AuthorizeModel(IUserService userService)
        {
            _authService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromQuery(Name="ReturnUrl")]string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var isValidUser = await _authService.IsValidUserAsync(Credential);

            if (isValidUser)
            {
                var authSchema = CookieAuthenticationDefaults.AuthenticationScheme;
                var principal = _authService.GenerateClaimsPrincipal(Credential, authSchema);
                await HttpContext.SignInAsync(authSchema, principal);

                var redirectUri = string.IsNullOrEmpty(returnUrl)? "Index": returnUrl;
                return RedirectToPage(redirectUri);
            }
            else
            {
                ViewData[CredentialErrorKey] = CredentialErrorMessage;
                ModelState.AddModelError(CredentialErrorKey, CredentialErrorMessage);
                return Page();
            }
        }
    }
}
