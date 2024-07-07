﻿using AutoMapper;
using Project.DTO.DTOClasses;
using Project.DTO.RequestModels;
using Project.DTO.ResponseModels;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookResponseModel, BookDTO>().ReverseMap();
            CreateMap<BookRequestModel, BookDTO>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
        }
    }
}
