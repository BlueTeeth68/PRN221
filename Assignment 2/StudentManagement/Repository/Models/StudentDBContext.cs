using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Repository.Models
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
        {
        }

        public StudentDBContext(DbContextOptions<StudentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<ClassMember> ClassMembers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId)
                    .ValueGeneratedNever()
                    .HasColumnName("class_id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class_name");
            });

            modelBuilder.Entity<ClassMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__ClassMem__B29B85347690ED2D");

                entity.ToTable("ClassMember");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("member_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .HasDefaultValueSql("('Male')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('Student')");

                entity.HasMany(d => d.Classes)
                    .WithMany(p => p.Members)
                    .UsingEntity<Dictionary<string, object>>(
                        "MemberClass",
                        l => l.HasOne<Class>().WithMany().HasForeignKey("ClassId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MemberCla__class__31EC6D26"),
                        r => r.HasOne<ClassMember>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MemberCla__membe__30F848ED"),
                        j =>
                        {
                            j.HasKey("MemberId", "ClassId").HasName("PK__MemberCl__CD44C2ACDF48AE21");

                            j.ToTable("MemberClass");

                            j.IndexerProperty<string>("MemberId").HasMaxLength(10).IsUnicode(false).HasColumnName("member_id");

                            j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__F3DBC572C04F693F")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(100)
                    .HasColumnName("avatar_url");

                entity.Property(e => e.FullName)
                    .HasMaxLength(250)
                    .HasColumnName("full_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('Manager')");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
