using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities;

/// <summary>
/// Represents a product sold in the e-commerce store.
/// </summary>
public class Product
{
    /// <summary>
    /// Primary key. Product identifier.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Product title or name.
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Product description.
    /// </summary>
    [MaxLength(2000)]
    public string? Description { get; set; }

    /// <summary>
    /// Product price.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    /// <summary>
    /// Foreign key to Category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Navigation property to Category.
    /// </summary>
    public Category? Category { get; set; }
}