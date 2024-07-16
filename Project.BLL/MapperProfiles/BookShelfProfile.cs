using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.RequestModels.Book;
using Project.BLL.RequestModels.BookShelf;
using Project.BLL.ResponseModels.BookShelf;
using Project.Entities.Models;
using Project.VM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.MapperProfiles
{
    public class BookShelfProfile : Profile
    {
        public BookShelfProfile()
        {
            CreateMap<BookShelf, BookShelfDTO>().ReverseMap();
            CreateMap<BookShelfUpdateRequestModel, BookShelfDTO>().ReverseMap();
            CreateMap<BookShelfCreateRequestModel, BookShelfDTO>().ReverseMap();
            CreateMap<BookShelfResponseModel, BookShelfDTO>().ReverseMap();
            CreateMap<BookShelfVM, BookShelfDTO>().ReverseMap();

        }
    }
}
