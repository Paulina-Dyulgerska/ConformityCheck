using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class Substance
    {
        public Substance()
        {
            this.Articles = new HashSet<ArticleSubstance>();
            this.RegulationLists = new HashSet<SubstanceRegulationList>();
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

        public virtual ICollection<SubstanceRegulationList> RegulationLists { get; set; }

        public virtual ICollection<ArticleSubstance> Articles { get; set; }
    }
}
