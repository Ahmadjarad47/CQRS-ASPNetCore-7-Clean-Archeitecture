using Ecommerce.Application.DTOs.EntitiesDto.Category;

namespace Ecommerce.Application.Features.Categories.Handlers.Query;

public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<CategoryDto>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesRequestHandler(ICategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetAllAsync();
        var res = _mapper.Map<List<CategoryDto>>(category);
        return res;
    }
}
