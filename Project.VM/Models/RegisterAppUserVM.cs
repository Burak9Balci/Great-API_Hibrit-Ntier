using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.Models
{
    public class RegisterAppUserVM
    {
        public string ConfirmPassword { get; set; }
        public virtual string? Email { get; set; }
        public string Password { get; set; }
    }
}
