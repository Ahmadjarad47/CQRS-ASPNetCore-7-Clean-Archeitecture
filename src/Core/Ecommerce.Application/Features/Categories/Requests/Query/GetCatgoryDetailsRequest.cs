using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.DTOs.EntitiesDto.Category;

namespace Ecommerce.Application.Features.Categories.Requests.Query
{
    public class GetCatgoryDetailsRequest:IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
