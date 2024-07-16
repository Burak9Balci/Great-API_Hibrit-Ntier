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
    public class AppUserManager : BaseManager<AppUser, AppUserDTO>, IAppUserManager
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;

        public AppUserManager(IRepository<AppUser> iRep, IMapper mapper, UserManager<AppUser> userManager) : base(iRep, mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task AddRoleToUserAsync(AppUserDTO appUser, string role)
        { 
            await _userManager.AddToRoleAsync(_mapper.Map<AppUser>(appUser), role);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUserDTO appUser)
        {
           return await _userManager.CreateAsync(_mapper.Map<AppUser>(appUser), appUser.NormalizedUserPassword);
        }

        
    }
}
