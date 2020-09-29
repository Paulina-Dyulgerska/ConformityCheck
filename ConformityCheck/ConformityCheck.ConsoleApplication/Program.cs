using ConformityCheck.Data;
using ConformityCheck.Models;
using ConformityCheck.Services;
using ConformityCheck.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

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

            //articleService.DeleteArticle(4);

            //var  a = articleService.ShowSupplierList(5);

            //articleService.DeleteSupplierFromArticle(1, 1);

            //articleService.DeleteSupplierFromArticle(2, 4);

            articleService.AddConformityToArticle(3, 3, new ArticleConformityImportDTO
            {
                ConformityType = "RoHS",
                IsAssepted = true,
                IssueDate = DateTime.UtcNow.AddDays(-10),
                ConformationAcceptanceDate = DateTime.UtcNow,
                Comments = "No temperatures in the DoC",
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
