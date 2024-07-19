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
        public string Password { get; set; }
        public virtual string? Email { get; set; }
        public Guid ActivationCode { get; set; }
    }
}
