using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDto.Product;

namespace Ecommerce.Application.Features.Products.Requests.Commands
{
    public class CreateProductCommand:IRequest<BaseCommandResponse>
    {
        public ProductDto ProductDto { get; set; }
    }
}
