using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.RequestModels.Author;
using Project.BLL.ResponseModels.Author;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.MapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author,AuthorDTO>().ReverseMap();
            CreateMap<AuthorCreateRequestModel,AuthorDTO>().ReverseMap();
            CreateMap<AuthorUpdateRequestModel, AuthorDTO>().ReverseMap();
            CreateMap<AuthorResponseModel, AuthorDTO>().ReverseMap();

        }
    }
}
