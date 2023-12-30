using AutoMapper;
using Ecommerce.Application.DTOs.EntitiesDto.Category;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Categories.Handlers.Command;
using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Responses;
using Ecommerce.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Features.Categories.Command
{
    public class CreateCategoryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _moqrepo;
        private readonly CategoryDto _categoryDto;
        public CreateCategoryCommandHandlerTest()
        {
            _moqrepo = MockCategoryRepository.GetCategoryRepository();
            //configure mapper
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryMappingProfile>();
            });
            _mapper = mapperconfig.CreateMapper();
            _categoryDto = new CategoryDto
            {
                Id = 4,
                Name = "cat_fout"
            };
        }

        [Fact]
        public async Task CreateCategory()
        {
            var handler = new CreateCategoryCommandHandler(_moqrepo.Object, _mapper);
            var result = await handler.Handle(new CreateCategoryCommand { CategoryDto = _categoryDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            //var category = await _moqrepo.Object.GetAllAsync();
            //Assert.Equal(4, category.Count);
        }
        [Fact]
        public async Task CreateCategoryCountCheck()
        {
            var handler = new CreateCategoryCommandHandler(_moqrepo.Object, _mapper);
            var result = await handler.Handle(new CreateCategoryCommand { CategoryDto = _categoryDto }, CancellationToken.None);
            var category = await _moqrepo.Object.GetAllAsync();
            category.Count.ShouldBe(4);
        }
      
    }
}
