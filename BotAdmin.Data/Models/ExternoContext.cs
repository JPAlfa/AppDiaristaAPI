using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppDiarista.Data.Models
{
    public partial class ExternoContext : DbContext
    {
        public ExternoContext()
        {
        }

        public ExternoContext(DbContextOptions<ExternoContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<Intent> Intent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=172.16.0.27\\DESSQL001;Database=Externo;user id=usrSysOmint;password=o7DOtUJe;MultipleActiveResultSets=True;");
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
