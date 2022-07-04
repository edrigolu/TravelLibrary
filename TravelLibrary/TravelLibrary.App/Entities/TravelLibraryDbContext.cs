using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TravelLibrary.App.Entities
{
    public partial class TravelLibraryDbContext : DbContext
    {
        public TravelLibraryDbContext()
        {
        }

        public TravelLibraryDbContext(DbContextOptions<TravelLibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<AutorLibro> AutorLibros { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=localhost;Database=TravelLibraryDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<AutorLibro>(entity =>
            {
                entity.ToTable("Autor_Libro");

                entity.Property(e => e.AutoresId).HasColumnName("Autores_Id");

                entity.Property(e => e.LibrosId).HasColumnName("Libros_Id");

                entity.HasOne(d => d.Autores)
                    .WithMany(p => p.AutorLibros)
                    .HasForeignKey(d => d.AutoresId)
                    .HasConstraintName("FK_Autores_Libros_Autores_Autores_Id");

                entity.HasOne(d => d.Libros)
                    .WithMany(p => p.AutorLibros)
                    .HasForeignKey(d => d.LibrosId)
                    .HasConstraintName("FK_Autores_Libros_Libros_Libros_Id");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("Editorial");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libro");

                entity.Property(e => e.EditorialesId).HasColumnName("Editoriales_Id");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.NPaginas)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("N_Paginas");

                entity.Property(e => e.Sinopsis).IsRequired();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.Editoriales)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EditorialesId)
                    .HasConstraintName("FK_Libros_Editoriales_Editoriales_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
