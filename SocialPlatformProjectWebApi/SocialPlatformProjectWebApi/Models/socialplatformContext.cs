using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public class SocialplatformContext : DbContext
    {
        public SocialplatformContext()
        {
        }

        public SocialplatformContext(DbContextOptions<SocialplatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }
        public virtual DbSet<ThreadUser> ThreadUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:socialplatform.database.windows.net;Database=socialplatform;User ID=grouptwo@socialplatform;Password=Secretpassword0;Trusted_Connection=False;Encrypt=True;");
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

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.CreatedDate)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.ThreadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Thread");
            });

            modelBuilder.Entity<Thread>(entity =>
            {
                entity.ToTable("Thread");

                entity.Property(e => e.CreatedDate)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Threads)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Thread_Category");
            });

            modelBuilder.Entity<ThreadUser>(entity =>
            {
                entity.HasOne(d => d.Thread)
                    .WithMany(p => p.ThreadUsers)
                    .HasForeignKey(d => d.ThreadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThreadUsers_Thread");
            });

            
        }

        
    }
}
