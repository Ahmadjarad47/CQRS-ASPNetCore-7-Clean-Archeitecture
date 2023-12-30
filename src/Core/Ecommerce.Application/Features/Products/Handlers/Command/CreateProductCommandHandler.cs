using Ecommerce.Application.DTOs.EntitiesDto.Product.Validators;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Application.Models.Email;
using Ecommerce.Application.Persistance.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper
            , IEmailSender emailSender
            )
        {
            _repository = repository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //check Validator
            var response = new BaseCommandResponse();

            var validator = new ProductValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.ProductDto, cancellationToken);
            if (validatorResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Falid While Creation";
                response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var product = _mapper.Map<Product>(request.ProductDto);
            await _repository.CreateAsync(product);
            response.Success = true;
            //response.Message = "Sussfully While Creation";
            response.Id = product.Id;

            //Send Email New Product
            try
            {
                var email = new EmailMessage
                {
                    To = "mroshdi000@gmail.com",
                    Subject = "Send Email Sussfully !",
                    Body = $"Now Uploding New Product -{request.ProductDto.Name}"
                };
                var result = await _emailSender.SendEmail(email);
                if (result)
                {
                    response.Message = "Succssfully Send Email";
                }
                else
                {
                    response.Message = "Faild To Send Email";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }
    }
}
