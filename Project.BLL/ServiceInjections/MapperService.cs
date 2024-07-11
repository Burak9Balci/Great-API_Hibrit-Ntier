using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Project.BLL.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class MapperService
    {
        public static void AddMapperService(this IServiceCollection service)
        {
            MapperConfiguration configuration = new MapperConfiguration(x =>
            {

                x.AddProfile(new AuthorProfile());
                x.AddProfile(new BookProfile());
                x.AddProfile(new BookShelfProfile());
                x.AddProfile(new CategoryProfile());
                x.AddProfile(new EditorProfile());
            });
            IMapper mapper = configuration.CreateMapper();
            service.AddSingleton(mapper);
        }
    }
}
