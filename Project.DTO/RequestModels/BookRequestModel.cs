using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO.RequestModels
{
    public class BookRequestModel
    {
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
}
