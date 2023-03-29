using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToToDiario.API.Domain.Entities;

public partial class Nota
{
    [Key]
    [Column("Nota_ID")]
    public int NotaId { get; set; }

    [Column(TypeName = "date")]
    public DateTime Fecha { get; set; }

    [Column("Estado_ID")]
    public int EstadoId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Mensaje { get; set; } = null!;

    [ForeignKey("EstadoId")]
    public virtual Estado Estado { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}
