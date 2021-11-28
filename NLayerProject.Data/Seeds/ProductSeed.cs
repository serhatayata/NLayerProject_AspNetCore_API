using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product()
                {
                    ProductID = 1,
                    Name = "Pilot Kalem",
                    Price = 12.50m,
                    Stock=100,
                    CategoryID=_ids[0],
                },
                new Product()
                {
                    ProductID = 2,
                    Name = "Kurşun Kalem",
                    Price = 40.50m,
                    Stock = 60,
                    CategoryID = _ids[0],
                },
                new Product()
                {
                    ProductID = 3,
                    Name = "Tükenmez Kalem",
                    Price = 20.50m,
                    Stock = 150,
                    CategoryID = _ids[0],
                },
                new Product()
                {
                    ProductID = 4,
                    Name = "Küçük Boy Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryID = _ids[1],
                },
                new Product()
                {
                    ProductID = 5,
                    Name = "Orta Boy Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryID = _ids[1],
                },
                new Product()
                {
                    ProductID = 6,
                    Name = "Büyük Boy Defter",
                    Price = 22.50m,
                    Stock = 200,
                    CategoryID = _ids[1],
                }
                );
        }
    }
}
