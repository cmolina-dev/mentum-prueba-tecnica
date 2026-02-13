using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public partial class MentumDbContext : DbContext
{
    public MentumDbContext()
    {
    }

    public MentumDbContext(DbContextOptions<MentumDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MentumDB;User Id=sa;Password=MentumTest2024!;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07721A9EEE");

            entity.Property(e => e.Direccion).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NombreCompleto).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacto__3214EC07CBAB4079");

            entity.Property(e => e.Direccion).HasMaxLength(500);
            entity.Property(e => e.NombreCompleto).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Contactos_Clientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
