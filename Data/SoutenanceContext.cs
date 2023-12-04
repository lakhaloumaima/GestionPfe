using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PfeApp.Models;

public class SoutenanceContext : DbContext
    {
        public SoutenanceContext (DbContextOptions<SoutenanceContext> options)
            : base(options)
        {
        }

        public DbSet<PfeApp.Models.Enseignant> Enseignant { get; set; } = default!;

        public DbSet<PfeApp.Models.Etudiant> Etudiant { get; set; } = default!;

        public DbSet<PfeApp.Models.Pfe> Pfe { get; set; } = default!;

        public DbSet<PfeApp.Models.Pfe_etudiant> Pfe_etudiant { get; set; } = default!;

        public DbSet<PfeApp.Models.Societe> Societe { get; set; } = default!;

        public DbSet<PfeApp.Models.Soutenance> Soutenance { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ... autres configurations ...

        // Relationship between Soutenance and Enseignant (President)
        modelBuilder.Entity<Soutenance>()
            .HasOne(s => s.President)
            .WithMany(e => e.SoutenancesPresident)  // Assurez-vous que cette propriété existe dans la classe Enseignant
            .HasForeignKey(s => s.PresidentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relationship between Soutenance and Enseignant (Rapporteur)
        modelBuilder.Entity<Soutenance>()
            .HasOne(s => s.Rapporteur)
            .WithMany(e => e.SoutenancesRapporteur)
            .HasForeignKey(s => s.RapporteurId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Soutenance>()
            .HasOne(s => s.Pfe)
            .WithMany(e => e.SoutenancesPfe)  // Assurez-vous que cette propriété existe dans la classe Enseignant
            .HasForeignKey(s => s.PfeId)
            .OnDelete(DeleteBehavior.Restrict);

        // ... autres configurations ...
    }
}


