﻿using System.Collections.Generic;
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
        public string Number { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ArticleProduct> Articles { get; set; }

        public virtual ICollection<ProductConformity> Conformities { get; set; }
    }
}
