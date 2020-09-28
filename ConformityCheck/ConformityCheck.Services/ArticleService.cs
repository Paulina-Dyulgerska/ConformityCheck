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
            var articleEntity = this.db.Articles.FirstOrDefault(x => x.Number == articleImportDTO.Number.Trim().ToUpper());

            if (articleEntity != null) //TODO - async-await
            {
                throw new ArgumentException($"There is already an article with this number.");
            }

            var article = new Article
            {
                Number = articleImportDTO.Number.Trim().ToUpper(),
                Description = PascalCaseConverter(articleImportDTO.Description),
            };

            db.Articles.Add(article);

            this.db.SaveChanges(); //TODO - async-await

            if (articleImportDTO.SupplierName != null && articleImportDTO.SupplierNumber != null)
            {
                this.AddSupplierToArticle(article, articleImportDTO);
            }
        }

        public void AddSupplierToArticle(Article article, ArticleImportDTO articleImportDTO)
        {
            var supplierEntity = this.GetOrCreateSupplier(articleImportDTO);

            var articleSuppliers = db.Articles.Where(a => a.Id == article.Id).Select(a => a.ArticleSuppliers).FirstOrDefault(); //async-await

            if (articleSuppliers.Any(x => x.SupplierId == supplierEntity.Id))
            {
                throw new ArgumentException("The supplier is already asigned to this article");
            }

            article.ArticleSuppliers.Add(new ArticleSupplier { Supplier = supplierEntity });

            this.db.SaveChanges(); //TODO async-await
        }

        public Supplier GetOrCreateSupplier(ArticleImportDTO articleImportDTO)
        {
            var supplierEntity = this.db.Suppliers.FirstOrDefault(x => x.Number == articleImportDTO.SupplierNumber.Trim().ToUpper());

            //new supplier is created if not exist in the DB:
            if (supplierEntity == null)
            {
                supplierEntity = new Supplier
                {
                    Number = articleImportDTO.SupplierNumber.Trim().ToUpper(),
                    Name = PascalCaseConverter(articleImportDTO.SupplierName),
                    Email = articleImportDTO.SupplierEmail?.Trim(),
                    PhoneNumber = articleImportDTO.SupplierPhoneNumber?.Trim(),
                    ContactPersonFirstName = articleImportDTO.ContactPersonFirstName == null ? null :
                            PascalCaseConverter(articleImportDTO.ContactPersonFirstName),
                    ContactPersonLastName = articleImportDTO.ContactPersonLastName == null ? null :
                            PascalCaseConverter(articleImportDTO.ContactPersonLastName),
                };

                this.db.Suppliers.Add(supplierEntity);

                this.db.SaveChanges(); //async-await
            }

            return supplierEntity;
        }

        public void DeleteSupplierFromArticle(int articleId, int supplierId)
        {
            var articleEntity = this.GetArticle(articleId);
            var supplierEntity = this.GetSupplier(supplierId);

            if (articleEntity == null)
            {
                throw new ArgumentException("No such article");
            }

            if (supplierEntity == null)
            {
                throw new ArgumentException("No such supplier");
            }

            var articleSuppliers = this.GetSuppliersIdsList(articleId);

            if (!articleSuppliers.Contains(supplierId))
            {
                throw new ArgumentException("The article does not have such supplier.");
            }

            db.ArticleSuppliers.Remove(new ArticleSupplier
            {
                ArticleId = articleId,
                SupplierId = supplierId,
            });

            db.SaveChanges();
        }

        public int DeleteArticle(int articleId)
        {
            var articleEntity = this.GetArticle(articleId);

            if (articleEntity == null)
            {
                throw new ArgumentException("No such article id");
            };

            this.db.Articles.Remove(articleEntity);

            //TODO - da razbera kak da naprawq triene, no da mi istanat zapisite. Sigurno trqbwa da
            //vkaram kolona IsDeleted vyv vsqka tablica ot dolnite 4...
            //article.IsDeleted = true;
            //foreach (var item in article.Suppliers)
            //{
            //}
            //article.Suppliers.Clear();
            //article.Substances.Clear();
            //article.Products.Clear();
            //article.Conformities.Clear();

            return this.db.SaveChanges(); //async-await
        }

        public void AddConformityToArticle(int articleId, int supplierId, ArticleConformityImportDTO articleConformityImportDTO)
        {
            var supplierEntity = this.GetSupplier(supplierId);
            var articleEntity = this.GetArticle(articleId);

            if (articleEntity == null)
            {
                throw new ArgumentException("No such article");
            }

            if (supplierEntity == null)
            {
                throw new ArgumentException("No such supplier");
            }

            var articleSuppliers = this.GetSuppliersIdsList(articleId);

            if (!articleSuppliers.Contains(supplierId))
            {
                throw new ArgumentException("The article does not have such supplier.");
            }

            var conformityType = this.db.ConformityTypes
                .FirstOrDefault(ct => ct.Description == articleConformityImportDTO.ConformityType.Trim().ToUpper());

            if (conformityType == null)
            {
                throw new ArgumentException("No such conformity type.");
            }

            var conformity = new Conformity
            {
                ConformityTypeId = conformityType.Id,
                IssueDate = articleConformityImportDTO.IssueDate,
                ConformationAcceptanceDate = articleConformityImportDTO.ConformationAcceptanceDate,
                IsAccepted = articleConformityImportDTO.IsAssepted,
                IsValid = true,
            };

            this.db.Conformities.Add(conformity);

            articleEntity.ArticleConformities.Add(new ArticleConformity
            {
                Article = articleEntity,
                Conformity = conformity,
            });

            this.db.SaveChanges(); //TODO async-await
        }
        public void DeleteConformity(int articleId)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD
=======
        public void DeleteConformity(int articleId)
        {
            throw new NotImplementedException();
        }
>>>>>>> 992932ed973c22a65cb4ab45f36ebb63e9c4a67b
        public void UpdateArticle(ArticleImportDTO articleImportDTO)
        {
            var articleEntity = this.db.Articles.FirstOrDefault(x => x.Number == articleImportDTO.Number.Trim().ToUpper());

            if (articleEntity == null) //TODO - async-await
            {
                throw new ArgumentException($"There is no article with this number.");
            }

            articleEntity.Number = articleImportDTO.Number.Trim().ToUpper();

            articleEntity.Description = PascalCaseConverter(articleImportDTO.Description);

            //TODO - all other article characteristics have to be able to be updated from this method!!! S buttons +add +add na vseki 
            //supplier, product, substance i t.n. A otstrani shte ima - za delete na vseki zapis!!!
            //Suppliers - AddSupplierToArticle, DeleteSupplierFromArticle
            //Conformities -AddConformity, DeleteConformity
            //Products - ListArticleProducts only, no delete
            //Sustances - Add/DeleteSubstance!!!! To have it in the interface

            this.db.SaveChanges(); //TODO - async-await
        }

        public IEnumerable<ConformityImportDTO> ListArticleConformities(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierExportDTO> ListArticleSuppliers(int articleId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ProductDTO> ListArticleProducts(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchByArticleNumber(int artileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchByConformityType(string conformityType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchByConfirmedStatus(string status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleExportDTO> SearchBySupplierNumber(string supplierNumber)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int articleId)
        {
            return this.db.Articles.FirstOrDefault(x => x.Id == articleId);
        }

        public Supplier GetSupplier(int supplierId)
        {
            return this.db.Suppliers.FirstOrDefault(x => x.Id == supplierId);
        }

        public IEnumerable<string> GetSuppliersNumbersList(int articleId)
        {
            return db.Articles.Where(x => x.Id == articleId).Select(x => x.ArticleSuppliers.Select(s => s.Supplier.Number)).FirstOrDefault();
        }

        public IEnumerable<int> GetSuppliersIdsList(int articleId)
        {
            return db.Articles.Where(x => x.Id == articleId).Select(x => x.ArticleSuppliers.Select(s => s.Supplier.Id)).FirstOrDefault();
        }

        public int GetSuppliersCount(int articleId)
        {
            return db.Articles.Where(x => x.Id == articleId).Select(x => x.ArticleSuppliers).FirstOrDefault().Count;
        }

        private string PascalCaseConverter(string stringToFix)
        {
            var st = new StringBuilder();
            st.Append(char.ToUpper(stringToFix[0]));
            for (int i = 1; i < stringToFix.Length; i++)
            {
                st.Append(char.ToLower(stringToFix[i]));
            }

            return st.ToString().Trim();
        }

        //private string FormatInputString(string stringToFormat) //it is 25% slower than the PascalCaseConverter
        //{
        //    return $"{stringToFormat.ToUpper()[0]}{stringToFormat.Substring(1).ToLower()}".Trim(); 
        //}
    }
}
