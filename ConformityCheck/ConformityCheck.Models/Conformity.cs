﻿using System;
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

        [Required]
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ConformationAcceptanceDate { get; set; }

        public bool IsConfirmed { get; set; }

        public virtual ICollection<ArticleConformity> Articles { get; set; }

        public virtual ICollection<ProductConformity> Products { get; set; }
    }
}