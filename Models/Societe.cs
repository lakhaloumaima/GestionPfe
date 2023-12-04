namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;

public class Societe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Lib Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Lib { get; set; }

    [Required(ErrorMessage = "Adresse Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Adresse { get; set; }

    [Required(ErrorMessage = "Tel Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Tel { get; set; }

}