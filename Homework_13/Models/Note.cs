using System.ComponentModel.DataAnnotations;

namespace Homework_13.Models;

public class Note
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    [Display(Name = "Note Title")]
    public string Title { get; set; }

    [Required]
    [Display(Name = "Note Text")]
    public string Text { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [StringLength(500)]
    [Display(Name = "Tags")]
    public string? Tags { get; set; }
}