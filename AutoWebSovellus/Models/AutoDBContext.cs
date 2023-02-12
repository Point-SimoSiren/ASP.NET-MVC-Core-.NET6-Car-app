using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutoWebSovellus.Models
{
    public partial class AutoDBContext : DbContext
    {
        public AutoDBContext()
        {
        }

        public AutoDBContext(DbContextOptions<AutoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autot> Autots { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:duuniserver.database.windows.net,1433;Initial Catalog=AutoDB;Persist Security Info=False;User ID=sirensimo;Password=GolfGolf7777!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autot>(entity =>
            {
                entity.HasKey(e => e.AutoId);

                entity.ToTable("Autot");

                entity.Property(e => e.Malli).HasMaxLength(50);

                entity.Property(e => e.Merkki).HasMaxLength(50);

                entity.Property(e => e.Rekisterinumero).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
