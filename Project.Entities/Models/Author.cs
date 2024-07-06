using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Author : BaseEntity
    {
        public string AuthorName { get; set; }
        //RS
        public virtual ICollection<Book> Books { get; set; }
    }
}
