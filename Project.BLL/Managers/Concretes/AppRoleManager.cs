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
    public class AppRoleManager : BaseManager<AppRole>,IAppRoleManager
    {
        public AppRoleManager(IRepository<AppRole> iRep) : base(iRep)
        {
        }
    }
}
