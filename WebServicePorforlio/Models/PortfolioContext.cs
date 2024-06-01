using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebServicePorforlio.Models;

public partial class PortfolioContext : DbContext
{
    public PortfolioContext()
    {
    }

    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatosPersona> DatosPersonas { get; set; }

    public virtual DbSet<DescripcionPersonal> DescripcionPersonal { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=PortfolioConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosPersona>(entity =>
        {
            entity.ToTable("DatosPersona");

            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()  
                  .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        modelBuilder.Entity<DescripcionPersonal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Descripc__3214EC07C68F56E0");

            entity.ToTable("DescripcionPersonal");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC0745A1DE29");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
