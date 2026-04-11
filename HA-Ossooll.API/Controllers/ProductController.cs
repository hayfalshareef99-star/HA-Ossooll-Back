using HA_Ossooll.Data.Data;
using HA_Ossooll.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HA_Ossooll.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Products
                .Include(p => p.Storage)
                .Include(p => p.ProductType)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _context.Products
                .Include(p => p.Storage)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product model)
        {
            _context.Products.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Product model)
        {
            var existing = await _context.Products.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = model.Name;
            existing.StorageId = model.StorageId;
            existing.ProductTypeId = model.ProductTypeId;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.Products.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Products.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}