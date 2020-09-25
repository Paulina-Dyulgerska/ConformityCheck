using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Substance
    {
        public Substance()
        {
            this.ArticleSubstances = new HashSet<ArticleSubstance>();
            this.SubstanceRegulationLists = new HashSet<SubstanceRegulationList>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string CASNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<SubstanceRegulationList> SubstanceRegulationLists { get; set; }

        public virtual ICollection<ArticleSubstance> ArticleSubstances { get; set; }
    }
}
