using System.ComponentModel.DataAnnotations.Schema;

namespace ConformityCheck.Models
{
    public class ProductConformity
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Conformity))]
        public int ConformityId { get; set; }
        public virtual Conformity Conformity { get; set; }
    }
}