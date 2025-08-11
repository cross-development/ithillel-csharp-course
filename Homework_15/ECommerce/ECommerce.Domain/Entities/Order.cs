using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities;

/// <summary>
/// Represents an order placed by a customer.
/// </summary>
public class Order
{
    /// <summary>
    /// Order identifier.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// The customer id who placed the order.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// The date and time when the order was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Total amount for the order.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    /// <summary>
    /// Navigation property to the customer.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Items included in the order.
    /// </summary>
    public ICollection<OrderItem> Items { get; set; } = [];
}
