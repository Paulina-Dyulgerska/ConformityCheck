using System.ComponentModel.DataAnnotations.Schema;

namespace ConformityCheck.Models
{
    public class ArticleSubstance
    {
        [ForeignKey(nameof(Article))]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        [ForeignKey(nameof(Substance))]
        public int SubstanceId { get; set; }
        public Substance Substance { get; set; }
    }
}