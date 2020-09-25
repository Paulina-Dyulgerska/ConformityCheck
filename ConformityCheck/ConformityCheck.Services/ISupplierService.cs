using ConformityCheck.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConformityCheck.Services
{
    public interface ISupplierService
    {
        void Create(string number, string name);

        void AddArticle(int supplierId, int articleId);

        void DeleteArticle(int supplierId, int articleId);

        IEnumerable<ArticleViewModel> ListArticles(int articleId);

        IEnumerable<ConformityViewModel> ListConformities(int articleId);

        void UpdateSupplierInformation(int supplierId);

        void DeleteSupplier(int supplierId);

        void AddConformity(int supplierId);

        IEnumerable<SupplierViewModel> SearchSupplier(int supplierId);

        IEnumerable<SupplierViewModel> SearchByArticle(string articleNumber);

        IEnumerable<SupplierViewModel> SearchByConformity(string conformityType);

    }
}
