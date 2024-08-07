﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.VM.Models
{
    public class BookVM : BaseVM
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public int AuthorID { get; set; }
        public int BookShelfID { get; set; }
        public int CategoryID { get; set; }
        public int EditorID { get; set; }
        public int AuthorName { get; set; }
        public int ShelfNo { get; set; }
        public int CategoryName { get; set; }
        public int EditorName { get; set; }
    }
}
