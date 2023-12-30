using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDto.Category;
using Ecommerce.Application.Exceptions;

namespace Ecommerce.Application.Features.Categories.Handlers.Query
{
    public class GetCatgoryDetailsRequestHandler : IRequestHandler<GetCatgoryDetailsRequest, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCatgoryDetailsRequestHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCatgoryDetailsRequest request, CancellationToken cancellationToken)
        {
            var category =await _repository.GetAsync(request.Id);
            if (category is null)
                throw new NotFoundExecption(nameof(Category),request.Id);
            return _mapper.Map<CategoryDto>(category);

        }
    }
}
