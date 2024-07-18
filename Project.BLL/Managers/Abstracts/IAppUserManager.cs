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
    public interface IAppUserManager : IManager<AppUser,AppUserDTO>
    {
        //Register metotları
        Task AddRoleToUserAsync(AppUser appUser, string role);
        Task<IdentityResult> CreateUserAsync(AppUserDTO appUser);
        Task<AppUser> FindUserByNameAsync(string userName);
        Task<IList<string>> GetRolesFromUserAsync(AppUserDTO appUserDTO);
        Task<SignInResult> SignInAsync(AppUserDTO appUserDTO, string password, bool isPersistent, bool lockoutOnFailure);
        Task EmailConfirmAsync(AppUser appUser);

        //SignIn Metotları


    }
}
