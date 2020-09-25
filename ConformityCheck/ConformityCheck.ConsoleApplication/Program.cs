using ConformityCheck.Data;
using ConformityCheck.Services;
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

            //articleService.Create("7421273-09", "Strip for absteller", "0085657", "Intechna",
            //    "a@abv.bg", "02343423", "Atanas", "Moskov");
            //articleService.Create("7421444-09", "Strip for absteller", "0085657", null, null, null, null, null);
        }
    }
}
