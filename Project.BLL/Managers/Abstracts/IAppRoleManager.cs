using Microsoft.AspNetCore.Identity;
using Project.BLL.DTOClasses.Concretes;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IAppRoleManager : IManager<AppRole,AppRoleDTO>
    {
        public Task<AppRole> FindRoleAsync(string role);

    }
}
