using ConformityCheck.Models;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<SubstanceRegulationList> SubstanceRegulationLists { get; set; }

        public DbSet<ArticleSupplier> ArticleSuppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ConformityCheck;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleProduct>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.ProductId });

                e.HasOne(ap => ap.Article)
                .WithMany(p => p.ArticleProducts)
                .HasForeignKey(ap => ap.ArticleId);

                e.HasOne(ap => ap.Product)
                .WithMany(a => a.ArticleProducts)
                .HasForeignKey(ap => ap.ProductId);
            });

            modelBuilder.Entity<ArticleConformity>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.ConformityId });

                e.HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleConformities)
                .HasForeignKey(c => c.ArticleId);

                e.HasOne(ac => ac.Conformity)
                .WithMany(c => c.ArticleConformities)
                .HasForeignKey(a => a.ConformityId);
            });

            modelBuilder.Entity<ProductConformity>(e =>
            {
                e.HasKey(x => new { x.ProductId, x.ConformityId });

                e.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductConformities)
                .HasForeignKey(c => c.ProductId);

                e.HasOne(pc => pc.Conformity)
                .WithMany(c => c.ProductConformities)
                .HasForeignKey(p => p.ConformityId);
            });

            modelBuilder.Entity<ArticleSubstance>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.SubstanceId });

                e.HasOne(asub => asub.Article)
                .WithMany(a => a.ArticleSubstances)
                .HasForeignKey(s => s.ArticleId);

                e.HasOne(asub => asub.Substance)
                .WithMany(s => s.ArticleSubstances)
                .HasForeignKey(a => a.SubstanceId);
            });


            modelBuilder.Entity<ArticleSupplier>(e =>
            {
                e.HasKey(x => new { x.ArticleId, x.SupplierId });

                e.HasOne(asup => asup.Article)
                .WithMany(a => a.ArticleSuppliers)
                .HasForeignKey(s => s.ArticleId);

                e.HasOne(asup => asup.Supplier)
                .WithMany(s => s.ArticleSuppliers)
                .HasForeignKey(a => a.SupplierId);
            });
            
            modelBuilder.Entity<SubstanceRegulationList>(e =>
            {
                e.HasKey(x => new { x.RegulationListId, x.SubstanceId });

                e.HasOne(srl => srl.RegulationList)
                .WithMany(rl => rl.SubstanceRegulationLists)
                .HasForeignKey(s => s.RegulationListId);

                e.HasOne(srl => srl.Substance)
                .WithMany(s => s.SubstanceRegulationLists)
                .HasForeignKey(rl => rl.SubstanceId);
            });

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Number)
                .IsUnique();

            modelBuilder.Entity<Substance>()
                .HasIndex(s => s.CASNumber)
                .IsUnique();

            modelBuilder.Entity<RegulationList>()
                .HasIndex(rl => rl.Description)
                .IsUnique();

            modelBuilder.Entity<Article>(e =>
            {
                e.HasIndex(a => a.Number)
                 .IsUnique();
            });

            modelBuilder.Entity<ConformityType>(e =>
            {
                e.HasMany(ct => ct.Conformities)
                .WithOne(c => c.ConformityType)
                .OnDelete(DeleteBehavior.Restrict); //ne moje da se iztrie ConformityType, predi
                                                    //da se iztriqt vsichki Conformities, koito sa ot tozi type!

                e.HasIndex(ct => ct.Description)
                .IsUnique();
            });


            //da setna da se nulira zapisa na SupplierID v Article pri del 
            //na Supplier - TODO! 

            //modelBuilder.Entity<RegulationList>(); //da mu slagam li neshto ne znam oshte! TODO

            //mislq, che towa ne mi trqbwa weche, zashtoto gi vyrzah many-to-many
            //modelBuilder.Entity<Supplier>()
            //    .HasMany(s => s.Articles)
            //    .WithOne(a => a.Supplier)
            //    .OnDelete(DeleteBehavior.Restrict);//ne moje da se iztrie Supplier, predi
            //da se iztriqt vsichki Articles, koito sa s tozi Supplier!
        }
    }
}
