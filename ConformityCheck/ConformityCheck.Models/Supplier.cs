using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Supplier
    {
        public Supplier()
        {
            this.Articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}