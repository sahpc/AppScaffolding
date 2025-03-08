using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppScaffolding.Models;

[Table("Seguimiento")]
public partial class Seguimiento
{
    [Key]
    public int Id { get; set; }

    public DateOnly? FechaVisita { get; set; }

    [StringLength(50)]
    public string? Comentario { get; set; }

    [StringLength(50)]
    public string? EstadoMascota { get; set; }

    public int? AdopcionId { get; set; }
}
