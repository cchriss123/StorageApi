
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.Data;
using StorageApi.Dto;
using StorageApi.Mapper;

namespace StorageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(StorageContext context) : ControllerBase
    {
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct()
        {
            var products = await context.Product.ToListAsync();
            return Ok(ProductMapper.Map(products));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await context.Product.FindAsync(id);
            
            if (product == null)
            {
                return NotFound();
            }
            return new ProductDto(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            
            var product = ProductMapper.Map(dto);
            context.Entry(product).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto dto)
        {
            
            var product = ProductMapper.Map(dto);
            context.Product.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, new ProductDto(product));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            context.Product.Remove(product);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return context.Product.Any(e => e.Id == id);
        }
        
        [HttpGet("stats")]
        public async Task<int> AmountOfProducts()
        {
            return await context.Product.CountAsync();
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetProductBySearch(string? category, string? name)
        {
            return ProductMapper.Map(
                await context.Product
                    .Where(p => 
                        (category == null || p.Category == category) && 
                        (name == null || p.Name.Contains(name)))
                    .ToListAsync());
        }
        
    }
}
