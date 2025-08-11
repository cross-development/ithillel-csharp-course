namespace ECommerce.Application.Customers.Dtos;

/// <summary>
/// DTO for customer entity.
/// </summary>
public class CustomerDto
{
    /// <summary>
    /// Customer id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Full name.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Email address.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Phone number.
    /// </summary>
    public string? Phone { get; set; }
}
