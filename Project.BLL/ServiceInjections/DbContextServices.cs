
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Dal.ContextClasses;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class DbContextServices
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection service)
        {
            ServiceProvider provider = service.BuildServiceProvider();
            IConfiguration? configuration = provider.GetService<IConfiguration>();
            service.AddDbContextPool<MyContext>(x => x.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
            return service;
        }
    }
}
