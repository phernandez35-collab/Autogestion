using System.ComponentModel.DataAnnotations;

namespace AutoGestion.Models;

public class Vehiculo
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecciona un cliente.")]
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    [Required(ErrorMessage = "La marca es obligatoria.")]
    [StringLength(50)]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "El modelo es obligatorio.")]
    [StringLength(50)]
    public string Modelo { get; set; } = string.Empty;

    [Range(1950, 2100, ErrorMessage = "El año no es válido.")]
    public int Anio { get; set; } = DateTime.Now.Year;

    [Required(ErrorMessage = "Las placas son obligatorias.")]
    [StringLength(15)]
    public string Placas { get; set; } = string.Empty;

    [StringLength(30)]
    public string? Color { get; set; }

    public List<OrdenReparacion> Ordenes { get; set; } = new();
}
