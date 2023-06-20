using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p => p.Id).IsClustered(true);
            builder.Property(p=>p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p=>p.Stock).IsRequired();
            builder.Property(p => p.Price).HasPrecision(15,2);
            builder.Property(p=>p.UserId).IsRequired();

            builder.HasData(new Product
            {
                Id = 1,
                Name = "Test",
                Price = 10,
                Stock = 10,
                UserId = "1"
            });
        }
    }
}
