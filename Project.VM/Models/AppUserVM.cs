using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.Models
{
    public class AppUserVM : BaseVM
    {
        public virtual string? UserName { get; set; }
        public virtual string? NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string NormalizedUserPassword { get; set; }
    }
}
