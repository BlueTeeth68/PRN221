using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class AuthorInstitution2023DBContext : DbContext
    {
        public AuthorInstitution2023DBContext()
        {
        }

        public AuthorInstitution2023DBContext(DbContextOptions<AuthorInstitution2023DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CorrespondingAuthor> CorrespondingAuthors { get; set; } = null!;
        public virtual DbSet<InstitutionInformation> InstitutionInformations { get; set; } = null!;
        public virtual DbSet<MemberAccount> MemberAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=123456;Database=AuthorInstitution2023DB");
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        public String GetConnectionString()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnection");

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorrespondingAuthor>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__Correspo__70DAFC14D7AB2F3F");

                entity.ToTable("CorrespondingAuthor");

                entity.Property(e => e.AuthorId)
                    .HasMaxLength(20)
                    .HasColumnName("AuthorID");

                entity.Property(e => e.AuthorBirthday).HasColumnType("datetime");

                entity.Property(e => e.AuthorName).HasMaxLength(100);

                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.InstitutionId).HasColumnName("InstitutionID");

                entity.Property(e => e.Skills).HasMaxLength(200);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.CorrespondingAuthors)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Correspon__Insti__286302EC");
            });

            modelBuilder.Entity<InstitutionInformation>(entity =>
            {
                entity.HasKey(e => e.InstitutionId)
                    .HasName("PK__Institut__8DF6B94D06FB377D");

                entity.ToTable("InstitutionInformation");

                entity.Property(e => e.InstitutionId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstitutionID");

                entity.Property(e => e.Area).HasMaxLength(150);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.InstitutionDescription).HasMaxLength(250);

                entity.Property(e => e.InstitutionName).HasMaxLength(120);

                entity.Property(e => e.TelephoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<MemberAccount>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__MemberAc__0CF04B381B4B1D7A");

                entity.ToTable("MemberAccount");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(50)
                    .HasColumnName("MemberID");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.MemberPassword).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
