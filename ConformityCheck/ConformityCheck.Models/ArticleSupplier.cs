using System;
using System.Collections.Generic;
using System.Text;

namespace ConformityCheck.Models
{
    public class ArticleSupplier
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
