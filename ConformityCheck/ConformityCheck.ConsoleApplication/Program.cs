using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services;
using ConformityCheck.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace ConformityCheck.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ConformityCheckContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            db.Database.Migrate();

            IArticleService articleService = new ArticleService(db);

            articleService.Create(new ArticleImportDTO
            {
                Number = "7421273-09",
                Description = "Strip for absteller",
                SupplierNumber = "0085657",
                SupplierName = "Intechna",
                SupplierEmail = "a@abv.bg",
                SupplierPhoneNumber = "02343423",
                ContactPersonFirstName = "Atanas",
                ContactPersonLastName = "Moskov"
            });

            articleService.Create(new ArticleImportDTO
            {
                Number = "4442344-09",
                Description = "Strip for absteller",
                SupplierNumber = "0096362",
                SupplierName = "TEHERasda",
                SupplierEmail = "a@abv.bg",
                SupplierPhoneNumber = "02343423",
                ContactPersonFirstName = "asDe",
                ContactPersonLastName = "ReFFF   "
            });

            articleService.Create(new ArticleImportDTO
            {
                Number = "11111-09",
                Description = "Strip for absteller",
                SupplierNumber = "222222",
                SupplierName = "Assssssss",
                SupplierEmail = "a@abv.bg",
                SupplierPhoneNumber = "02343423",
                ContactPersonFirstName = "asDe",
                ContactPersonLastName = "ReFFF   "
            });

            articleService.Create(new ArticleImportDTO
            {
                Number = "22222-09",
                Description = "Strip for absteller",
                SupplierNumber = "222222",
                SupplierName = "Assssssss",
                SupplierEmail = "a@abv.bg",
                SupplierPhoneNumber = "02343423",
                ContactPersonFirstName = "asDe",
                ContactPersonLastName = "ReFFF   "
            });

            var article = db.Articles.FirstOrDefault(x => x.Id == 3);
            articleService.AddSupplierToArticle(article, new ArticleImportDTO
            {
                Number = article.Number,
                Description = article.Description,
                SupplierNumber = "0099999",
                SupplierName = "PAN",
            });

            //articleService.DeleteArticle(4);

            //var  a = articleService.ShowSupplierList(5);

            //articleService.DeleteSupplierFromArticle(1, 1);

            //articleService.DeleteSupplierFromArticle(2, 4);

            articleService.AddConformityToArticle(2, 4, new ArticleConformityImportDTO
            {
                ConformityType = "RoHS",
                IsAssepted = true,
                IssueDate = DateTime.UtcNow.AddDays(-10),
                ConformationAcceptanceDate = DateTime.UtcNow,
            });


        }
    }

    class Helper
    {
        static void Help()
        {
            var db = new ConformityCheckContext();
            IArticleService articleService = new ArticleService(db);

            Stopwatch sw = Stopwatch.StartNew();
            //articleService.FormatInputString("asdasdadFSfASFASFA"); //2810
            //articleService.PascalCaseConverter("asdasdadFSfASFASFA"); //2230
            Console.WriteLine(sw.ElapsedTicks);

            var a = db.Articles.Where(x => x.Id == 6).FirstOrDefault();
            db.Entry(a).Collection(e => e.ArticleSuppliers).Load();
            var l = a.ArticleSuppliers;

            var bCount = db.Articles.Where(x => x.Id == 6).Select(x => x.ArticleSuppliers).FirstOrDefault();
            var ld = articleService.GetSuppliersNumbersList(db.Articles.Where(x => x.Id == 5).FirstOrDefault().Id);
            var bSupplierNumber = db.Articles
                                    .Where(x => x.Id == 5)
                                    .Select(x => x.ArticleSuppliers.Select(s => s.Supplier.Number))
                                    .FirstOrDefault();

            //
            var g = db.Articles.Where(a => a.Id == 2).Select(a => new
            {
                Nomer = a.Number,
                ArticleSupplier = a.ArticleSuppliers.ToList(),
            }).FirstOrDefault();
            g.ArticleSupplier.Clear();
            //db.SaveChanges(); //tova ne vliqe na DB-a, zashtoto g ne e ot DB-a, a e samo v pametta na programata mi!!!
        }
    }
}
