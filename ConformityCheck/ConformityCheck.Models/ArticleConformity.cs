using System.ComponentModel.DataAnnotations.Schema;

namespace ConformityCheck.Models
{
    public class ArticleConformity
    {
        [ForeignKey(nameof(Article))]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        [ForeignKey(nameof(Conformity))]
        public int ConformityId { get; set; }
        public Conformity Conformity { get; set; }
    }
}
