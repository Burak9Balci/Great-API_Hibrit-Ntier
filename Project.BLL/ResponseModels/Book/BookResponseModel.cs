using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ResponseModels.Book
{
    public class BookResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int CategoryID { get; set; }
        public int BookShelfID { get; set; }
        public int EditorID { get; set; }
        public int AuthorID { get; set; }

    }
}
