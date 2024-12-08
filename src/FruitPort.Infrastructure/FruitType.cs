using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FruitPort.Infrastructure;

public class FruitType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Origin { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PurchasePrice { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal SalePrice { get; set; }

    public ICollection<FruitStock> StockEntries { get; set; } = new List<FruitStock>();

    [NotMapped]
    public decimal Margin => SalePrice - PurchasePrice;
}
