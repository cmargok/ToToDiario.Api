using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToToDiario.API.Domain.Entities;

[Table("Estado")]
public partial class Estado
{
    [Key]
    [Column("Estado_ID")]
    public int EstadoId { get; set; }

    [Column("Estado")]
    [StringLength(205)]
    [Unicode(false)]
    public string EstadoTipo { get; set; } = null!;

    public virtual ICollection<Nota> Notas { get; } = new List<Nota>();
}
