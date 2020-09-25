using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System.Collections.Generic;

namespace ConformityCheck.Services
{
    public interface IArticleService
    {
        public void Create(string number, string description, string supplierNumber, string supplierName,
            string supplierEmail, string supplierPhoneNumber, string contactPersonFirstName,
            string contactPersonLastName);

        public void AddSupplierToArticle(Article article, string supplierNumber, string supplierName,
                                        string supplierEmail, string supplierPhoneNumber,
                                        string contactPersonFirstName,
                                        string contactPersonLastName);

        public Supplier GetOrCreateSupplier(string supplierNumber, string supplierName, string supplierEmail,
            string supplierPhoneNumber, string contactPersonFirstName, string contactPersonLastName);

        IEnumerable<SupplierViewModel> ListArticleSuppliers(int articleId);

        IEnumerable<ConformityViewModel> ListArticleConformities(int articleId);

        void UpdateSupplierList(int articleId);

        void UpdateArticle(int articleId);

        void DeleteArticle(int articleId);

        void AddConformity(int articleId);

        IEnumerable<ArticleViewModel> SearchArticle(int artileId);

        IEnumerable<ArticleViewModel> SearchBySupplier(string supplierNumber);

        IEnumerable<ArticleViewModel> SearchByConformity(string conformityType);

        IEnumerable<ArticleViewModel> SearchByStatus(string status); //confirmed or not

    }
}
