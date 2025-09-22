namespace ConformityCheck.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;

    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class ArticleManageSuppliersInputModel
    {
        [ArticleEntityAttribute]
        [Display(Name = "Article")]
        public string Id { get; set; }

        [SupplierEntityAttribute]
        [Display(Name = "Supplier")]
        public string SupplierId { get; set; }
    }
}
