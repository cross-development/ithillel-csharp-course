using System.ComponentModel.DataAnnotations;

namespace Homework_13.Models;

public class Contact
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Contact Name")]
    public string Name { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Mobile Phone")]
    public string Phone { get; set; }

    [Phone]
    [Display(Name = "Alternative Mobile Phone")]
    public string? AlternatePhone { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [StringLength(500)]
    [Display(Name = "Short Description")]
    public string? Description { get; set; }
}