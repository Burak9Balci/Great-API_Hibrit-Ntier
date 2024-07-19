using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class CookieService
    {
        public static void AddCookieService(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.HttpOnly = true;
                x.ExpireTimeSpan = TimeSpan.FromDays(1);
                x.SlidingExpiration = true;
                x.Cookie.Name = "Ozzy";
                x.Cookie.SameSite = SameSiteMode.Strict;
                x.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            });
        }
    }
}
