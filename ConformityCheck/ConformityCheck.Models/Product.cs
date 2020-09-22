using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Product
    {
        public Product()
        {
            this.Articles = new HashSet<ArticleProduct>();
            this.Conformities = new HashSet<ProductConformity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<ArticleProduct> Articles { get; set; }

        public virtual ICollection<ProductConformity> Conformities { get; set; }
    }
}
