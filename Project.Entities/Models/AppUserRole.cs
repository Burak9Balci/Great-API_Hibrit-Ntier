using Microsoft.AspNetCore.Identity;
using Project.Entities.Enums;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public AppUserRole()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        //RS
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
