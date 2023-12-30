using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDto.Product;

namespace Ecommerce.Application.Features.Products.Handlers.Queries
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsRequestHandler(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
         =>  _mapper.Map<List<ProductDto>>(await _repository.GetAllAsync());
    }
}
