using System.ComponentModel.DataAnnotations;

namespace AutoGestion.Models;

public class Seguimiento
{
    public int Id { get; set; }

    public int OrdenReparacionId { get; set; }
    public OrdenReparacion? OrdenReparacion { get; set; }

    public EstadoServicio Estado { get; set; } = EstadoServicio.Recibido;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [StringLength(300)]
    public string? Nota { get; set; }
}
