using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;

namespace Infrastructure
{
    public partial class CoursesContext : IdentityDbContext<AspNetUsers>
    {
        public CoursesContext()
        {
        }

        public CoursesContext(DbContextOptions<CoursesContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Dbbc> Dbbc { get; set; }
        public virtual DbSet<Dbbctouser> Dbbctouser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Courses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Credit).IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Dbbc>(entity =>
            {
                entity.ToTable("DBBC");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Dbbc)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DBBC_ToUser");
            });

            modelBuilder.Entity<Dbbctouser>(entity =>
            {
                entity.ToTable("DBBCTOUSER");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Dbbcid).HasColumnName("DBBCId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Dbbc)
                    .WithMany(p => p.Dbbctouser)
                    .HasForeignKey(d => d.Dbbcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_ToDBBC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dbbctouser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_ToUser");
            });

            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
