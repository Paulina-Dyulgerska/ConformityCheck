using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public void AddConformity(int articleId)
        {
            throw new NotImplementedException();
        }

        public void AddSupplierToArticle(Article article, string supplierNumber, string supplierName,
                                        string supplierEmail, string supplierPhoneNumber,
                                        string contactPersonFirstName,
                                        string contactPersonLastName)
        {
            if (supplierNumber != null && supplierName != null && supplierEmail != null)
            {
                var supplier = this.GetOrCreateSupplier(supplierNumber, supplierName,
                                                     supplierEmail, supplierPhoneNumber, contactPersonFirstName,
                                                     contactPersonLastName);

                article.Suppliers.Add(new ArticleSupplier { Supplier = supplier });
            }

            this.db.SaveChanges(); //async-await
        }

        public void Create(string number, string description, string supplierNumber, string supplierName,
            string supplierEmail, string supplierPhoneNumber, string contactPersonFirstName,
            string contactPersonLastName)
        {
            //TODO - check the number and description in the importModelsDTOs wirh RegullarExpretion!!!

            //check the article number and description
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException($"{nameof(number)} cannot be null or empty");
            }

            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException($"{nameof(description)} cannot be null or empty");
            }

            if (this.db.Articles.FirstOrDefault(x => x.Number == number) != null) //TODO - async-await
            {
                throw new ArgumentException($"{nameof(number)} there is already an artilce with this number.");
            }

            var article = new Article
            {
                Number = number.Trim().ToUpper(),
                Description = description.Trim().ToUpper(),
            };

            this.AddSupplierToArticle(article, supplierNumber, supplierName, supplierEmail, supplierPhoneNumber,
                                         contactPersonFirstName, contactPersonLastName);

            db.Articles.Add(article);

            this.db.SaveChanges(); //async-await
        }

        public void DeleteArticle(int articleId)
        {
            throw new NotImplementedException();
        }

        public Supplier GetOrCreateSupplier(string supplierNumber, string supplierName,
                                        string supplierEmail, string supplierPhoneNumber,
                                        string contactPersonFirstName,
                                        string contactPersonLastName)
        {
            //TODO - to validate supplierNumber supplierName supplierEmail in input DTO supplier model
            //using RegularExpretion!

            var supplier = this.db.Suppliers.FirstOrDefault(x => x.Number == supplierNumber.Trim());

            //new supplier is created if not exist in the DB:
            if (supplier == null)
            {
                supplier = new Supplier
                {
                    Number = supplierNumber,
                    Name = supplierName,
                    Email = supplierEmail,
                    PhoneNumber = supplierPhoneNumber,
                    ContactPersonFirstName = contactPersonFirstName,
                    ContactPersonLastName = contactPersonLastName,
                };
            }

            this.db.SaveChanges(); //async-await

            return supplier;
        }

        public IEnumerable<ConformityViewModel> ListArticleConformities(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierViewModel> ListArticleSuppliers(int articleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> SearchArticle(int artileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> SearchByConformity(string conformityType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> SearchByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArticleViewModel> SearchBySupplier(string supplierNumber)
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
    }
}
