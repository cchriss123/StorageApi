using StorageApi.Dto;
using StorageApi.Models;

namespace StorageApi.Mapper;

public static class ProductMapper
{
    
    //dto to prod
    public static Product Map(ProductDto dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Category = dto.Category,
            Shelf = dto.Shelf,
            Count = dto.Count
        };
    }
    
    public static ProductDto Map(Product product)
    {
        return new ProductDto(product);
    }
    
    public static List<ProductDto> Map(IEnumerable<Product> products)
    {
        return products.Select(Map).ToList();
    }
    
    
    
}