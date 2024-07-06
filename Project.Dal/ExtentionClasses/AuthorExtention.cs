using Microsoft.EntityFrameworkCore;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.ExtentionClasses
{
    public static class AuthorExtention
    {
        public static void SeedAuthor(ModelBuilder builder)
        {
            Author a = new()
            {
                ID = 1,
                AuthorName = "J.R.R Martin",

            };
            builder.Entity<Author>().HasData(a);
        }
    }
}
