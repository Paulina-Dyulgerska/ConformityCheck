namespace ConformityCheck.Web.ViewModels.Conformities
{
    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class ConformityIdInputModel
    {
        [ConformityEntityAttribute]
        public string Id { get; set; }
    }
}
