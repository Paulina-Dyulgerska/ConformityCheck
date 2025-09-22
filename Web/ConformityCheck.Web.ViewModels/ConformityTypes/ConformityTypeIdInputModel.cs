namespace ConformityCheck.Web.ViewModels.ConformityTypes
{
    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class ConformityTypeIdInputModel
    {
        [ConformityTypeEntityAttribute]
        public int Id { get; set; }
    }
}
