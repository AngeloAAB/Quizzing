using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuizzingDAL.Models;

namespace QuizzingDAL.Data
{
    public partial class QuizzingDbContext : DbContext
    {
        public QuizzingDbContext()
        {
        }

        public QuizzingDbContext(DbContextOptions<QuizzingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<CorrectAnswer> CorrectAnswer { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Multiplechoice> Multiplechoice { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Result> Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ANGOTHEB-MPC\\SQLSERVER2019;Initial Catalog=QuizzingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Answer1)
                    .HasColumnName("Answer")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CorrectAnswer>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.AnswerId });

                entity.ToTable("correctAnswer");

                entity.HasIndex(e => e.AnswerId);

                entity.HasIndex(e => new { e.AnswerId, e.QuestionId })
                    .HasName("AK_correctAnswer_AnswerId_QuestionId_M")
                    .IsUnique();

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.CorrectAnswer)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_correctAnswer_Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.CorrectAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cAnswer_Question");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(75);

                entity.Property(e => e.Theme).HasMaxLength(50);
            });

            modelBuilder.Entity<Multiplechoice>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.AnswerId });

                entity.HasIndex(e => e.AnswerId);

                entity.HasIndex(e => new { e.AnswerId, e.QuestionId })
                    .HasName("AK_Multiplechoice_AnswerId_QuestionId_M")
                    .IsUnique();

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.Multiplechoice)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Multiplechoice_Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Multiplechoice)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Multiplechoice_Question");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AQuestion)
                    .HasColumnName("aQuestion")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Question_Exam");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.HasIndex(e => e.ResultId);

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.Reply)
                    .HasForeignKey(d => d.ResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Result");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.Property(e => e.Score).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
