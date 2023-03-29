using Microsoft.EntityFrameworkCore;
using ToToDiario.API.Application.InfrastructureContracts;
using ToToDiario.API.Domain.Entities;
using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Infrastructure.Persistence.Repositories
{

    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;
        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddNoteUserAsync(Nota newNota, CancellationToken ct)
        {
            await _context.Nota.AddAsync(newNota,ct);
            int result = await _context.SaveChangesAsync(ct);

            if (result > 0)
            {
                return newNota.NotaId;
            }
            return 0;
        }

        public async Task<List<Nota>> GetNotesAsync(int UserId, CancellationToken ct)
        {
            return await _context.Nota.Where(n => n.UserId== UserId && n.EstadoId != (int)NotasEstado.Borrado).Select(o => new Nota
            {
                NotaId = o.NotaId,
                Mensaje = o.Mensaje,
                UserId= UserId,
                Estado=o.Estado,
                Fecha=o.Fecha,  
            }).AsNoTracking().ToListAsync(ct);
        }

        public async Task<Nota> GetOneNoteAsync(int NoteId, CancellationToken ct)
        {
            var note = await _context.Nota.AsNoTracking().FirstOrDefaultAsync(n => n.NotaId == NoteId,ct);

            return note!;
        }
    }
}
