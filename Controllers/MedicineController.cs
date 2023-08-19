using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen3U.Models;
using System.Net;

namespace Examen3U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MedicineController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var listMedicines = await _context.Medicines.ToListAsync();
            if (listMedicines == null || listMedicines.Count == 0)
            {
                return NoContent();
            }
            return Ok(listMedicines);
        }
        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Medicine medicine)
        {
            if (medicine == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(medicine);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Medicine medicine)
        {
            if (medicine == null)
            {
                return BadRequest(); //Error code 400
            }
            var entity = await _context.Medicines.FindAsync(medicine.Id);
            if (entity == null)
            {
                return NotFound(); //Error code 404
            }
            entity.Name = medicine.Name;
            entity.Description = medicine.Description;
            entity.RecommendedDose = medicine.RecommendedDose;
            entity.AdministrationForm = medicine.AdministrationForm;
            entity.Indications = medicine.Indications;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}