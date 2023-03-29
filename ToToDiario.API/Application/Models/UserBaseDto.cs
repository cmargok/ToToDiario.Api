using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToToDiario.API.Domain.Commons;
using ToToDiario.API.Domain.Entities;

namespace ToToDiario.API.Application.Models
{

    public class UserRegisterDto
    {
        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

    }

    public class UserBaseDto : UserRegisterDto
    {      
        public int UserId { get; set; }

    } 
   

    public class UserDto : BaseOut
    {
        public int UserId { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

    }

    public class UsersDto : BaseOut
    {
        public IEnumerable<UserBaseDto> Users { get; set; }
    }

    public class UserConfirmacion : BaseOut
    {
        public int UserId { get; set; }
    }

    public class UsersNotes : UserConfirmacion
    {
        public IEnumerable<NotesUserDto> notes { get; set; }   
    }
}
