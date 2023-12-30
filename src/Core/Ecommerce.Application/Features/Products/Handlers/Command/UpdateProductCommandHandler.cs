using Ecommerce.Application.DTOs.EntitiesDto.Product.Validators;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Products.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //check Validator
            var validator = new ProductValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.ProductDto, cancellationToken);
            if (validatorResult.IsValid == false)
                throw new ValidationExecption(validatorResult);

            var oldProduct = await _repository.GetAsync(request.ProductDto.Id);
            var res = _mapper.Map(request.ProductDto, oldProduct);
            await _repository.UpdateAsync(res);
            return Unit.Value;
        }
    }
}
