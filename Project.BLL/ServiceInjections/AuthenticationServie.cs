using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class AuthenticationServie
    {
        public static void AddAuthenticationService(this IServiceCollection service)
        {
            service.AddAuthentication("Identity.Application").AddCookie("Identity.Application", options =>
            {
                options.LoginPath = "/Home/deneme";


            });

        }
    }
}
