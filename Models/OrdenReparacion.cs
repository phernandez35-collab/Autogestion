using System.ComponentModel.DataAnnotations;

namespace AutoGestion.Models;

public class OrdenReparacion
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un vehículo.")]
    public int VehiculoId { get; set; }
    public Vehiculo? Vehiculo { get; set; }

    public DateTime FechaIngreso { get; set; } = DateTime.Now;
    public DateTime? FechaEntrega { get; set; }

    [Required(ErrorMessage = "Describe el problema reportado.")]
    [StringLength(500)]
    public string ProblemaReportado { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Tratamiento { get; set; }

    [Range(0, 9999999.99, ErrorMessage = "El costo no es válido.")]
    public decimal? Costo { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El kilometraje no es válido.")]
    public int? Kilometraje { get; set; }

    public List<Seguimiento> Seguimientos { get; set; } = new();
}
