
using System.ComponentModel.DataAnnotations;

namespace MagicBean.Samples.CookieAuthentication.Models
{
    public class ApplicationUser
    {
        [Required, MinLength(4), MaxLength(12)]
        public string Username { get; set; }

        [Required, MinLength(8), MaxLength(16)]
        public string Password { get; set; }
    }
}
