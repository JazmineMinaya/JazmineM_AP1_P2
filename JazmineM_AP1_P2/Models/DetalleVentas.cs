using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JazmineM_AP1_P2.Models;

public partial class DetalleVentas
{
    [Key]
    public int DetalleId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una venta")]
    public int VentaId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un producto")]
    public int ProductoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Este campo es requerido")]
    public int Cantidad { get; set; } = 0;

    [Range(1, double.MaxValue, ErrorMessage = "Este campo es requerido")]
    public double Precio { get; set; }

    [ForeignKey("VentaId")]
    public virtual Ventas? Venta { get; set; }

    [ForeignKey("ProductoId")]
    public virtual Productos? Producto { get; set; }
}
