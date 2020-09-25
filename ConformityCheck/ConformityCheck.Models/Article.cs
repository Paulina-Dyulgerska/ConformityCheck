using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConformityCheck.Models
{
    public class Article
    {
        public Article()
        {
            this.Products = new HashSet<ArticleProduct>();
            this.Conformities = new HashSet<ArticleConformity>();
            this.Substances = new HashSet<ArticleSubstance>();
            this.Suppliers = new HashSet<ArticleSupplier>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        //[ForeignKey(nameof(Supplier))]
        //public int? MainSupplierID { get; set; }
        //public virtual Supplier MainSupplier { get; set; }
        
        public bool IsDeleted { get; set; }

        public virtual ICollection<ArticleProduct> Products { get; set; }

        public virtual ICollection<ArticleConformity> Conformities { get; set; }

        public virtual ICollection<ArticleSubstance> Substances { get; set; }

        public virtual ICollection<ArticleSupplier> Suppliers { get; set; }
    }
}
