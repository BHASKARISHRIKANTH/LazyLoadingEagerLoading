using LazyLoadingEagerLoading.Data;
using LazyLoadingEagerLoading.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LazyLoadingEagerLoading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Eager Loading Endpoint
        [HttpGet("eager")]
        public async Task<IActionResult> GetCategoriesWithProductsEager()
        {
            var categories = await _context.Categories
                .Include(c => c.Products)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = c.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                       Name = p.Name
                    }).ToList()
                }).ToListAsync();

            return Ok(categories);
        }

        // Lazy Loading Endpoint with DTO
        [HttpGet("lazy")]
        public async Task<IActionResult> GetCategoriesLazy()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = c.Products.Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList()
                }).ToListAsync();

            return Ok(categories);
        }
    }
}
