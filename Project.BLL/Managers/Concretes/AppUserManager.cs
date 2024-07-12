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
    public class AppUserManager : BaseManager<AppUser,AppUserDTO>,IAppUserManager
    {
        public AppUserManager(IRepository<AppUser> iRep, IMapper mapper) : base(iRep, mapper)
        {
        }

       
    }
}
