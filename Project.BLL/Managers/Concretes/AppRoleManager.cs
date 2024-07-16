using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class AppRoleManager : BaseManager<AppRole, AppRoleDTO>, IAppRoleManager
    {
        readonly RoleManager<AppRole> _roleManager;

        

        public AppRoleManager(IRepository<AppRole> iRep, IMapper mapper, RoleManager<AppRole> roleManager) : base(iRep,mapper)
        {
            _roleManager = roleManager;
        }

        public async Task<AppRole> FindRoleAsync(string role)
        {
            if (await _roleManager.FindByNameAsync(role) == null)
            {
                await _roleManager.CreateAsync(new() { Name = role });
            }
            return await _roleManager.FindByNameAsync(role);
        }
    }
}
