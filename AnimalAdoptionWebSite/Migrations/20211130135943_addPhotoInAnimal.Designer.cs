﻿// <auto-generated />
using System;
using AnimalAdoptionWebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalAdoptionWebSite.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211130135943_addPhotoInAnimal")]
    partial class addPhotoInAnimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Admin", b =>
                {
                    b.Property<byte>("ADMIN_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MAIL")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NAMESURNAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OCCUPATION")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("USERNAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ADMIN_ID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Adoption", b =>
                {
                    b.Property<byte>("ADOPTION_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ANIMAL_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("MEMBER_ID")
                        .HasColumnType("int");

                    b.HasKey("ADOPTION_ID");

                    b.HasIndex("ANIMAL_ID");

                    b.HasIndex("MEMBER_ID");

                    b.ToTable("Adoptions");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Animal", b =>
                {
                    b.Property<int>("ANIMAL_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AGE")
                        .HasColumnType("tinyint");

                    b.Property<string>("CITY")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("GENUS")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<byte>("KIND_ID")
                        .HasColumnType("tinyint");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PHOTO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("STATUS")
                        .HasColumnType("bit");

                    b.HasKey("ANIMAL_ID");

                    b.HasIndex("KIND_ID");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Kind", b =>
                {
                    b.Property<byte>("KIND_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TYPE_NAME")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("KIND_ID");

                    b.ToTable("Kinds");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Member", b =>
                {
                    b.Property<int>("MEMBER_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ABOUT")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ADDRESS")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<byte>("AGE")
                        .HasColumnType("tinyint");

                    b.Property<string>("MAIL")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NAMESURNAME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PHONENUMBER")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MEMBER_ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Adoption", b =>
                {
                    b.HasOne("AnimalAdoptionWebSite.Models.Animal", "Animal")
                        .WithMany("Adoptions")
                        .HasForeignKey("ANIMAL_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAdoptionWebSite.Models.Member", "Member")
                        .WithMany("Adoptions")
                        .HasForeignKey("MEMBER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Animal", b =>
                {
                    b.HasOne("AnimalAdoptionWebSite.Models.Kind", "Kind")
                        .WithMany("Animals")
                        .HasForeignKey("KIND_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kind");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Animal", b =>
                {
                    b.Navigation("Adoptions");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Kind", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("AnimalAdoptionWebSite.Models.Member", b =>
                {
                    b.Navigation("Adoptions");
                });
#pragma warning restore 612, 618
        }
    }
}
