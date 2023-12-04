namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pfe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Desc Obligatoire")]
    [StringLength(30, MinimumLength = 3)]
    public string Desc { get; set; }

    [Required(ErrorMessage = "DateD Obligatoire")]
    public DateTime DateD { get; set; }

    [Required(ErrorMessage = "DateF Obligatoire")]
    public DateTime DateF { get; set; }


    [ForeignKey("EncadrantID")]
    public int EncadrantID { get; set; }

    [ForeignKey("SocieteID")]
    public int SocieteID { get; set; }

    // Navigation properties
    public virtual Enseignant? Encadrant { get; set; }
    public virtual Societe? Societe { get; set; }

    public ICollection<Soutenance>? SoutenancesPfe { get; set; }


}