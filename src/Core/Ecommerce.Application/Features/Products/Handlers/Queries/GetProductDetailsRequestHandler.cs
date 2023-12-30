using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDto.Product;
using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Features.Products.Handlers.Queries
{
    public class GetProductDetailsRequestHandler : IRequestHandler<GetProductDetailsRequest, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductDetailsRequestHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetAsync(request.Id);
            if (product is null)
                throw new NotFoundExecption(nameof(Product), request.Id);
            var response = _mapper.Map<ProductDto>(product);
            return response;

        }
    }
}
