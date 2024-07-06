using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepService(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            service.AddScoped<IBookRepository,BookRepository>();
            service.AddScoped<ICategoryRepository,CategoryRepository>();
            service.AddScoped<IAuthorRepository,AuthorRepository>();
            service.AddScoped<IAppRoleRepository,AppRoleRepository>();
            service.AddScoped<IAppUserRepository,AppUserRepository>();
            service.AddScoped<IAppUserRoleRepository,AppUserRoleRepository>();
            service.AddScoped<IBookShelfRepository,BookShelfRepository>();
            service.AddScoped<IEditorRepository,EditorRepository>();
            service.AddScoped<IOrderDetailRepository,OrderDetailRepository>();
            service.AddScoped<IOrderRepository,OrderRepository>();
            return service;
        }
    }
}
