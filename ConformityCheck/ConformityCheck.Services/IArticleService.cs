using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System.Collections.Generic;

namespace ConformityCheck.Services
{
    public interface IArticleService
    {
        public Article GetArticle(int articleId);

        public void Create(ArticleImportDTO articleImportDTO);

        public void AddSupplierToArticle(Article article, SupplierImportDTO supplierImportDTO);

        public Supplier GetOrCreateSupplier(SupplierImportDTO supplierImportDTO);

        public bool DeleteArticle(int articleId);

        public void DeleteSupplierFromArticle(int articleId);

        public void ShowSupplierList(int articleId);

        public IEnumerable<SupplierExportDTO> ListArticleSuppliers(int articleId);

        public IEnumerable<ConformityDTO> ListArticleConformities(int articleId);

        public void UpdateArticle(int articleId);

        public void AddConformity(int articleId);

        public IEnumerable<ArticleExportDTO> SearchArticle(int artileId);

        public IEnumerable<ArticleExportDTO> SearchBySupplier(string supplierNumber);

        public IEnumerable<ArticleExportDTO> SearchByConformity(string conformityType);

        public IEnumerable<ArticleExportDTO> SearchByStatus(string status); //confirmed or not

    }
}
