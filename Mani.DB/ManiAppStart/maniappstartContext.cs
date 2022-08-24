using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mani.DB.ManiAppStart
{
    public partial class maniappstartContext : DbContext
    {
        public maniappstartContext()
        {
        }

        public maniappstartContext(DbContextOptions<maniappstartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<관련내용> 관련내용 { get; set; } = null!;
        public virtual DbSet<요리> 요리 { get; set; } = null!;
        public virtual DbSet<요리재료> 요리재료 { get; set; } = null!;
        public virtual DbSet<재료목록> 재료목록 { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ins002com\\sql2014;Database=maniappstart;User ID=sa;Password=1234");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<관련내용>(entity =>
            {
                entity.ToTable("관련내용");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.분류).HasMaxLength(100);

                entity.Property(e => e.요리id).HasColumnName("요리ID");
            });

            modelBuilder.Entity<요리>(entity =>
            {
                entity.ToTable("요리");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.요리명).HasMaxLength(100);
            });

            modelBuilder.Entity<요리재료>(entity =>
            {
                entity.HasKey(e => new { e.요리id, e.재료id });

                entity.ToTable("요리재료");

                entity.Property(e => e.요리id).HasColumnName("요리ID");

                entity.Property(e => e.재료id).HasColumnName("재료ID");

                entity.Property(e => e.계량수).HasMaxLength(20);
            });

            modelBuilder.Entity<재료목록>(entity =>
            {
                entity.ToTable("재료목록");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.단위).HasMaxLength(10);

                entity.Property(e => e.재료명).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
