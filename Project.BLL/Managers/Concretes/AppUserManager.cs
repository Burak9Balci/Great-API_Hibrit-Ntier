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
        readonly SignInManager<AppUser> _signInManager;
      
        public AppUserManager(IRepository<AppUser> iRep, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(iRep, mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task AddRoleToUserAsync(AppUserDTO appUser, string role)
        { 
            await _userManager.AddToRoleAsync(_mapper.Map<AppUser>(appUser), role);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUserDTO appUser)
        {
           return await _userManager.CreateAsync(_mapper.Map<AppUser>(appUser), appUser.NormalizedUserPassword);
        }

        public async Task<AppUser> FindUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IList<string>> GetRolesFromUserAsync(AppUserDTO appUserDTO)
        {
            AppUser user = _mapper.Map<AppUser>(appUserDTO);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<SignInResult> SignInAsync(AppUserDTO appUserDTO, string password, bool isPersistent, bool lockoutOnFailure)
        {
            AppUser user = await FindUserByNameAsync(appUserDTO.NormalizedUserName);
            return await _signInManager.PasswordSignInAsync(user,password,isPersistent,lockoutOnFailure);
        }
    }
}
