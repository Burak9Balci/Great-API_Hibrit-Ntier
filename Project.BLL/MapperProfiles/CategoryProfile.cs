using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.RequestModels.Category;
using Project.BLL.ResponseModels.Category;
using Project.Entities.Models;
using Project.VM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<CategoryCreateRequestModel,CategoryDTO>().ReverseMap();
            CreateMap<CategoryUpdateRequestModel,CategoryDTO>().ReverseMap();
            CreateMap<CategoryResponseModel,CategoryDTO>().ReverseMap();
            CreateMap<CategoryVM,CategoryDTO>().ReverseMap();
            CreateMap<List<CategoryDTO>, Category>().ReverseMap();
        }
    }
}
