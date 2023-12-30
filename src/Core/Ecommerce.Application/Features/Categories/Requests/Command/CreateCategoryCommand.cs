using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDto.Category;

namespace Ecommerce.Application.Features.Categories.Requests.Command
{
    public class CreateCategoryCommand:IRequest<BaseCommandResponse>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
