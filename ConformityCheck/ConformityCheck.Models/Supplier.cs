using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.ArticleSuppliers = new HashSet<ArticleSupplier>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        public string ContactPersonFirstName { get; set; }

        [MaxLength(20)]
        public string ContactPersonLastName { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ArticleSupplier> ArticleSuppliers { get; set; }
    }
}