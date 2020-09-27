﻿using ConformityCheck.Models;
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

        public IEnumerable<string> GetSuppliersNuumbersList(int articleId);
        public int GetSuppliersCount(int articleId);


        public IEnumerable<SupplierExportDTO> ListArticleSuppliers(int articleId);

        public IEnumerable<ConformityDTO> ListArticleConformities(int articleId);
        public IEnumerable<ProductDTO> ListArticleProducts(int articleId);

        public void UpdateArticle(ArticleImportDTO articleImportDTO);

        public void AddConformity(int articleId);

        public IEnumerable<ArticleExportDTO> SearchArticle(int artileId);

        public IEnumerable<ArticleExportDTO> SearchBySupplier(string supplierNumber);

        public IEnumerable<ArticleExportDTO> SearchByConformity(string conformityType);

        public IEnumerable<ArticleExportDTO> SearchByStatus(string status); //confirmed or not



    }
}
