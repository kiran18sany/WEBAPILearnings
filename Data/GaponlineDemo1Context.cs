using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WarrantyAPITest.Models;

namespace WarrantyAPITest.Data;

public partial class GaponlineDemo1Context : DbContext
{
    public GaponlineDemo1Context()
    {
    }

    public GaponlineDemo1Context(DbContextOptions<GaponlineDemo1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<EwclaimPartMaster> EwclaimPartMasters { get; set; }

    public virtual DbSet<EwclaimSubmissionDetailsApi> EwclaimSubmissionDetailsApis { get; set; }

    public virtual DbSet<EwclaimSubmissionHeaderApi> EwclaimSubmissionHeaderApis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EwclaimPartMaster>(entity =>
        {
            entity.HasKey(e => e.PartId);

            entity.ToTable("EWClaimPartMaster");
        });

        modelBuilder.Entity<EwclaimSubmissionDetailsApi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EWClaimSubmissionDetailsAPI");

            entity.Property(e => e.LabourCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LabourDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LabourGoodWill).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LabourQuoted).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PartsCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PartsDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PartsGoodWill).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PartsQuoted).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");
        });

        modelBuilder.Entity<EwclaimSubmissionHeaderApi>(entity =>
        {
            entity.HasKey(e => e.SubmissionId);

            entity.ToTable("EWClaimSubmissionHeaderAPI");

            entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");
            entity.Property(e => e.ClaimKm).HasColumnName("ClaimKM");
            entity.Property(e => e.GappolicyNo).HasColumnName("GAPPolicyNo");
            entity.Property(e => e.GappolicySerialNo).HasColumnName("GAPPolicySerialNo");
            entity.Property(e => e.LastServiceKm).HasColumnName("LastServiceKM");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Vinnumber).HasColumnName("VINNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
