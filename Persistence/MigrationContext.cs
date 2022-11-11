using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
 

namespace Persistence
{
    public partial class MigrationContext : DbContext
    {
        public MigrationContext()
        {
        }

        public MigrationContext(DbContextOptions<MigrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Lawyer> Lawyers { get; set; }
        public virtual DbSet<LawyerCondition> LawyerConditions { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonCondition> PersonConditions { get; set; }
        public virtual DbSet<PersonLawyer> PersonLawyers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketItem> TicketItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visa> Visas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Database=.;initial catalog=MigrationDb;persist security info=True;user id=sa;password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Lawyer>(entity =>
            {
                entity.ToTable("Lawyer");
            });

            modelBuilder.Entity<LawyerCondition>(entity =>
            {
                entity.ToTable("LawyerCondition");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Lawyer)
                    .WithMany(p => p.LawyerConditions)
                    .HasForeignKey(d => d.LawyerId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.VisaExpirationDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            modelBuilder.Entity<PersonCondition>(entity =>
            {
                entity.ToTable("PersonCondition");

                entity.HasOne(d => d.LawyerCondition)
                    .WithMany(p => p.PersonConditions)
                    .HasForeignKey(d => d.LawyerConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonCondition_LawyerCondition");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonConditions)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<PersonLawyer>(entity =>
            {
                entity.ToTable("PersonLawyer");

                entity.HasOne(d => d.Lawyer)
                    .WithMany(p => p.PersonLawyers)
                    .HasForeignKey(d => d.LawyerId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonLawyers)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Users");
            });

            modelBuilder.Entity<TicketItem>(entity =>
            {
                entity.ToTable("TicketItem");

                entity.Property(e => e.Descriptions)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasComment("1-new\r\n2-read\r\n3-answerd");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketItems)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketItem_Ticket");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Visa>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Visas)
                    .HasForeignKey(d => d.PersonId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
