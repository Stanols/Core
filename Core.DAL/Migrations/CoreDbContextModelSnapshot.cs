﻿// <auto-generated />
using System;
using Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Core.DAL.Migrations
{
	[DbContext(typeof(CoreDbContext))]
	partial class CoreDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("Npgsql:HiLoSequenceName", "EntityFrameworkHiLoSequence")
				.HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo)
				.HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
				.HasAnnotation("Relational:MaxIdentifierLength", 63)
				.HasAnnotation("Relational:Sequence:.EntityFrameworkHiLoSequence", "'EntityFrameworkHiLoSequence', '', '1', '10', '', '', 'Int64', 'False'");

			modelBuilder.Entity("Core.DAL.Entities.Adventure", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnName("Id")
						.HasColumnType("integer");

					b.Property<int>("CreatedById");

					b.Property<string>("Description");

					b.Property<DateTime>("EndsOn");

					b.Property<string>("Name");

					b.Property<DateTime>("StartsOn");

					b.HasKey("Id");

					b.HasIndex("CreatedById");

					b.ToTable("Adventures");
				});

			modelBuilder.Entity("Core.DAL.Entities.AdventureUser", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnName("Id")
						.HasColumnType("integer");

					b.Property<int>("AdventureId");

					b.Property<int>("UserId");

					b.HasKey("Id");

					b.HasIndex("AdventureId");

					b.HasIndex("UserId");

					b.ToTable("AdventureUsers");
				});

			modelBuilder.Entity("Core.DAL.Entities.Experience", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnName("Id")
						.HasColumnType("integer");

					b.Property<int>("AdventureId");

					b.Property<string>("Description");

					b.Property<DateTime>("EndsOn");

					b.Property<int>("LocationId");

					b.Property<string>("Name");

					b.Property<DateTime>("StartsOn");

					b.HasKey("Id");

					b.HasIndex("AdventureId");

					b.HasIndex("LocationId");

					b.ToTable("Experiences");
				});

			modelBuilder.Entity("Core.DAL.Entities.Location", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnName("Id")
						.HasColumnType("integer");

					b.Property<double>("Latitude");

					b.Property<double>("Longitude");

					b.Property<string>("Name");

					b.HasKey("Id");

					b.ToTable("Locations");
				});

			modelBuilder.Entity("Core.DAL.Entities.User", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnName("Id")
						.HasColumnType("integer");

					b.Property<string>("Email");

					b.Property<string>("FirstName");

					b.Property<string>("LastName");

					b.Property<string>("Name")
						.HasMaxLength(450);

					b.Property<byte[]>("PasswordHash");

					b.Property<byte[]>("PasswordSalt");

					b.HasKey("Id");

					b.HasIndex("Name")
						.IsUnique();

					b.ToTable("Users");
				});

			modelBuilder.Entity("Core.DAL.Entities.Adventure", b =>
				{
					b.HasOne("Core.DAL.Entities.User", "CreatedBy")
						.WithMany()
						.HasForeignKey("CreatedById")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("Core.DAL.Entities.AdventureUser", b =>
				{
					b.HasOne("Core.DAL.Entities.Adventure", "Adventure")
						.WithMany("AdventureUsers")
						.HasForeignKey("AdventureId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("Core.DAL.Entities.User", "User")
						.WithMany("AdventureUsers")
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("Core.DAL.Entities.Experience", b =>
				{
					b.HasOne("Core.DAL.Entities.Adventure", "Adventure")
						.WithMany("Experiences")
						.HasForeignKey("AdventureId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("Core.DAL.Entities.Location", "Location")
						.WithMany()
						.HasForeignKey("LocationId")
						.OnDelete(DeleteBehavior.Cascade);
				});
#pragma warning restore 612, 618
		}
	}
}
