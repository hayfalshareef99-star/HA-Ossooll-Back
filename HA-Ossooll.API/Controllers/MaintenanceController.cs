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
    public class MaintenanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaintenanceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.Maintenances
                .Include(m => m.Storage)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _context.Maintenances
                .Include(m => m.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Maintenance model)
        {
            _context.Maintenances.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Maintenance model)
        {
            var existing = await _context.Maintenances.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Date = model.Date;
            existing.Cost = model.Cost;
            existing.StorageId = model.StorageId;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var item = await _context.Maintenances.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Maintenances.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}