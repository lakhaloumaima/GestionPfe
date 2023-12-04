namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pfe_etudiant
{
    public int Id { get; set; }

    [ForeignKey("Pfe")]
    public int PfeId { get; set; }

    [ForeignKey("Etudiant")]
    public int EtudiantID { get; set; }

    // Navigation properties
    public virtual Pfe? Pfe { get; set; }

    public virtual Etudiant? Etudiant { get; set; }


}
