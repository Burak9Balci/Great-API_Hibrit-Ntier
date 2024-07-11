using Microsoft.EntityFrameworkCore;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.ExtentionClasses
{
    public static class BookExtention
    {
        public static void SeedBook(ModelBuilder model)
        {
            Book b = new()
            {
                ID = 1,
                Name = "Ateş ve Kan",
                UnitPrice = 22,
                AuthorID = 1,
            };
            model.Entity<Book>().HasData(b);
        }

    }
}
