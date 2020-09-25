using ConformityCheck.Data;
using ConformityCheck.Services;
using ConformityCheck.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConformityCheck.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ConformityCheckContext();
            db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            //db.Database.Migrate();

            IArticleService articleService = new ArticleService(db);

            //articleService.Create(new ArticleImportDTO
            //{
            //    Number = "7421273-09",
            //    Description = "Strip for absteller",
            //    SupplierNumber = "0085657",
            //    SupplierName = "Intechna",
            //    SupplierEmail = "a@abv.bg",
            //    SupplierPhoneNumber = "02343423",
            //    ContactPersonFirstName = "Atanas",
            //    ContactPersonLastName = "Moskov"
            //});

            //articleService.Create(new ArticleImportDTO
            //{
            //    Number = "4442344-09",
            //    Description = "Strip for absteller",
            //    SupplierNumber = "0096362",
            //    SupplierName = "TEHERasda",
            //    SupplierEmail = "a@abv.bg",
            //    SupplierPhoneNumber = "02343423",
            //    ContactPersonFirstName = "asDe",
            //    ContactPersonLastName = "ReFFF   "
            //});

            //articleService.Create(new ArticleImportDTO
            //{
            //    Number = "11111-09",
            //    Description = "Strip for absteller",
            //    SupplierNumber = "222222",
            //    SupplierName = "Assssssss",
            //    SupplierEmail = "a@abv.bg",
            //    SupplierPhoneNumber = "02343423",
            //    ContactPersonFirstName = "asDe",
            //    ContactPersonLastName = "ReFFF   "
            //});

            //articleService.Create(new ArticleImportDTO
            //{
            //    Number = "22222-09",
            //    Description = "Strip for absteller",
            //    SupplierNumber = "222222",
            //    SupplierName = "Assssssss",
            //    SupplierEmail = "a@abv.bg",
            //    SupplierPhoneNumber = "02343423",
            //    ContactPersonFirstName = "asDe",
            //    ContactPersonLastName = "ReFFF   "
            //});

            //articleService.DeleteArticle(13);

            //articleService.AddSupplierToArticle(db.Articles.FirstOrDefault(x => x.Id == 2), new SupplierImportDTO
            //{
            //    Number = "0096862",
            //    Name = "Urban",
            //});

            var a = db.Articles.FirstOrDefault(x => x.Id == 4).ArticleSuppliers.Select(x => x.SupplierId).ToList();
        }
    }
}
