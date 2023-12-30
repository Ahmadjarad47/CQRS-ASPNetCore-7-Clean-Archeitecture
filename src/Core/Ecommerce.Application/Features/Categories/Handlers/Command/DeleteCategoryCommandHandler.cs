using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Categories.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            //get category by id
            var oldCategory = await _repository.GetAsync(request.Id);  
            if(oldCategory is null)
                throw new NotFoundExecption(nameof(Category),request.Id);
            //remove
            await _repository.DeleteAsync(oldCategory.Id);
            return Unit.Value;
        }
    }
}
