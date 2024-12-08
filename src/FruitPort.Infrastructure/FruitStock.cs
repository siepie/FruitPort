using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FruitPort.Infrastructure;

public class FruitStock
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int FruitTypeId { get; set; }

    [ForeignKey(nameof(FruitTypeId))]
    public FruitType FruitType { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public DateTime ActionDate { get; set; }
}
