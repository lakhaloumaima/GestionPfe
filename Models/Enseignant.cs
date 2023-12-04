namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;

public class Enseignant
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nom Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Nom { get; set; }

    [Required(ErrorMessage = "Prénom Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Prenom { get; set; }

    // Ajoutez cette propriété
    public ICollection<Soutenance>? SoutenancesPresident { get; set; }

    public ICollection<Soutenance>? SoutenancesRapporteur { get; set; }
}
