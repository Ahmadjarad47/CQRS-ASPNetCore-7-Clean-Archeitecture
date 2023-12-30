global using Ecommerce.Application.MappingProfiles;
using AutoMapper;
using Ecommerce.Application.DTOs.EntitiesDto.Category;
using Ecommerce.Application.Features.Categories.Handlers.Query;
using Ecommerce.Application.Features.Categories.Requests.Query;
using Ecommerce.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Features.Categories.Query
{
    public class GetAllCategoriesRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _moqrepo;
        public GetAllCategoriesRequestHandlerTest()
        {
            _moqrepo = MockCategoryRepository.GetCategoryRepository();
            //configure mapper
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryMappingProfile>();
            });
            _mapper = mapperconfig.CreateMapper();
        }

        [Fact]

        public async Task GetCategoryListTest()
        {
            var handler = new GetAllCategoriesRequestHandler(_moqrepo.Object, _mapper);
            var result = await handler.Handle(new GetAllCategoriesRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<CategoryDto>>();
        }
        [Fact]
        public async Task GetCategoryListCountTest()
        {
            var handler = new GetAllCategoriesRequestHandler(_moqrepo.Object, _mapper);
            var result = await handler.Handle(new GetAllCategoriesRequest(), CancellationToken.None);
            result.Count.ShouldBe(3);
        }
    }
}
