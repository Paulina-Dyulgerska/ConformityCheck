using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                var supplierImportDTO = new SupplierImportDTO
                {
                    Number = articleImportDTO.SupplierNumber.Trim(),
                    Name = PascalCaseConverter(articleImportDTO.SupplierName.Trim()),
                    //Email = articleImportDTO.SupplierEmail == null ? null : articleImportDTO.SupplierEmail.Trim(),
                    Email = articleImportDTO.SupplierEmail?.Trim(),
                    PhoneNumber = articleImportDTO.SupplierPhoneNumber?.Trim(),
                    ContactPersonFirstName =
                            PascalCaseConverter(articleImportDTO.ContactPersonFirstName?.Trim()),
                    ContactPersonLastName = 
                            PascalCaseConverter(articleImportDTO.ContactPersonLastName?.Trim()),
                };

                this.AddSupplierToArticle(article, supplierImportDTO);
            }
        }

        public void AddSupplierToArticle(Article article, SupplierImportDTO supplierImportDTO)
        {
            var supplier = this.GetOrCreateSupplier(supplierImportDTO);

            article.Suppliers.Add(new ArticleSupplier { Supplier = supplier });

            this.db.SaveChanges(); //async-await
        }

        public Supplier GetOrCreateSupplier(SupplierImportDTO supplierImportDTO)
        {
            var supplier = this.db.Suppliers
                .FirstOrDefault(x => x.Number == supplierImportDTO.Number);

            //new supplier is created if not exist in the DB:
            if (supplier == null)
            {
                supplier = new Supplier
                {
                    Number = supplierImportDTO.Number,
                    Name = supplierImportDTO.Name,
                    Email = supplierImportDTO.Email,
                    PhoneNumber = supplierImportDTO.PhoneNumber,
                    ContactPersonFirstName = supplierImportDTO.ContactPersonFirstName,
                    ContactPersonLastName = supplierImportDTO.ContactPersonLastName,
                };

                this.db.Suppliers.Add(supplier);

                this.db.SaveChanges(); //async-await
            }

            return supplier;
        }

        public bool DeleteArticle(int articleId)
        {
            var article = this.GetArticle(articleId);

            if (article == null)
            {
                return false;
            };

            article.IsDeleted = true;
            article.Suppliers.Clear();
            article.Substances.Clear();
            article.Products.Clear();
            article.Conformities.Clear();

            this.db.SaveChanges(); //async-await

            return article.IsDeleted;
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

        private string PascalCaseConverter(string stringToFix)
        {
            var st = new StringBuilder();
            st.Append(char.ToUpper(stringToFix[0]));
            for (int i = 1; i < stringToFix.Length; i++)
            {
                if (stringToFix[i] == ' ')
                {
                    continue;
                }

                st.Append(char.ToLower(stringToFix[i]));
            }

            return st.ToString();
        }
    }
}
