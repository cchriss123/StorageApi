using StorageApi.Models;

namespace StorageApi.Dto;

public class ProductDto
{
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Price { get; set; }
        public string Category { get; set; } = "";
        public string Shelf { get; set; } = "";
        public int Count { get; set; }
        public string Description { get; set; } = "";

        public ProductDto()
        {
        }

        public ProductDto(Product product)
        {
                Id = product.Id;
                Name = product.Name;
                Price = product.Price;
                Category = product.Category;
                Shelf = product.Shelf;
                Count = product.Count;
                Description = product.Description;
        }
}