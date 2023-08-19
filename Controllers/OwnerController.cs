using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen3U.Models;
using System.Net;

namespace Examen3U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OwnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var listOwners = await _context.Owners.ToListAsync();
            if (listOwners == null || listOwners.Count == 0)
            {
                return NoContent();
            }
            return Ok(listOwners);
        }
        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest(); //Error code 400
            }
            var entity = await _context.Owners.FindAsync(owner.Id);
            if (entity == null)
            {
                return NotFound(); //Error code 404
            }

            entity.Name = owner.Name;
            entity.Surname = owner.Surname;
            entity.SecondSurname = owner.SecondSurname;
            entity.Address = owner.Address;
            entity.Email = owner.Email;
            entity.Phone = owner.Phone;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}