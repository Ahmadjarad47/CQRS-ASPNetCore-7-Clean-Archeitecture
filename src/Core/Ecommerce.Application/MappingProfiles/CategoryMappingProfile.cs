using AutoMapper;
using Ecommerce.Application.DTOs.EntitiesDto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.MappingProfiles
{
    public class CategoryMappingProfile:Profile
    {
        public CategoryMappingProfile()
        {
            // Configure Automapper 
            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
