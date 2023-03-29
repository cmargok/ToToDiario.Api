using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToToDiario.API.Domain.Entities;
using ToToDiario.API.Infrastructure.Persistence;
using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Notes")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Estado> estados = await _context.Estados.ToListAsync(new CancellationToken());


            if (estados.Count < 1)
            {
                return NoContent();
            }
            return Ok(estados);

        }

    }
}
