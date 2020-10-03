using ConformityCheck.Data;
using ConformityCheck.Services;
using ConformityCheck.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConformityCheck.Importer
{
    class Program
    {
        static void Main()
        {
            var db = new ConformityCheckContext();

            //Add articles:
            IArticleService articleService = new ArticleService(db);
            var jsonArticles = File.ReadAllText("ArticlesData.json");
            var articles = JsonSerializer.Deserialize<IEnumerable<ArticleImportDTO>>(jsonArticles);

            foreach (var article in articles)
            {
                try
                {
                    articleService.Create(article);
                }
                catch (Exception)
                {

                    //throw; //az ne znam kakvo shte pravq s tazi error i prodyljavam natatyk, kato prosto nqma
                    //da zapisha nishto v DB-a. No moqt Service throwna error i toj se hvana tuk - ot klienta na 
                    //moq Service, no kojto shte polzwa tozi cod, shte reshi kakwo da pravi s error-a. Az samo mu davam 
                    //info za towa kakwo ne e nared, towa mu prashta Service na tozi, kojto go polzwa. Towa da pravi Service
                    //error na polzwashtiqt go, e pravilnoto povedenie na Service-to!!!
                }
            }
            
            //Add conformity types:
            IConformityTypeService conformityTypeService = new ConformityTypeService(db);
            var jsonConformityTypes = File.ReadAllText("ConformityTypesData.json");
            var conformityTypes = JsonSerializer.Deserialize<IEnumerable<ConformityTypeDTO>>(jsonConformityTypes);

            foreach (var conformityType in conformityTypes)
            {
                try
                {
                    conformityTypeService.Create(conformityType);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
