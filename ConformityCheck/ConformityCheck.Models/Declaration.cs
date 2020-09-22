using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConformityCheck.Models
{
    public class Declaration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(ConformityType))]
        public int ConformityTypeId { get; set; }
        public ConformityType ConformityType { get; set; }

        [Required]
        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? AcceptanceDate { get; set; }

        public bool IsAccepted { get; set; }
    }
}
