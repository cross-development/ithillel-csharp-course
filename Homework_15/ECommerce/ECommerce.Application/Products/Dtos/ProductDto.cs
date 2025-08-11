namespace ECommerce.Application.Products.Dtos;

/// <summary>
/// Data transfer object representing product information.
/// </summary>
public class ProductDto
{
    /// <summary>
    /// Product identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Product description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Category identifier.
    /// </summary>
    public int CategoryId { get; set; }
}
