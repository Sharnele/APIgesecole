using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIgesecole.Models
{
    public partial class gesecoleContext : DbContext
    {
        public gesecoleContext()
        {
        }

        public gesecoleContext(DbContextOptions<gesecoleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cour> Cours { get; set; } = null!;
        public virtual DbSet<Etudiant> Etudiants { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Sharnele\\SQLEXPRESS01;initial catalog=gesecole; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cour>(entity =>
            {
                entity.ToTable("Cour");

                entity.Property(e => e.Nom)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.ToTable("Etudiant");

                entity.Property(e => e.Matricule)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone).HasColumnName("telephone");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Datep).HasColumnType("date");

                entity.HasOne(d => d.IdcourNavigation)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.Idcour)
                    .HasConstraintName("FK__Participa__Idcou__5CD6CB2B");

                entity.HasOne(d => d.IdetudiantNavigation)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.Idetudiant)
                    .HasConstraintName("FK__Participa__Idetu__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
