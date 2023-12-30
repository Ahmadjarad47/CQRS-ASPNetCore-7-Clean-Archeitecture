using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Products.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _repository.GetAsync(request.Id);
            if(oldProduct is null)
                throw new NotFoundExecption(nameof(Product),request.Id);

            await _repository.DeleteAsync(oldProduct.Id);
            return Unit.Value;
        }
    }
}
