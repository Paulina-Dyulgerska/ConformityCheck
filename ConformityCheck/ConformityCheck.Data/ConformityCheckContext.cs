using ConformityCheck.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConformityCheck.Data
{
    public class ConformityCheckContext : DbContext
    {
        public ConformityCheckContext()
        {
        }

        public ConformityCheckContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ConformityType> ConformityTypes { get; set; }

        public DbSet<Conformity> Conformities { get; set; }

        public DbSet<Substance> Substances { get; set; }

        public DbSet<RegulationList> RegulationLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ConformityCheck;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleProduct>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.ProductId });

                e.HasOne(ap => ap.Article)
                .WithMany(p => p.Products)
                .HasForeignKey(ap => ap.ArticleId);

                e.HasOne(ap => ap.Product)
                .WithMany(a => a.Articles)
                .HasForeignKey(ap => ap.ProductId);
            });

            modelBuilder.Entity<ArticleConformity>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.ConformityId });

                e.HasOne(ac => ac.Article)
                .WithMany(a => a.Conformities)
                .HasForeignKey(c => c.ArticleId);

                e.HasOne(ac => ac.Conformity)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.ConformityId);
            });

            modelBuilder.Entity<ProductConformity>(e =>
            {
                e.HasKey(x => new { x.ProductId, x.ConformityId });

                e.HasOne(pc => pc.Product)
                .WithMany(p => p.Conformities)
                .HasForeignKey(c => c.ProductId);

                e.HasOne(pc => pc.Conformity)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ConformityId);
            });

            modelBuilder.Entity<ArticleSubstance>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.SubstanceId });

                e.HasOne(asub => asub.Article)
                .WithMany(a => a.Substances)
                .HasForeignKey(s => s.ArticleId);

                e.HasOne(asub => asub.Substance)
                .WithMany(s => s.Articles)
                .HasForeignKey(a => a.SubstanceId);
            });

            modelBuilder.Entity<SubstanceRegulationList>(e =>
            {
                e.HasKey(x => new { x.RegulationListId, x.SubstanceId });

                e.HasOne(srl => srl.RegulationList)
                .WithMany(rl => rl.Substances)
                .HasForeignKey(s => s.RegulationListId);

                e.HasOne(srl => srl.Substance)
                .WithMany(s => s.RegulationLists)
                .HasForeignKey(rl => rl.SubstanceId);
            });

            modelBuilder.Entity<Conformity>()
                .HasOne(c => c.ConformityType)
                .WithMany(ct => ct.Conformities)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConformityType>(e =>
            {
                e.HasMany(ct => ct.Conformities)
                .WithOne(c => c.ConformityType)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasIndex(ct => ct.Description)
                .IsUnique();
            });

            modelBuilder.Entity<Article>()
                .HasIndex(a => a.Number)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Number)
                .IsUnique();

            modelBuilder.Entity<Substance>()
                .HasIndex(s => s.CASNumber)
                .IsUnique();

            //modelBuilder.Entity<RegulationList>(); //da mu slagam li neshto ne znam oshte!
        }
    }
}
