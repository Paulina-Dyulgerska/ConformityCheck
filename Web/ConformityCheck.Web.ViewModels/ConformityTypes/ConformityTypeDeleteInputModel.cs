namespace ConformityCheck.Web.ViewModels.ConformityTypes
{
    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class ConformityTypeDeleteInputModel
    {
        [ConformityTypeEntityAttribute]
        [ConformityTypeUsageAttribute]
        public int Id { get; set; }
    }
}
