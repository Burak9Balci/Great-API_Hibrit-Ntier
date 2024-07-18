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
        public string Password { get; set; }
        public virtual string? Email { get; set; }
    }
}
