namespace ConformityCheck.Web.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class SupplierArticlesDetailsInputModel : PagingViewModel
    {
        [Required]
        [SupplierEntityAttribute]
        public string Id { get; set; }
    }
}
