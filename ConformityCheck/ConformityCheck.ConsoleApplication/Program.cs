﻿using ConformityCheck.Data;
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

            //var article = db.Articles.FirstOrDefault(x => x.Id == 3);
            //articleService.AddSupplierToArticle(article, new ArticleImportDTO
            //{
            //    Number = article.Number,
            //    Description = article.Description,
            //    SupplierNumber = "0099999",
            //    SupplierName = "PAN",
            //});

            //articleService.DeleteArticle(4);

            //var  a = articleService.ShowSupplierList(5);

            //articleService.DeleteSupplierFromArticle(1, 1);

            articleService.DeleteSupplierFromArticle(31, 1);
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
            var ld = articleService.GetSuppliersNuumbersList(db.Articles.Where(x => x.Id == 5).FirstOrDefault().Id);
            var bSupplierNumber = db.Articles
    .Where(x => x.Id == 5)
    .Select(x => x.ArticleSuppliers.Select(s => s.Supplier.Number))
    .FirstOrDefault();
        }
    }
}
