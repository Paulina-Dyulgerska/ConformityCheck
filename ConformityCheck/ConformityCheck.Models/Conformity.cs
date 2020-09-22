using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(ConformityType))]
        public int ConformityTypeId { get; set; }
        public virtual ConformityType ConformityType { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime? ConformationDate { get; set; }

        public virtual ICollection<ArticleConformity> Articles { get; set; }

        public virtual ICollection<ProductConformity> Products { get; set; }
    }
}
