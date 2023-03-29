using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToToDiario.API.Application.Models;
using ToToDiario.API.Application.NoteService;
using ToToDiario.API.Application.UserService;
using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }


        [HttpGet("{UserId}/Notes")]
        public async Task<IActionResult> GetAllAsync(int UserId)
        {
            var response = await _noteService.GetNotesAsync(UserId, new CancellationToken());

            if (response.Result == ResultStatus.Success)
            {
                return Ok(response);
            }
            else if (response.Result == ResultStatus.NoRecords)
            {
                return NoContent();
            }
            return NotFound("User NotFound.");
        }


        [HttpGet("{UserId}/Notes/{NoteId}")]
        public async Task<IActionResult> GetOneNoteAsync(int UserId, int NoteId)
        {
            var response = await _noteService.GetOneNoteAsync(UserId, NoteId, new CancellationToken());

            if (response.Result == ResultStatus.Success)
            {
                return Ok(response);
            }else if (response.Result == ResultStatus.NoRecords)
            {
                return NoContent();
            }
            return NotFound("User NotFound.");
        }

        [HttpPost("AddNote")]
        public async Task<IActionResult> AddNoteAsync(int UserId, AddNoteBaseDto newNota)
        {
            var response = await _noteService.AddNoteUserAsync(UserId, newNota, new CancellationToken());


            if (response.Result == ResultStatus.Success)
            {
                return Created($"{UserId}/Notes/{response.NotaId}", response);
            }else if(response.Result == ResultStatus.NotCreated)
            {
                return BadRequest();

            }
            return NotFound("User NotFound.");

        }
    }
}
