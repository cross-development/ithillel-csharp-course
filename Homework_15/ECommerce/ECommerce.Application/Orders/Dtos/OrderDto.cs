namespace ECommerce.Application.Orders.Dtos;

/// <summary>
/// DTO representing order.
/// </summary>
public class OrderDto
{
    /// <summary>
    /// Order id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Customer id who placed the order.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Order creation date (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Total amount.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Items in the order.
    /// </summary>
    public List<OrderItemDto> Items { get; set; } = [];
}