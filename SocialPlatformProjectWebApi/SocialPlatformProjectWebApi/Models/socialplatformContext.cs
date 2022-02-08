using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public partial class socialplatformContext : DbContext
    {
        public socialplatformContext()
        {
        }

        public socialplatformContext(DbContextOptions<socialplatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryThread> CategoryThreads { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<ThreadUser> ThreadUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socialplatform.database.windows.net,1433;Database=socialplatform;User Id=grouptwo;Password=Secretpassword0;Trusted_Connection=False;Encrypt=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryThread>(entity =>
            {
                entity.ToTable("CategoryThread");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdSub)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserId_Sub");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryThreads)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Thread_Category");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdSub)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserId_Sub");

                entity.HasOne(d => d.CategoryThread)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.CategoryThreadId)
                    .HasConstraintName("FK_Reply_Thread");
            });

            modelBuilder.Entity<ThreadUser>(entity =>
            {
                entity.Property(e => e.UserIdSub)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserId_Sub");

                entity.HasOne(d => d.CategoryThread)
                    .WithMany(p => p.ThreadUsers)
                    .HasForeignKey(d => d.CategoryThreadId)
                    .HasConstraintName("FK_ThreadUsers_Thread");

                entity.HasOne(d => d.UserIdSubNavigation)
                    .WithMany(p => p.ThreadUsers)
                    .HasForeignKey(d => d.UserIdSub)
                    .HasConstraintName("FK_ThreadUsers_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdSub);

                entity.ToTable("User");

                entity.Property(e => e.IdSub)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Id_sub");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Picture)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
