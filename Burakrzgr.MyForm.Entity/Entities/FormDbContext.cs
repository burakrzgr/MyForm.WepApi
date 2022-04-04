using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class FormDbContext : DbContext
    {
        //Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\burak\source\repos\Burakrzgr.MyForm.WepApi\Database\DBMyForm.mdf;Integrated Security=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ../Burakrzgr.MyForm.Entity/Entities -force
        public FormDbContext()
        {
        }

        public FormDbContext(DbContextOptions<FormDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Choice> Choices { get; set; } = null!;
        public virtual DbSet<FormBroadcast> FormBroadcasts { get; set; } = null!;
        public virtual DbSet<FormTemplate> FormTemplates { get; set; } = null!;
        public virtual DbSet<QuestionTemplate> QuestionTemplates { get; set; } = null!;
        public virtual DbSet<QuestionTemplateChoice> QuestionTemplateChoices { get; set; } = null!;
        public virtual DbSet<SubmittedForm> SubmitedForms { get; set; } = null!;
        public virtual DbSet<SubmittedQuestionChoice> SubmitedQuestionChoices { get; set; } = null!;
        public virtual DbSet<SubmittedQuestion> SubmittedQuestions { get; set; } = null!;
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\burak\\source\\repos\\Burakrzgr.MyForm.WepApi\\Database\\DBMyForm.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>(entity =>
            {
                entity.ToTable("Choice");

                entity.Property(e => e.ChoiceText).HasMaxLength(100);
            });

            modelBuilder.Entity<FormBroadcast>(entity =>
            {
                entity.ToTable("FormBroadcast");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FormTemplate>(entity =>
            {
                entity.ToTable("FormTemplate");

                entity.Property(e => e.DateOfCreate).HasColumnType("datetime");

                entity.Property(e => e.FormDesc).HasMaxLength(500);

                entity.Property(e => e.FormName).HasMaxLength(250);
            });

            modelBuilder.Entity<QuestionTemplate>(entity =>
            {
                entity.ToTable("QuestionTemplate");

                entity.Property(e => e.QuestionText).HasMaxLength(250);
            });

            modelBuilder.Entity<QuestionTemplateChoice>(entity =>
            {
                entity.HasKey(e => new { e.QuestionTemplateId, e.ChoiceId });

                entity.ToTable("QuestionTemplate_Choice");

                entity.HasIndex(e => new { e.QuestionTemplateId, e.ChoiceId }, "QuestionTemplate_Choice_unique")
                    .IsUnique();
            });

            modelBuilder.Entity<SubmittedForm>(entity =>
            {
                entity.ToTable("SubmitedForm");
            });

            modelBuilder.Entity<SubmittedQuestionChoice>(entity =>
            {
                entity.HasKey(e => new { e.SubmitedQuestionId, e.ChoiceId });

                entity.ToTable("SubmitedQuestion_Choice");

                entity.HasIndex(e => new { e.SubmitedQuestionId, e.ChoiceId }, "SubmitedQuestion_Choice_unique")
                    .IsUnique();
            });

            modelBuilder.Entity<SubmittedQuestion>(entity =>
            {
                entity.ToTable("SubmittedQuestion");
            });

            modelBuilder.Entity<UploadedFile>(entity =>
            {
                entity.ToTable("UploadedFile");

                entity.Property(e => e.Extension).HasMaxLength(10);

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.UploadedFile1)
                    .HasMaxLength(250)
                    .HasColumnName("UploadedFile");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(70);

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
