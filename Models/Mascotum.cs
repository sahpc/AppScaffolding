using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppScaffolding.Models;

public partial class Mascotum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Especie { get; set; }

    [StringLength(50)]
    public string? Raza { get; set; }

    public int? UsuarioId { get; set; }
}
