﻿// <auto-generated />
using System;
using Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.DAL.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.EntityFrameworkHiLoSequence", "'EntityFrameworkHiLoSequence', '', '1', '10', '', '', 'Int64', 'False'");

            NpgsqlModelBuilderExtensions.UseHiLo(modelBuilder, "EntityFrameworkHiLoSequence");

            modelBuilder.HasSequence("EntityFrameworkHiLoSequence")
                .IncrementsBy(10);

            modelBuilder.Entity("Core.DAL.Entities.Adventure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndsOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartsOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Adventures", (string)null);
                });

            modelBuilder.Entity("Core.DAL.Entities.AdventureUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    b.Property<int>("AdventureId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.HasIndex("UserId");

                    b.ToTable("AdventureUsers", (string)null);
                });

            modelBuilder.Entity("Core.DAL.Entities.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    b.Property<int>("AdventureId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndsOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartsOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AdventureId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experiences", (string)null);
                });

            modelBuilder.Entity("Core.DAL.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("Core.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(450)
                        .HasColumnType("character varying(450)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Core.DAL.Entities.Adventure", b =>
                {
                    b.HasOne("Core.DAL.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Core.DAL.Entities.AdventureUser", b =>
                {
                    b.HasOne("Core.DAL.Entities.Adventure", "Adventure")
                        .WithMany("AdventureUsers")
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.DAL.Entities.User", "User")
                        .WithMany("AdventureUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adventure");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.DAL.Entities.Experience", b =>
                {
                    b.HasOne("Core.DAL.Entities.Adventure", "Adventure")
                        .WithMany("Experiences")
                        .HasForeignKey("AdventureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.DAL.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adventure");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Core.DAL.Entities.Adventure", b =>
                {
                    b.Navigation("AdventureUsers");

                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("Core.DAL.Entities.User", b =>
                {
                    b.Navigation("AdventureUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
