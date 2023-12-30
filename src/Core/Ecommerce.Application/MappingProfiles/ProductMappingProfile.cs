using Ecommerce.Application.DTOs.EntitiesDto.Product;

namespace Ecommerce.Application.MappingProfiles;

public class ProductMappingProfile:Profile
{
	public ProductMappingProfile()
	{
		CreateMap<Product, ProductDto>().ReverseMap();
	}

}
