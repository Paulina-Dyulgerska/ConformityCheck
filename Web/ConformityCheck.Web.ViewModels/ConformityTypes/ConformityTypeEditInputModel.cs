namespace ConformityCheck.Web.ViewModels.ConformityTypes
{
    using ConformityCheck.Data.Models;
    using ConformityCheck.Services.Mapping;
    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class ConformityTypeEditInputModel : ConformityTypeBaseModel, IMapFrom<ConformityType>
    {
        [ConformityTypeEntityAttribute]
        public int Id { get; set; }
    }
}
