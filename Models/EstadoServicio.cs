using System.ComponentModel.DataAnnotations;

namespace AutoGestion.Models;

public enum EstadoServicio
{
    [Display(Name = "Recibido")] Recibido,
    [Display(Name = "En diagnóstico")] EnDiagnostico,
    [Display(Name = "En reparación")] EnReparacion,
    [Display(Name = "Listo para entrega")] ListoParaEntrega,
    [Display(Name = "Entregado")] Entregado
}
