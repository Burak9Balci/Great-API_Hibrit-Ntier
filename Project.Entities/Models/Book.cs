using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Book : BaseEntity
    {
        public Book()
        {
          
        }
        public override string ToString()
        {
            return Name;

        }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int? CategoryID { get; set; }
        public int? AuthorID { get; set; }
        public int? BookShelfID { get; set; }
        public int? EditorID { get; set; }

        //Rs
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual BookShelf BookShelf { get; set; }
        public virtual Editor Editor { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
