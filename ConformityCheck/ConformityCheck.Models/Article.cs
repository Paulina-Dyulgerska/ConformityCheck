using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
   public class Article
    {
        public Article()
        {
            this.Products = new HashSet<ArticleProduct>();
            this.Conformities = new HashSet<ArticleConformity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ArticleProduct> Products { get; set; }

        public virtual ICollection<ArticleConformity> Conformities { get; set; }
    }
}
