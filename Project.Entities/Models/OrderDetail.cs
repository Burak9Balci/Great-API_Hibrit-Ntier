using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class OrderDetail : BaseEntity
    {
        public int BookID { get; set; }
        public int OrderID { get; set; }

        //RS
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
