using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
   public class RegulationList
    {
        public RegulationList()
        {
            this.Substances = new HashSet<SubstanceRegulationList>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<SubstanceRegulationList> Substances { get; set; }
    }
}
