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
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();

            //CreateMap<Book, BookDTO>().ForMember(x => x.AuthorName, org => org.MapFrom(x => x.Author.AuthorName)).ForMember(x => x.ShelfNo, org => org.MapFrom(x => x.BookShelf.ShelfNo)).ForMember(x => x.CategoryName, org => org.MapFrom(x => x.Category.CategoryName)).ForMember(x => x.EditorName, org => org.MapFrom(x => x.Editor.EditorName)).ReverseMap();

        }
    }
}
