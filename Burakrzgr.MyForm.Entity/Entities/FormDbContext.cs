using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Burakrzgr.MyForm.Entity.Entities
{
    //Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\burak\Documents\DBMyForm.mdf;Integrated Security=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ../Burakrzgr.MyForm.Entity/Entities
    public partial class FormDbContext : DbContext
    {
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
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\burak\\Documents\\DBMyForm.mdf;Integrated Security=True;Connect Timeout=30");
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
                entity.HasNoKey();

                entity.ToTable("FormBroadcast");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FormTemplate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FormTemplate");

                entity.Property(e => e.DateOfCreate).HasColumnType("datetime");

                entity.Property(e => e.FormDesc).HasMaxLength(500);

                entity.Property(e => e.FormName).HasMaxLength(250);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PersonalInfo)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<QuestionTemplate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuestionTemplate");

                entity.Property(e => e.AnswerStr1).HasMaxLength(250);

                entity.Property(e => e.AnswerStr2).HasMaxLength(250);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<QuestionTemplateChoice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuestionTemplate_Choice");

                entity.HasIndex(e => new { e.QuestionTemplateId, e.ChoiceId }, "QuestionTemplate_Choice_unique")
                    .IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(70);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
