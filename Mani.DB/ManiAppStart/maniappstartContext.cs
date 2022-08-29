using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mani.DB.maniAppStart
{
    public partial class ManiAppStartContext : DbContext
    {
        public ManiAppStartContext()
        {
        }

        public ManiAppStartContext(DbContextOptions<ManiAppStartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<관련내용> 관련내용s { get; set; } = null!;
        public virtual DbSet<요리> 요리s { get; set; } = null!;
        public virtual DbSet<요리재료> 요리재료s { get; set; } = null!;
        public virtual DbSet<재료목록> 재료목록s { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ins002Com\\sql2014;Database=ManiAppStart;User ID=sa;Password=1234");
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

                entity.HasOne(d => d.요리)
                    .WithMany(p => p.관련내용s)
                    .HasForeignKey(d => d.요리id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_관련내용_요리");
            });

            modelBuilder.Entity<요리>(entity =>
            {
                entity.ToTable("요리");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.간단설명).HasMaxLength(200);

                entity.Property(e => e.분류).HasMaxLength(20);

                entity.Property(e => e.요리명).HasMaxLength(100);
            });

            modelBuilder.Entity<요리재료>(entity =>
            {
                entity.HasKey(e => new { e.요리id, e.재료id });

                entity.ToTable("요리재료");

                entity.Property(e => e.요리id).HasColumnName("요리ID");

                entity.Property(e => e.재료id).HasColumnName("재료ID");

                entity.Property(e => e.계량수).HasMaxLength(20);

                entity.Property(e => e.메모).HasMaxLength(200);

                entity.HasOne(d => d.요리)
                    .WithMany(p => p.요리재료s)
                    .HasForeignKey(d => d.요리id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_요리재료_요리");

                entity.HasOne(d => d.재료)
                    .WithMany(p => p.요리재료s)
                    .HasForeignKey(d => d.재료id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_요리재료_재료목록");
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
