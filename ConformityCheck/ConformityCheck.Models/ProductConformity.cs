using System.ComponentModel.DataAnnotations.Schema;

namespace ConformityCheck.Models
{
    public class ProductConformity
    {
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey(nameof(Conformity))]
        public int ConformityId { get; set; }
        public Conformity Conformity { get; set; }
    }
}