using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pvbackend.Models
{
    public partial class marcialdbContext : DbContext
    {
        public marcialdbContext()
        {
        }

        public marcialdbContext(DbContextOptions<marcialdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Pedidoencabezado> Pedidoencabezado { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User ID = postgres;Password=Marcial1995;Server=localhost;Port=5432;Database=marcialdb;Integrated Security=true; Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("articulo");

                entity.Property(e => e.Articuloid)
                    .HasColumnName("articuloid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Ubicacion)
                    .HasColumnName("ubicacion")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.ToTable("inventario");

                entity.Property(e => e.Inventarioid)
                    .HasColumnName("inventarioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Articuloid).HasColumnName("articuloid");

                entity.Property(e => e.Existencia).HasColumnName("existencia");
            });

            modelBuilder.Entity<Pedidoencabezado>(entity =>
            {
                entity.HasKey(e => e.Pedidoid)
                    .HasName("pedidoencabezado_pkey");

                entity.ToTable("pedidoencabezado");

                entity.Property(e => e.Pedidoid)
                    .HasColumnName("pedidoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Usuarioid)
                    .HasColumnName("usuarioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasColumnType("character varying");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
