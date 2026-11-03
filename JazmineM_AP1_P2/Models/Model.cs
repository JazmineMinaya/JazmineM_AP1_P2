using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JazmineM_AP1_P2.Models;

public partial class Model
{
    [Key]
    public int ModelId { get; set; }
}
