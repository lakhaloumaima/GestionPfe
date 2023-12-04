namespace PfeApp.Models;
using System.ComponentModel.DataAnnotations;


    public class EtudPfe
    {
        public int Id { get; set; }

    
         public int EtudiantId { get; set; }

        public string Etudiant { get; set; }
        public string PfeTitle { get; set; }
        public string Societe { get; set; }

        public string Encadrant { get; set; }
        public string President { get; set; }
        public string Rapporteur { get; set; }

}

