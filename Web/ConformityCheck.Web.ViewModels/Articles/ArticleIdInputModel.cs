namespace ConformityCheck.Web.ViewModels.Articles
{
    using ConformityCheck.Web.ViewModels.ValidationAttributes;

    public class ArticleIdInputModel
    {
        [ArticleEntityAttribute]
        public string Id { get; set; }
    }
}
