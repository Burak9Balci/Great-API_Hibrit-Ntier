using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.RequestModels.Book
{
    public class BookUpdateRequestModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public short? BookShelf { get; set; }
        public string EditorName { get; set; }
    }
}
