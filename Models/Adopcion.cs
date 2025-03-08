using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppScaffolding.Models;

[Table("Adopcion")]
public partial class Adopcion
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Column("FechaAdopcion")]
    public DateOnly? FechaAdopcion { get; set; }
    [Column("UsuarioId")]
    public int? UsuarioId { get; set; }
    [Column("MascotaId")]
    public int? MascotaId { get; set; }
}
