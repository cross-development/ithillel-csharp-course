using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities;

/// <summary>
/// Represents an item in an order.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Order item id.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Order foreign key.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Product id.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Price per unit at the time of order.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Navigation to product (optional).
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Navigation to order.
    /// </summary>
    public Order? Order { get; set; }
}