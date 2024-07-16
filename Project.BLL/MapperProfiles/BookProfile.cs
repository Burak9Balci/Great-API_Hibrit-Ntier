using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.RequestModels.Book;
using Project.BLL.ResponseModels.Book;
using Project.Entities.Models;
using Project.VM.Models;
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
            CreateMap<BookCreateRequestModel, BookDTO>().ReverseMap();
            CreateMap<BookUpdateRequestModel, BookDTO>().ReverseMap();
            CreateMap<BookResponseModel, BookDTO>().ReverseMap();
            CreateMap<BookVM, BookDTO>().ReverseMap();

        }
    }
}
