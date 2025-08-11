using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities;

/// <summary>
/// Represents a customer of the e-commerce store.
/// </summary>
public class Customer
{
    /// <summary>
    /// Customer identifier.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Customer's full name.
    /// </summary>
    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Customer email address.
    /// </summary>
    [Required]
    [MaxLength(320)]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Optional phone number.
    /// </summary>
    [MaxLength(30)]
    public string? Phone { get; set; }
}
