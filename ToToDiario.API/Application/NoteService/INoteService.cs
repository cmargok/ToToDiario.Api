using ToToDiario.API.Application.Models;

namespace ToToDiario.API.Application.NoteService
{
    public interface INoteService
    {
        public Task<NoteConfirmacion> AddNoteUserAsync(int UserId, AddNoteBaseDto newNota, CancellationToken ct);

        public Task<OneNoteDto> GetOneNoteAsync (int UserId, int NoteId, CancellationToken ct);

        public Task<UsersNotes> GetNotesAsync(int UserId, CancellationToken ct);
    }
}
