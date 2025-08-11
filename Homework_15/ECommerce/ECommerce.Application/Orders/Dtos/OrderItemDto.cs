namespace ECommerce.Application.Orders.Dtos;

/// <summary>
/// DTO for order item.
/// </summary>
public class OrderItemDto
{
    /// <summary>
    /// Product id.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }
}