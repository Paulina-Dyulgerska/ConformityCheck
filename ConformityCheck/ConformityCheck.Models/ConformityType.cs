using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConformityCheck.Models
{
    public class ConformityType
    {
        public ConformityType()
        {
            this.Conformities = new HashSet<Conformity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Conformity> Conformities { get; set; }
    }
}
