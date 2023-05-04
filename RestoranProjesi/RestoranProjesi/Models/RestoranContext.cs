using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestoranProjesi.Models
{
    public partial class RestoranContext : DbContext
    {
        public RestoranContext()
        {
        }

        public RestoranContext(DbContextOptions<RestoranContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; } = null!;
        public virtual DbSet<Sefler> Seflers { get; set; } = null!;
        public virtual DbSet<Subeler> Subelers { get; set; } = null!;
        public virtual DbSet<Yemekler> Yemeklers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-K4EVO3J;Database=Restoran;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.HasKey(e => e.KullaniciNo);

                entity.ToTable("Kullanicilar");

                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sefler>(entity =>
            {
                entity.HasKey(e => e.ŞefNo);

                entity.ToTable("Sefler");

                entity.Property(e => e.ŞefAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ŞefSoyad)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subeler>(entity =>
            {
                entity.HasKey(e => e.SubeNo);

                entity.ToTable("Subeler");

                entity.Property(e => e.Il)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ilce)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubeAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Yemekler>(entity =>
            {
                entity.HasKey(e => e.YemekNo);

                entity.ToTable("Yemekler");

                entity.Property(e => e.Fiyat).HasColumnType("money");

                entity.Property(e => e.YemekAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ŞefAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
