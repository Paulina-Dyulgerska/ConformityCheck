using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System.Collections.Generic;

namespace ConformityCheck.Services
{
    public interface IArticleService
    {
        public Article GetArticle(int articleId);

        public Supplier GetSupplier(int supplierId);
       
        public void Create(ArticleImportDTO articleImportDTO);

        public void AddSupplierToArticle(Article article, ArticleImportDTO articleImportDTO);

        public Supplier GetOrCreateSupplier(ArticleImportDTO articleImportDTO);

        public int DeleteArticle(int articleId);

        public void DeleteSupplierFromArticle(int articleId, int supplierId);

        public IEnumerable<string> GetSuppliersNumbersList(int articleId);
        public int GetSuppliersCount(int articleId);


        public IEnumerable<SupplierExportDTO> ListArticleSuppliers(int articleId);

        public IEnumerable<ConformityImportDTO> ListArticleConformities(int articleId);
        public IEnumerable<ProductDTO> ListArticleProducts(int articleId);

        public void UpdateArticle(ArticleImportDTO articleImportDTO);

<<<<<<< HEAD
        public void AddConformityToArticle(int articleId, int supplierId, ArticleConformityImportDTO articleConformityImportDTO);

        public void DeleteConformity(int articleId);

        public IEnumerable<ArticleExportDTO> SearchByArticleNumber(int artileId);

        public IEnumerable<ArticleExportDTO> SearchBySupplierNumber(string supplierNumber);

        public IEnumerable<ArticleExportDTO> SearchByConformityType(string conformityType);

=======
        public void AddConformity(int articleId);
        public void DeleteConformity(int articleId);

        public IEnumerable<ArticleExportDTO> SearchByArticleNumber(int artileId);

        public IEnumerable<ArticleExportDTO> SearchBySupplierNumber(string supplierNumber);

        public IEnumerable<ArticleExportDTO> SearchByConformityType(string conformityType);

>>>>>>> 992932ed973c22a65cb4ab45f36ebb63e9c4a67b
        public IEnumerable<ArticleExportDTO> SearchByConfirmedStatus(string status); //confirmed or not



    }
}
