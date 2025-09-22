namespace ConformityCheck.Web.ViewModels.Suppliers
{
    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class SupplierIdInputModel
    {
        [SupplierEntityAttribute]
        public string Id { get; set; }
    }
}
