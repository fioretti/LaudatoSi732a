using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarcoPoloGCApi.Models
{
    public partial class MarcoPoloGCDBContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Gcpurchase> Gcpurchase { get; set; }
        public virtual DbSet<Gcredemption> Gcredemption { get; set; }
        public virtual DbSet<GcservicesType> GcservicesType { get; set; }
        public virtual DbSet<Gctype> Gctype { get; set; }
        public virtual DbSet<GiftCertificate> GiftCertificate { get; set; }
        public virtual DbSet<ServicesType> ServicesType { get; set; }

        public MarcoPoloGCDBContext(DbContextOptions<MarcoPoloGCDBContext> options)
           : base(options)
            { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Gcpurchase>(entity =>
            {
                entity.ToTable("GCPurchase");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GiftCertificateId).HasColumnName("GiftCertificateID");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.HasOne(d => d.GiftCertificate)
                    .WithMany(p => p.Gcpurchase)
                    .HasForeignKey(d => d.GiftCertificateId)
                    .HasConstraintName("FK_GCPurchase_GiftCertificate");
            });

            modelBuilder.Entity<Gcredemption>(entity =>
            {
                entity.ToTable("GCRedemption");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GiftCertificateId).HasColumnName("GiftCertificateID");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RedemptionDate).HasColumnType("datetime");

                entity.HasOne(d => d.GiftCertificate)
                    .WithMany(p => p.Gcredemption)
                    .HasForeignKey(d => d.GiftCertificateId)
                    .HasConstraintName("FK_GCRedemption_GiftCertificate");
            });

            modelBuilder.Entity<GcservicesType>(entity =>
            {
                entity.ToTable("GCServicesType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GiftCertificateId).HasColumnName("GiftCertificateID");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ServicesTypeId).HasColumnName("ServicesTypeID");

                entity.HasOne(d => d.GiftCertificate)
                    .WithMany(p => p.GcservicesType)
                    .HasForeignKey(d => d.GiftCertificateId)
                    .HasConstraintName("FK_GCServicesType_GiftCertificate");

                entity.HasOne(d => d.ServicesType)
                    .WithMany(p => p.GcservicesType)
                    .HasForeignKey(d => d.ServicesTypeId)
                    .HasConstraintName("FK_GCServicesType_ServicesType");
            });

            modelBuilder.Entity<Gctype>(entity =>
            {
                entity.ToTable("GCType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Gctype1)
                    .HasColumnName("GCType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GiftCertificate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DtipermitNo)
                    .HasColumnName("DTIPermitNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.GctypeId).HasColumnName("GCTypeID");

                entity.Property(e => e.IssuanceDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ValidityPeriod).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.Gctype)
                    .WithMany(p => p.GiftCertificate)
                    .HasForeignKey(d => d.GctypeId)
                    .HasConstraintName("FK_GiftCertificate_GCType");
            });

            modelBuilder.Entity<ServicesType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ServicesType1)
                    .HasColumnName("ServicesType")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
