using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Vestergaard_new.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later (the year the first movie came out).")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required(ErrorMessage = "Edited field is required. Please select Yes or No.")]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required(ErrorMessage = "Copied To Plex field is required. Please select Yes or No.")]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}