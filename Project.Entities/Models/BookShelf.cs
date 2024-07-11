using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class BookShelf : BaseEntity
    {
        public short ShelfNo { get; set; }
        //RS
        public virtual ICollection<Book> Books { get; set; }
    }
}
