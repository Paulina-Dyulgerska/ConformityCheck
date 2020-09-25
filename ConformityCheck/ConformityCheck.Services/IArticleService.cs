using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System.Collections.Generic;

namespace ConformityCheck.Services
{
    public interface IArticleService
    {
        public void Create(ArticleImportDTO articleImportDTO);

        public void AddSupplierToArticle(Article article, SupplierImportDTO supplierImportDTO);

        public Supplier GetOrCreateSupplier(SupplierImportDTO supplierImportDTO);

        bool DeleteArticle(int articleId);

        IEnumerable<SupplierExportDTO> ListArticleSuppliers(int articleId);

        IEnumerable<ConformityDTO> ListArticleConformities(int articleId);

        void UpdateSupplierList(int articleId);

        void UpdateArticle(int articleId);

        void AddConformity(int articleId);

        IEnumerable<ArticleExportDTO> SearchArticle(int artileId);

        IEnumerable<ArticleExportDTO> SearchBySupplier(string supplierNumber);

        IEnumerable<ArticleExportDTO> SearchByConformity(string conformityType);

        IEnumerable<ArticleExportDTO> SearchByStatus(string status); //confirmed or not

    }
}
