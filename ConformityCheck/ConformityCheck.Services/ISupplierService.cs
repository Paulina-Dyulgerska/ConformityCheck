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

        IEnumerable<ArticleExportDTO> ListArticles(int articleId);

        IEnumerable<ConformityDTO> ListConformities(int articleId);

        void UpdateSupplierInformation(int supplierId);

        void DeleteSupplier(int supplierId);

        void AddConformity(int supplierId);

        IEnumerable<SupplierExportDTO> SearchSupplier(int supplierId);

        IEnumerable<SupplierExportDTO> SearchByArticle(string articleNumber);

        IEnumerable<SupplierExportDTO> SearchByConformity(string conformityType);

    }
}
