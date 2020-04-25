using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MonitoringTeamApi.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<LogCreateVm> LogCreateVm { get; set; }
        public virtual DbSet<LogDeleteVm> LogDeleteVm { get; set; }
        public virtual DbSet<LogEditVm> LogEditVm { get; set; }
        public virtual DbSet<LogListVm> LogListVm { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PageCreateVm> PageCreateVm { get; set; }
        public virtual DbSet<PageDeleteVm> PageDeleteVm { get; set; }
        public virtual DbSet<PageEditVm> PageEditVm { get; set; }
        public virtual DbSet<PageListVm> PageListVm { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<UserListVm> UserListVm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:bikeshopdatabaseserver.database.windows.net,1433;Initial Catalog=MonitorTeamDB;Persist Security Info=False;User ID=bikeshopadmin;Password=fiveguys1sprint!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.PageCreateVmid);

                entity.HasIndex(e => e.PageDeleteVmid);

                entity.HasIndex(e => e.PageEditVmid);

                entity.HasIndex(e => e.PageInfoId);

                entity.HasIndex(e => e.PageListVmid);

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId);

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasIndex(e => e.PageCreateVmid);

                entity.HasIndex(e => e.PageDeleteVmid);

                entity.HasIndex(e => e.PageEditVmid);

                entity.HasIndex(e => e.PageInfoId);

                entity.HasIndex(e => e.PageListVmid);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
