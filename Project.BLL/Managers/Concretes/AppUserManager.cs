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
        IRepository<AppUser> _iRep;



        public AppUserManager(IRepository<AppUser> iRep, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(iRep, mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _iRep = iRep;
        }

        public async Task AddRoleToUserAsync(AppUser appUser, string role)
        {
            await _userManager.AddToRoleAsync(appUser, role);
        }
        public async Task<string> MakeUserName(string mail)
        {
            int index = mail.IndexOf('@');
            return mail.Substring(0, index);
        }
        public async Task<IdentityResult> CreateUserAsync(AppUserDTO appUser)
        {

            appUser.UserName = await MakeUserName(appUser.Email);
            return await _userManager.CreateAsync(_mapper.Map<AppUser>(appUser), appUser.Password);
        }
        public async Task EmailConfirmAsync(AppUser user)
        {
            user.EmailConfirmed = true;
            await UpdateUserAsync(user);
        }
        public async Task<AppUser> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IList<string>> GetRolesFromUserAsync(AppUserDTO appUserDTO)
        {
            AppUser user = await FindUserByEmailAsync(appUserDTO.Email);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<SignInResult> SignInAsync(AppUserDTO appUserDTO, string password, bool isPersistent, bool lockoutOnFailure)
        {
            AppUser user = await FindUserByEmailAsync(appUserDTO.Email);
            return await _signInManager.PasswordSignInAsync(user,password,isPersistent,lockoutOnFailure);
        }

        public async Task UpdateUserAsync(AppUser appUser)
        {
            await _userManager.UpdateAsync(appUser);
        }
    }
}
