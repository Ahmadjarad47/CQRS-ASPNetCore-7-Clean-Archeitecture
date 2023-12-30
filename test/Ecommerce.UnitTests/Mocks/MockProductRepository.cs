using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            #region MockData
            var products = new List<Product>
            {
                new Product{Id=1,Name="p1",Price=500,CategoryId = 1},
                new Product{Id=2,Name="p2",Price=700,CategoryId = 1},
            };
            #endregion

            //object moqrepo
            var moqrepo = new Mock<IProductRepository>();

            //get all products
            moqrepo.Setup(x=>x.GetAllAsync()).ReturnsAsync(products);
            //create new product
            moqrepo.Setup(x => x.CreateAsync(It.IsAny<Product>())).Returns((Product product) =>
            {
                products.Add(product);
                return Task.CompletedTask;
            });
            return moqrepo;
        }
    }
}
