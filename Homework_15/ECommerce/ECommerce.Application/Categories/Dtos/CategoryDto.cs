namespace ECommerce.Application.Categories.Dtos;

/// <summary>
/// Data transfer object for category.
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// Category id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Category name.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Category description.
    /// </summary>
    public string? Description { get; set; }
}
