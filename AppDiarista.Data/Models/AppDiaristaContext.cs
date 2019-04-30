using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppDiarista.Data.Models
{
    public partial class AppDiaristaContext : DbContext
    {
        public AppDiaristaContext()
        {
        }

        public AppDiaristaContext(DbContextOptions<AppDiaristaContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Intent> Intent { get; set; }
        public virtual DbSet<Contratante> Contratante { get; set; }
        public virtual DbSet<Diarista> Diarista { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AppDiarista;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Intent>(entity =>
            {
                entity.Property(e => e.AmbiguousText).IsUnicode(false);

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.DefaultAnswer).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });
        }
    }
}
