namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;

public class Etudiant
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nom Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Nom { get; set; }

    [Required(ErrorMessage = "Prénom Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Prenom { get; set; }


    // [ DataType( DataType.Date) ]
    [DataType(DataType.Date)]

    [Display(Name = "Date De Naissance")]
    public DateTime DateN { get; set; }

    public string NomPrenom
    {
        get
        {

            return Nom + " " + Prenom;
        }
    }


}
