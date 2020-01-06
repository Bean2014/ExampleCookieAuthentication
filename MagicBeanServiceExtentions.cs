using MagicBean.Samples.CookieAuthentication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MagicBean.Samples.CookieAuthentication
{
    public static class MagicBeanServiceExtentions
    {
        public static IServiceCollection AddMagicBeanServices(this IServiceCollection services)
        {
            return services.AddScoped<UserService>()
                           .AddScoped<IUserService, UserService>();
        }
    }
}