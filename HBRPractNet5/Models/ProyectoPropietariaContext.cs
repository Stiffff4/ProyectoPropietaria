using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoPropietaria.Models
{
    public partial class ProyectoPropietariaContext : DbContext
    {
        public ProyectoPropietariaContext()
        {
        }

        public ProyectoPropietariaContext(DbContextOptions<ProyectoPropietariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=STIFFFF;Initial Catalog=PropietariaDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Creado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Productos_Productos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

                entity.Property(e => e.IsAdmin).HasColumnName("Is_Admin");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
