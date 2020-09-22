using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Conformity
    {
        public Conformity()
        {
            this.Articles = new HashSet<ArticleConformity>();
            this.Products = new HashSet<ProductConformity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public ConformityType ConformityType { get; set; }

        [Required]
        public bool IsConfirmed { get; set; }

        public DateTime? ConformationDate { get; set; }

        public virtual ICollection<ArticleConformity> Articles { get; set; }

        public virtual ICollection<ProductConformity> Products { get; set; }
    }
}
