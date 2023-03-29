using ToToDiario.API.Application.InfrastructureContracts;
using ToToDiario.API.Application.Models;
using ToToDiario.API.Domain.Entities;
using ToToDiario.API.Domain.Shared.ExtensionsMethods;
using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Application.NoteService
{
    public class NoteService : INoteService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotaRepository _notaRepository;

        public NoteService(IUserRepository userRepository, INotaRepository notaRepository)
        {
            _userRepository = userRepository;
            _notaRepository = notaRepository;
        }
        public async Task<NoteConfirmacion> AddNoteUserAsync(int UserId, AddNoteBaseDto newNota, CancellationToken ct)
        {
            var NoteConfirmacion = new NoteConfirmacion();

            if (await _userRepository.UserExistsAsync(UserId, ct))
            {
                var note = new Nota
                {
                    Fecha = newNota.Fecha,
                    Mensaje = newNota.Mensaje,
                    EstadoId = (int)NotasEstado.Activo,
                    UserId = UserId,
                };

                var addNote = await _notaRepository.AddNoteUserAsync(note, ct);

                if (addNote > 0)
                {
                    NoteConfirmacion.Result = ResultStatus.Success;
                    NoteConfirmacion.ResultMessage = ResultStatus.Success.GetDescription();
                    NoteConfirmacion.NotaId = addNote;
                    return NoteConfirmacion;
                }
                NoteConfirmacion.Result = ResultStatus.NotCreated;
                NoteConfirmacion.ResultMessage = ResultStatus.NotCreated.GetDescription();
                NoteConfirmacion.NotaId = 0;
                return NoteConfirmacion;
            }
            NoteConfirmacion.Result = ResultStatus.NotExist;
            NoteConfirmacion.ResultMessage = ResultStatus.NotExist.GetDescription();
            NoteConfirmacion.NotaId = 0;
            return NoteConfirmacion;
        }

        public async Task<OneNoteDto> GetOneNoteAsync(int UserId, int NoteId, CancellationToken ct)
        {
            var Notas = new OneNoteDto();

            if (await _userRepository.UserExistsAsync(UserId, ct))
            {              
                var Note = await _notaRepository.GetOneNoteAsync(NoteId, ct);

                if (Note is not null)
                {
                    Notas.Result = ResultStatus.Success;
                    Notas.ResultMessage = ResultStatus.Success.GetDescription();
                    Notas.Mensaje = Note.Mensaje;
                    Notas.NotaId = NoteId;
                    Notas.EstadoId = Note.EstadoId;
                    Notas.Fecha= Note.Fecha;
                    Notas.UserId= UserId;
                    return Notas;
                }
                Notas.Result = ResultStatus.NoRecords;
                Notas.ResultMessage = ResultStatus.NoRecords.GetDescription();
                return Notas;
            }
            Notas.Result = ResultStatus.NotExist;
            Notas.ResultMessage = ResultStatus.NotExist.GetDescription();
            return Notas;

            
        }

        public async Task<UsersNotes> GetNotesAsync (int UserId, CancellationToken ct)
        {
            var Notas = new UsersNotes();

            if (await _userRepository.UserExistsAsync(UserId, ct))
            {
                var NotesEntity = await _notaRepository.GetNotesAsync(UserId, ct);

                if (NotesEntity.Count > 0)
                {
                    Notas.notes = NotesEntity.Select(n => new NotesUserDto
                    {
                        Fecha= n.Fecha,
                        EstadoId= n.EstadoId,
                        Mensaje= n.Mensaje,
                        NotaId= n.NotaId,
                    }).ToList();

                    Notas.Result = ResultStatus.Success;
                    Notas.ResultMessage = ResultStatus.Success.GetDescription();
                    Notas.UserId = UserId;
                    return Notas;
                }
                Notas.Result = ResultStatus.NoRecords;
                Notas.ResultMessage = ResultStatus.NoRecords.GetDescription();
                Notas.UserId = UserId;
                Notas.notes = Enumerable.Empty<NotesUserDto>();
                return Notas;
            }

            Notas.Result = ResultStatus.NotExist;
            Notas.ResultMessage = ResultStatus.NotExist.GetDescription();
            Notas.UserId = UserId;
            Notas.notes = Enumerable.Empty<NotesUserDto>();
            return Notas;
        }
    }
}
