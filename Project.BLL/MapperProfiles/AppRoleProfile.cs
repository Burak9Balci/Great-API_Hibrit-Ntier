using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.Entities.Models;
using Project.VM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.MapperProfiles
{
    public class AppRoleProfile :Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole,AppRoleDTO>().ReverseMap();
            CreateMap<AppRoleVM,AppRoleDTO>();
        }
    }
}
