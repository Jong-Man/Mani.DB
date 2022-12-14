using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mani.DB.ManiAppStart
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

        public virtual DbSet<관련내용> 관련내용S { get; set; } = null!;
        public virtual DbSet<레시피> 레시피S { get; set; } = null!;
        public virtual DbSet<요리> 요리S { get; set; } = null!;
        public virtual DbSet<요리재료> 요리재료S { get; set; } = null!;
        public virtual DbSet<재료> 재료S { get; set; } = null!;
        public virtual DbSet<추가HTML내용> 추가HTML내용S { get; set; } = null!;
        public virtual DbSet<해쉬태그> 해쉬태그S { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ins002com\\sql2014;Database=ManiAppStart;User ID=sa;Password=1234");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<관련내용>(entity =>
            {
                entity.ToTable("관련내용");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.분류).HasMaxLength(100);

                entity.Property(e => e.요리ID).HasColumnName("요리ID");

                entity.HasOne(d => d.요리)
                    .WithMany(p => p.관련내용S)
                    .HasForeignKey(d => d.요리ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_관련내용_요리");
            });

            modelBuilder.Entity<레시피>(entity =>
            {
                entity.ToTable("레시피");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.구분)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.요리ID).HasColumnName("요리ID");

                entity.HasOne(d => d.요리)
                    .WithMany(p => p.레시피S)
                    .HasForeignKey(d => d.요리ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_레시피_요리");
            });

            modelBuilder.Entity<요리>(entity =>
            {
                entity.ToTable("요리");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.간단설명).HasMaxLength(200);

                entity.Property(e => e.분류).HasMaxLength(20);

                entity.Property(e => e.요리명).HasMaxLength(100);
            });

            modelBuilder.Entity<요리재료>(entity =>
            {
                entity.HasKey(e => new { e.요리ID, e.재료ID });

                entity.ToTable("요리재료");

                entity.Property(e => e.요리ID).HasColumnName("요리ID");

                entity.Property(e => e.재료ID).HasColumnName("재료ID");

                entity.Property(e => e.계량수).HasMaxLength(20);

                entity.Property(e => e.메모).HasMaxLength(200);

                entity.HasOne(d => d.요리)
                    .WithMany(p => p.요리재료S)
                    .HasForeignKey(d => d.요리ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_요리재료_요리");

                entity.HasOne(d => d.재료)
                    .WithMany(p => p.요리재료S)
                    .HasForeignKey(d => d.재료ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_요리재료_재료목록");
            });

            modelBuilder.Entity<재료>(entity =>
            {
                entity.ToTable("재료");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.단위).HasMaxLength(10);

                entity.Property(e => e.재료명).HasMaxLength(100);

                entity.Property(e => e.분류).HasMaxLength(20);
            });

            modelBuilder.Entity<추가HTML내용>(entity =>
            {
                entity.ToTable("추가HTML내용");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.분류).HasMaxLength(20);

                entity.Property(e => e.제목).HasMaxLength(100);
            });

            modelBuilder.Entity<해쉬태그>(entity =>
            {
                entity.ToTable("해쉬태그");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.HTMLID).HasColumnName("HTMLID");

                entity.Property(e => e.태그내용).HasMaxLength(50);

                entity.HasOne(d => d.HTML)
                    .WithMany(p => p.해쉬태그S)
                    .HasForeignKey(d => d.HTMLID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_해쉬태그_추가HTML내용");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
