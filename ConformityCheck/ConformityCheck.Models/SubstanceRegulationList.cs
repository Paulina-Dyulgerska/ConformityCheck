using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConformityCheck.Models
{
    public class SubstanceRegulationList
    {
        [ForeignKey(nameof(Substance))]
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }

        [ForeignKey(nameof(RegulationList))]
        public int RegulationListId { get; set; }
        public RegulationList RegulationList { get; set; }

        public string Restriction { get; set; }
    }
}
