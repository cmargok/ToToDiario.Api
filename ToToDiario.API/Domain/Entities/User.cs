using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToToDiario.API.Domain.Entities;

[Table("User")]
public partial class User
{
    [Key]
    [Column("User_ID")]
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombres { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Apellidos { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Nota> Notas { get; } = new List<Nota>();
}
