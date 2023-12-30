using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Categories.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Check Validator
            var valiator = new CategoryValidator();
            var validatorResult = await valiator.ValidateAsync(request.CategoryDto);
            if (validatorResult.IsValid == false)
                throw new ValidationExecption(validatorResult);

            var oldCategory = await _repository.GetAsync(request.CategoryDto.Id);
            var res = _mapper.Map(request.CategoryDto, oldCategory);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
