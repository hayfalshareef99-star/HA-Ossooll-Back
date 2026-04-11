using HA_Ossooll.Data.Data;
using HA_Ossooll.Data.DTOs;
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
                .Include(m => m.Product)
                .ThenInclude(p => p.Storage)
                .Include(m => m.Product)
                .ThenInclude(p => p.ProductType)
                .Select(m => new MaintenanceDto
                {
                    Id = m.Id,
                    Date = m.Date,
                    Cost = m.Cost,
                    ProductId = m.ProductId,
                    ProductName = m.Product != null ? m.Product.Name : "",
                    StorageName = m.Product != null && m.Product.Storage != null ? m.Product.Storage.Name : "",
                    ProductTypeName = m.Product != null && m.Product.ProductType != null ? m.Product.ProductType.Name : ""
                })
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var item = await _context.Maintenances
                .Include(m => m.Product)
                .ThenInclude(p => p.Storage)
                .Include(m => m.Product)
                .ThenInclude(p => p.ProductType)
                .Where(m => m.Id == id)
                .Select(m => new MaintenanceDto
                {
                    Id = m.Id,
                    Date = m.Date,
                    Cost = m.Cost,
                    ProductId = m.ProductId,
                    ProductName = m.Product != null ? m.Product.Name : "",
                    StorageName = m.Product != null && m.Product.Storage != null ? m.Product.Storage.Name : "",
                    ProductTypeName = m.Product != null && m.Product.ProductType != null ? m.Product.ProductType.Name : ""
                })
                .FirstOrDefaultAsync();

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaintenanceDto model)
        {
            var maintenance = new Maintenance
            {
                Date = model.Date,
                Cost = model.Cost,
                ProductId = model.ProductId
            };

            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync();

            return Ok(maintenance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] MaintenanceDto model)
        {
            var existing = await _context.Maintenances.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Date = model.Date;
            existing.Cost = model.Cost;
            existing.ProductId = model.ProductId;

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