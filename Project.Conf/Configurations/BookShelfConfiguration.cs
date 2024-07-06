using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Conf.Configurations
{
    public class BookShelfConfiguration : BaseConfiguration<BookShelf>
    {
        public override void Configure(EntityTypeBuilder<BookShelf> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Books).WithOne(x => x.BookShelf).HasForeignKey(x =>x.BookShelfID);
        }
    }
}
