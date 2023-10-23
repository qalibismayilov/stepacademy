using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp1.Models
{
    public partial class StepItAcademyContext : DbContext
    {
        public StepItAcademyContext()
        {
        }

        public StepItAcademyContext(DbContextOptions<StepItAcademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groupp> Groupps { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=STHQ0129-02;Initial Catalog=StepItAcademy;User ID=admin;Password=********;Connect Timeout=30;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groupp>(entity =>
            {
                entity.ToTable("Groupp");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Avarage).HasColumnName("avarage");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.Groupp)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GrouppId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Student__GrouppI__398D8EEE");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Permission).HasColumnName("permission");

                entity.HasOne(d => d.Groupp)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.GrouppId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Teacher__GrouppI__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
