using Microsoft.AspNetCore.Identity;
using Project.Dal.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        UserManager<AppUser> _userManager;
        MyContext _db;
        public AppUserRepository(MyContext db, UserManager<AppUser> userManager) : base(db)
        {
            _userManager = userManager;
        
        }

        public async Task<bool> AddUser(AppUser user)
        {
            IdentityResult result  = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
               return false;
            }
        }
    }
}
