using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO.ServiceInjection
{
    public static class MapperService
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration =  new MapperConfiguration(x =>
            {
                x.AddProfile();
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
