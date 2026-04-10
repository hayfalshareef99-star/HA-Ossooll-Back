using HA_Ossooll.Data.Data;
using HA_Ossooll.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HA_Ossooll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StorageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Storages.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _context.Storages.FindAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Storage model)
        {
            _context.Storages.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Storage model)
        {
            var existing = await _context.Storages.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = model.Name;
            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.Storages.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Storages.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}