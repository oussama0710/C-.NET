#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
public class Survey
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string DojoLocation { get; set; }
    [Required]
    public string FavouriteLanguage { get; set; }
    [Required]
    public string Comment { get; set; }
}