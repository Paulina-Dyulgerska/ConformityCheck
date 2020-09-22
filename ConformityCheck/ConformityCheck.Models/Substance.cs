using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Substance
    {
        public Substance()
        {
            this.Articles = new HashSet<ArticleSubstance>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string CASNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<ArticleSubstance> Articles { get; set; }
    }
}
