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
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserVM, AppUserDTO>().ReverseMap();
            CreateMap<AppUserDTO,AppUser>().ReverseMap();
            CreateMap<AppUserDTO,LoginAppUserVM>().ReverseMap();
            CreateMap<AppUserDTO,RegisterAppUserVM>().ReverseMap();
      
        }
    }
}
