using StorageApi.Models;

namespace StorageApi.Dto;

public class ProductDto(Product product)
{
        public int Id { get; set; } = product.Id;
        public string Name { get; set; } = product.Name;
        public int Price { get; set; } = product.Price;
        public string Category { get; set; } = product.Category;
        public string Shelf { get; set; } = product.Shelf;
        public int Count { get; set; } = product.Count;
        public string Description { get; set; } = product.Description;
}