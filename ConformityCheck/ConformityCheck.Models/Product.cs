using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Product
    {
        public Product()
        {
            this.ArticleProducts = new HashSet<ArticleProduct>();
            this.ProductConformities = new HashSet<ProductConformity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ArticleProduct> ArticleProducts { get; set; }

        public virtual ICollection<ProductConformity> ProductConformities { get; set; }
    }
}
