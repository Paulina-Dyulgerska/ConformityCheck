﻿// <auto-generated />
using System;
using ConformityCheck.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConformityCheck.Data.Migrations
{
    [DbContext(typeof(ConformityCheckContext))]
    [Migration("20200927185805_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConformityCheck.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleConformity", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("ConformityId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "ConformityId");

                    b.HasIndex("ConformityId");

                    b.ToTable("ArticleConformity");
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleProduct", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ArticleProduct");
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleSubstance", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("SubstanceId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "SubstanceId");

                    b.HasIndex("SubstanceId");

                    b.ToTable("ArticleSubstance");
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleSupplier", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ArticleSuppliers");
                });

            modelBuilder.Entity("ConformityCheck.Models.Conformity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ConformationAcceptanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConformityTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConformityTypeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Conformities");
                });

            modelBuilder.Entity("ConformityCheck.Models.ConformityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.ToTable("ConformityTypes");
                });

            modelBuilder.Entity("ConformityCheck.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ConformityCheck.Models.ProductConformity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ConformityId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ConformityId");

                    b.HasIndex("ConformityId");

                    b.ToTable("ProductConformity");
                });

            modelBuilder.Entity("ConformityCheck.Models.RegulationList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.ToTable("RegulationLists");
                });

            modelBuilder.Entity("ConformityCheck.Models.Substance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CASNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CASNumber")
                        .IsUnique();

                    b.ToTable("Substances");
                });

            modelBuilder.Entity("ConformityCheck.Models.SubstanceRegulationList", b =>
                {
                    b.Property<int>("RegulationListId")
                        .HasColumnType("int");

                    b.Property<int>("SubstanceId")
                        .HasColumnType("int");

                    b.Property<string>("Restriction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegulationListId", "SubstanceId");

                    b.HasIndex("SubstanceId");

                    b.ToTable("SubstanceRegulationList");
                });

            modelBuilder.Entity("ConformityCheck.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactPersonFirstName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ContactPersonLastName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleConformity", b =>
                {
                    b.HasOne("ConformityCheck.Models.Article", "Article")
                        .WithMany("ArticleConformities")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Conformity", "Conformity")
                        .WithMany("ArticleConformities")
                        .HasForeignKey("ConformityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleProduct", b =>
                {
                    b.HasOne("ConformityCheck.Models.Article", "Article")
                        .WithMany("ArticleProducts")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Product", "Product")
                        .WithMany("ArticleProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleSubstance", b =>
                {
                    b.HasOne("ConformityCheck.Models.Article", "Article")
                        .WithMany("ArticleSubstances")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Substance", "Substance")
                        .WithMany("ArticleSubstances")
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConformityCheck.Models.ArticleSupplier", b =>
                {
                    b.HasOne("ConformityCheck.Models.Article", "Article")
                        .WithMany("ArticleSuppliers")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Supplier", "Supplier")
                        .WithMany("ArticleSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConformityCheck.Models.Conformity", b =>
                {
                    b.HasOne("ConformityCheck.Models.ConformityType", "ConformityType")
                        .WithMany("Conformities")
                        .HasForeignKey("ConformityTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConformityCheck.Models.ProductConformity", b =>
                {
                    b.HasOne("ConformityCheck.Models.Conformity", "Conformity")
                        .WithMany("ProductConformities")
                        .HasForeignKey("ConformityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Product", "Product")
                        .WithMany("ProductConformities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConformityCheck.Models.SubstanceRegulationList", b =>
                {
                    b.HasOne("ConformityCheck.Models.RegulationList", "RegulationList")
                        .WithMany("SubstanceRegulationLists")
                        .HasForeignKey("RegulationListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConformityCheck.Models.Substance", "Substance")
                        .WithMany("SubstanceRegulationLists")
                        .HasForeignKey("SubstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
