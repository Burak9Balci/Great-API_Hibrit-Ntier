using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTOClasses.Concretes
{
    public class BookDTO : BaseDTO
    {

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int AuthorID { get; set; }
        public int BookShelfID { get; set; }
        public int CategoryID { get; set; }
        public int EditorID { get; set; }
        public string AuthorName { get; set; }
        public string ShelfNo { get; set; }
        public string CategoryName { get; set; }
        public string EditorName { get; set; }

    }
}
