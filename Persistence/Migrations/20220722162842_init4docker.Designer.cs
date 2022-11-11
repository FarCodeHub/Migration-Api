﻿ 
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(MigrationContext))]
    [Migration("20220722162842_init4docker")]
    partial class init4docker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Domain.Entities.Lawyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Lawyer");
                });

            modelBuilder.Entity("Domain.Entities.LawyerCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LawyerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LawyerId");

                    b.ToTable("LawyerCondition");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("IsMarried")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisaExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisaStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisaType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Entities.PersonCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LawyerConditionId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LawyerConditionId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonCondition");
                });

            modelBuilder.Entity("Domain.Entities.PersonLawyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LawyerId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LawyerId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonLawyer");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasFilter("[PersonId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Visa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisaExpairationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisaStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisaType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Visas");
                });

            modelBuilder.Entity("Domain.Entities.Attachment", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Attachments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.LawyerCondition", b =>
                {
                    b.HasOne("Domain.Entities.Lawyer", "Lawyer")
                        .WithMany("LawyerCondition")
                        .HasForeignKey("LawyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lawyer");
                });

            modelBuilder.Entity("Domain.Entities.PersonCondition", b =>
                {
                    b.HasOne("Domain.Entities.LawyerCondition", "LawyerCondition")
                        .WithMany("PersonConditions")
                        .HasForeignKey("LawyerConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("PersonConditions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LawyerCondition");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.PersonLawyer", b =>
                {
                    b.HasOne("Domain.Entities.Lawyer", "Lawyer")
                        .WithMany("PersonLawyers")
                        .HasForeignKey("LawyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("PersonLawyers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lawyer");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.User", "PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.Visa", b =>
                {
                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithOne("Visa")
                        .HasForeignKey("Domain.Entities.Visa", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.Lawyer", b =>
                {
                    b.Navigation("LawyerCondition");

                    b.Navigation("PersonLawyers");
                });

            modelBuilder.Entity("Domain.Entities.LawyerCondition", b =>
                {
                    b.Navigation("PersonConditions");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Navigation("PersonConditions");

                    b.Navigation("PersonLawyers");

                    b.Navigation("User");

                    b.Navigation("Visa");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
