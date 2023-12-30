using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDto.Category.Validators
{
    public class CategoryValidator:AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is Required !")
                .MinimumLength(3).WithMessage("{PropertyName} limit with 3 charcture .")
                .MaximumLength(50).WithMessage("{PropertyName} limit with 50 charcture .");
        }
    }
}
