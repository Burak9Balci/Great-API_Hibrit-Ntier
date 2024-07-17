using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTOClasses.Concretes
{
    public class AppUserDTO : BaseDTO

    { 
        public virtual string? UserName { get; set; }      
        public virtual string? NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string NormalizedUserPassword { get; set; }
        public string? NormalizedEmail { get; set; }
    }
}
