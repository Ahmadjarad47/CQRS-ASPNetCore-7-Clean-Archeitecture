using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Configurations.Entities
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product(1,"product one", "desciption one", 150, 1),
                new Product(2,"product two", "desciption two", 300, 2),
                new Product(3,"product three", "desciption three", 900, 1));
        }
    }
}
