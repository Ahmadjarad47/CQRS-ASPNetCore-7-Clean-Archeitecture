global using Ecommerce.Application.DTOs.EntitiesDto.Category.Validators;
global using Ecommerce.Application.Features.Categories.Requests.Command;
global using Ecommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Check Validator
            var response = new BaseCommandResponse();
            var valiator = new CategoryValidator();
            var validatorResult = await valiator.ValidateAsync(request.CategoryDto);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Falid While Creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var category = _mapper.Map<Category>(request.CategoryDto);
            await _repository.CreateAsync(category);
            response.Success = true;
            response.Message = "Sussfully While Creation";
            response.Id = category.Id;
            return response;
        }
    }
}
