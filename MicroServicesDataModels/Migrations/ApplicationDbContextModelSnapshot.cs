﻿// <auto-generated />
using System;
using MicroServicesDataModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroServicesDataModels.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MicroServicesDataModels.Models.Attribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 15, 16, 14, 13, 240, DateTimeKind.Utc).AddTicks(2752));

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 15, 16, 14, 13, 240, DateTimeKind.Utc).AddTicks(6478));

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.HasIndex("EventDate");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.Link", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 15, 16, 14, 13, 240, DateTimeKind.Utc).AddTicks(7982));

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<long>("EventId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.HasIndex("Url");

                    b.HasIndex("EventId", "Url");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 15, 16, 14, 13, 240, DateTimeKind.Utc).AddTicks(9392));

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.PersonAttribute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<long>("AttributeId");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 15, 16, 14, 13, 241, DateTimeKind.Utc).AddTicks(1018));

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<long>("PersonId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("PersonId", "AttributeId");

                    b.ToTable("PersonAttributes");
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.PersonEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 15, 16, 14, 13, 241, DateTimeKind.Utc).AddTicks(2383));

                    b.Property<string>("CreatedBy");

                    b.Property<long>("EventId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<long>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PersonId", "EventId")
                        .IsUnique();

                    b.ToTable("PersonEvents");
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.Link", b =>
                {
                    b.HasOne("MicroServicesDataModels.Models.Event", "Event")
                        .WithMany("Links")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.PersonAttribute", b =>
                {
                    b.HasOne("MicroServicesDataModels.Models.Attribute", "Attribute")
                        .WithMany("PersonAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MicroServicesDataModels.Models.Person", "Person")
                        .WithMany("PersonAttributes")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MicroServicesDataModels.Models.PersonEvent", b =>
                {
                    b.HasOne("MicroServicesDataModels.Models.Event", "Event")
                        .WithMany("PersonEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MicroServicesDataModels.Models.Person", "Person")
                        .WithMany("PersonEvents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
