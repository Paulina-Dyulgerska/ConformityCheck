using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConformityCheck.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ConformityCheckContext db;

        public ArticleService(ConformityCheckContext db)
        {
            this.db = db;
        }

        public void Create(ArticleImportDTO articleImportDTO)
        {
            if (this.db.Articles.FirstOrDefault(x => x.Number == articleImportDTO.Number) != null) //TODO - async-await
            {
                throw new ArgumentException($"There is already an article with this number");
            }

            var article = new Article
            {
                Number = articleImportDTO.Number.Trim().ToUpper(),
                Description = articleImportDTO.Description.Trim().ToUpper(),
            };

            db.Articles.Add(article);

            this.db.SaveChanges(); //async-await

            if (articleImportDTO.SupplierName != null && articleImportDTO.SupplierNumber != null)
            {
                this.AddSupplierToArticle(article.Id, articleImportDTO);
            }

        }

        public void AddSupplierToArticle(int articleId, ArticleImportDTO articleImportDTO)
        {
            var supplier = this.GetOrCreateSupplier(articleImportDTO);

            this.GetArticle(articleId).Suppliers.Add(new ArticleSupplier { Supplier = supplier });

            this.db.SaveChanges(); //async-await
        }

        public Supplier GetOrCreateSupplier(ArticleImportDTO articleImportDTO)
        {
            var supplier = this.db.Suppliers
                .FirstOrDefault(x => x.Number == articleImportDTO.SupplierNumber.Trim());

            //new supplier is created if not exist in the DB:
            if (supplier == null)
            {
                supplier = new Supplier
                {
                    Number = articleImportDTO.SupplierNumber,
                    Name = articleImportDTO.SupplierName,
                    Email = articleImportDTO.SupplierEmail,
                    PhoneNumber = articleImportDTO.SupplierPhoneNumber,
                    ContactPersonFirstName = articleImportDTO.ContactPersonFirstName,
                    ContactPersonLastName = articleImportDTO.ContactPersonLastName,
                };
            }

            this.db.SaveChanges(); //async-await

            return supplier;
        }

        public void DeleteArticle(int articleId)
        {
            var article = this.GetArticle(articleId);
            if (article != null)
            {
                article.IsDeleted = true;
            };

            article.Suppliers.Clear();
            article.Substances.Clear();
            article.Products.Clear();
            article.Conformities.Clear();

            this.db.SaveChanges(); //async-await
        }


        public void AddConformity(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConformityDTO> ListArticleConformities(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierExportDTO> ListArticleSuppliers(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchArticle(int artileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchByConformity(string conformityType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchBySupplier(string supplierNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(int articleId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplierList(int articleId)
        {
            throw new NotImplementedException();
        }


        private Article GetArticle(int articleId)
        {
            return this.db.Articles.FirstOrDefault(x => x.Id == articleId);
        }

    }
}
