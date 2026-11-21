using System.ComponentModel.DataAnnotations;

namespace AutoGestion.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [StringLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Domicilio { get; set; }

    [StringLength(100)]
    [EmailAddress(ErrorMessage = "El correo no es válido.")]
    public string? Correo { get; set; }

    public List<Vehiculo> Vehiculos { get; set; } = new();
}
