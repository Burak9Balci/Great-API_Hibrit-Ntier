using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.MapperProfiles
{
    public class EditorProfile : Profile
    {
        public EditorProfile()
        {
            CreateMap<Editor,EditorDTO>().ReverseMap();
        }
    }
}
