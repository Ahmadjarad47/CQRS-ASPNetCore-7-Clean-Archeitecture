global using Ecommerce.Application.Persistance.Contracts;
global using Moq;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Mocks
{
    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            #region MockData
            var categorries = new List<Category>
            {
                new Category{Id=1,Name="cat_one",Description="des_one"},
                new Category{Id=2,Name="cat_tow",Description="des_tow"},
                new Category{Id=3,Name="cat_three",Description="des_three"},
            };
            #endregion

            //object moqrepo
            var moqrepo = new Mock<ICategoryRepository>();
            //get all category
            moqrepo.Setup(x => x.GetAllAsync()).ReturnsAsync(categorries);

            // create category
            moqrepo.Setup(x => x.CreateAsync(It.IsAny<Category>())).Returns((Category category) =>
            {
                categorries.Add(category);
                return Task.CompletedTask;
            });
            return moqrepo;
        }
    }
}
