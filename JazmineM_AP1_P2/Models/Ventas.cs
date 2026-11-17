using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JazmineM_AP1_P2.Models;

public partial class Ventas
{
    [Key]
    public int VentaId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Observacion { get; set; }

    public double Total { get; set; }

    public virtual ICollection<DetalleVentas> DetalleVentas { get; set; } = new List<DetalleVentas>();
}
