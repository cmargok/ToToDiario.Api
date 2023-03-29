using ToToDiario.API.Domain.Entities;

namespace ToToDiario.API.Application.InfrastructureContracts
{
    public interface INotaRepository
    {
        public Task<int> AddNoteUserAsync(Nota newNota, CancellationToken ct);

        public Task<List<Nota>> GetNotesAsync (int NoteId, CancellationToken ct);

        public Task<Nota> GetOneNoteAsync(int UserId, CancellationToken ct);
    }
}
