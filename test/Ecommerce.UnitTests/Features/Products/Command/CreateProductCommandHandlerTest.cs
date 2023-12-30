using AutoMapper;
using Ecommerce.Application.DTOs.EntitiesDto.Category;
using Ecommerce.Application.DTOs.EntitiesDto.Product;
using Ecommerce.Application.Features.Products.Handlers.Command;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Application.Persistance.Email;
using Ecommerce.Application.Responses;
using Ecommerce.UnitTests.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Features.Products.Command
{
    public class CreateProductCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _moqrepo;
        private readonly ProductDto _productDto;
        private readonly CreateProductCommandHandler _hadler;
        private readonly IEmailSender _sender;
        public CreateProductCommandHandlerTest()
        {
            _moqrepo = MockProductRepository.GetProductRepository();
            //configure mapper
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProductMappingProfile>();
            });
            _mapper = mapperconfig.CreateMapper();
            _hadler = new CreateProductCommandHandler(_moqrepo.Object, _mapper,_sender);
            _productDto = new ProductDto
            {
                Id = 3,
                Name = "p_3",
                Price = 20,
                CategoryId = 1
            };
        }
        [Fact]
        public async Task Invalid_Create_Product_Test()
        {
            _productDto.Price = -5;
            var result = await _hadler.Handle(new CreateProductCommand { ProductDto = _productDto }, CancellationToken.None);
            result.ShouldBeOfType<BaseCommandResponse>();
            var product = await _moqrepo.Object.GetAllAsync();
            product.Count.ShouldBe(2);
        }
    }
}
