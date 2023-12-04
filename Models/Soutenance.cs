namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Soutenance
{
    public int Id { get; set; }

    [DataType(DataType.Date)]
    [CustomDateValidation(ErrorMessage = "La date doit être supérieure à la date actuelle.")]
    [Required(ErrorMessage = "Date Obligatoire")]
    public DateTime Date { get; set; }

    [DataType(DataType.Time)]

    [Required(ErrorMessage = "Heure Obligatoire")]
    public DateTime Heure { get; set; }

    [ForeignKey("PfeId")]
    public int PfeId { get; set; }

    [ForeignKey("PresidentId")]
    public int PresidentId { get; set; }

    [ForeignKey("RapporteurId")]
    public int RapporteurId { get; set; }

    // Navigation properties
    public virtual Pfe? Pfe { get; set; }

    public virtual Enseignant? President { get; set; }

    public virtual Enseignant? Rapporteur { get; set; }


}

public class CustomDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dateValue = (DateTime)value;

        if (dateValue <= DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}

