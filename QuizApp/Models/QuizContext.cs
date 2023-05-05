using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizApp.Models
{
    public partial class QuizContext : DbContext
    {
        public QuizContext()
        {
        }

        public QuizContext(DbContextOptions<QuizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAnswers> UsersAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C9263899E0D0DB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersAnswers>(entity =>
            {
                entity.HasKey(e => e.IdAnswers)
                    .HasName("PK__Users_an__E22FAE16B18EA65E");

                entity.ToTable("Users_answers");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorrectAnswers).HasColumnName("Correct_answers");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersAnswers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users_ans__UserI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
