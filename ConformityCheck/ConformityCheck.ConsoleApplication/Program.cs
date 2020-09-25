using ConformityCheck.Data;
using ConformityCheck.Services;
using ConformityCheck.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

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

            articleService.Create(new ArticleImportDTO
            {
                Number = "34234234234234-09",
                Description = "Strip for absteller",
                SupplierNumber = "0083657",
                SupplierName = "Reco",
                //SupplierEmail = "a@abv.bg",
                //SupplierPhoneNumber = "02343423",
                //ContactPersonFirstName = "Atanas",
                //ContactPersonLastName = "Moskov"
            });
        }
    }
}
