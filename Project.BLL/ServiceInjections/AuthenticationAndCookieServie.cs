using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class AuthenticationAndCookieServie
    {
        public static void AddAuthenticationAndCookieService(this IServiceCollection service)
        {
            service.AddAuthentication("Identity.Application").AddCookie("Identity.Application", options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
                options.Cookie.Name = "Ozzy";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.LoginPath = new PathString("/Home/Login");

            });

        }
    }
}
