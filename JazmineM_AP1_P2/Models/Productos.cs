using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JazmineM_AP1_P2.Models;

public partial class Productos
{
    [Key]
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Nombre { get; set; } = string.Empty;

    [Range(1, double.MaxValue, ErrorMessage = "Este campo es requerido")]
    public double Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Este campo es requerido")]
    public int Stock { get; set; } = 10;
}
