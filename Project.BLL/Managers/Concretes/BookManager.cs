using AutoMapper;
using Project.BLL.DTOClasses.Concretes;
using Project.BLL.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class BookManager : BaseManager<Book,BookDTO>, IBookManager
    {
        public BookManager(IRepository<Book> iRep,IMapper map) : base(iRep,map)
        {
        }
    }
}
