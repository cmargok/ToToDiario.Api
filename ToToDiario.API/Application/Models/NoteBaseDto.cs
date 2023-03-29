using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToToDiario.API.Domain.Entities;
using ToToDiario.API.Domain.Commons;

namespace ToToDiario.API.Application.Models
{
    public class AddNoteBaseDto
    {
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }

    public class OneNoteDto : BaseOut
    {
        public int NotaId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int EstadoId { get; set; }
        public int UserId { get; set; }
    }


    public class NoteBaseDto : NotesUserDto
    {        
        public int UserId { get; set; }        
    }

    public class NoteConfirmacion : BaseOut
    {
        public int NotaId { get; set; }
    }

    public class NotesUserDto
    {
        public int NotaId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int EstadoId { get; set; }
    }

}
