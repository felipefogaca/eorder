﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eOrder.Infra;

#nullable disable

namespace eOrder.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230128171023_Rules")]
    partial class Rules
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eOrder.Domain.Customers.Entities.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("ReceiveMail")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contacts", (string)null);
                });

            modelBuilder.Entity("eOrder.Domain.Customers.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Code"), false);

                    b.HasIndex("Document");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Document"), false);

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("eOrder.Domain.Rules.Entity.Rule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParameterOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParameterType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RunOnModification")
                        .HasColumnType("bit");

                    b.Property<bool>("RunOnNews")
                        .HasColumnType("bit");

                    b.Property<string>("SituationOnApprove")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituationOnDisapprove")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("eOrder.Domain.Customers.Entities.Contact", b =>
                {
                    b.HasOne("eOrder.Domain.Customers.Entities.Customer", null)
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eOrder.Domain.Customers.Entities.Customer", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
