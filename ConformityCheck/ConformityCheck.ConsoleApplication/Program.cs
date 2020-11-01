using ConformityCheck.Data;
using ConformityCheck.Services;
using ConformityCheck.Services.Models;
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
            IConformityTypeService conformityTypeService = new ConformityTypeService(db);

            //articleService.DeleteArticle(4);

            //var  a = articleService.ShowSupplierList(5);

            //articleService.DeleteSupplierFromArticle(1, 1);

            //articleService.DeleteSupplierFromArticle(2, 4);

            //articleService.AddConformityToArticle(5, 4, new ArticleConformityImportDTO
            //{
            //    ConformityType = "RoHS1",
            //    IsAssepted = true,
            //    IssueDate = DateTime.UtcNow.AddDays(-10),
            //    ConformationAcceptanceDate = DateTime.UtcNow,
            //    Comments = "No temperatures in the DoC",
            //});

            //var r = conformityTypeService.ListAllConformityTypes();
            //var r = conformityTypeService.Delete(2);

            //TODO:
            //            Twilio e usluga za void neshta. S nego moga da prashtam SMS na klienti za identification naprimer, moje da prashtam sms i po drugi temi.
            //Da si namerq usluga za izprashtane na e-mails kym dostawchici.
            //https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/
            //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient?view=netcore-3.1

            //TODO:
            //Imam 3 varianta za zapis na files:
            //            -Da si zapisvam files s deklaraciite v DB - a kato Binary(Max) colona tam!!!!Binary(Max) se prevejda do byte[] (masiv ot bytes) ot EF!!!
            //            - Da gi zapisvam files vyv file systema v nqkakwi papki. - towa ne stawa za declarationite v moqt DB.
            //            - da gi zapisvam v cloud -t.e.v Azure imam blob.Blob e usluga v clouda, tam moga da pratq file(byte[]) i toj zapisva faila i mi vryshta
            //        edin address, tozi adddress e publichno dostypen i vseki moje da go dostypi v internet, az tozi address moga da go vyrna i da go zapisha v
            //nqkakwa tablica v DB-a si i ot tam da go polzwam.Da go pomislq za moeto proektche.
            //Da si vodq tablica s ID na file, tova id da e Guid i da si pazq addressa kym tozi file.

            //TODO:
            //da si pravq validaciite na dannite ot formite, popylvani ot userite,
            //chrez attributite vyv view modelite, chrez koito vzimam tezi danni, a NE chrez
            //if-ove v samiq service!!!!

            //TODO:
            //            Celta mi kato C# programist e vsichko koeto poluchawam, obrabotvam i predawam kato informaciq, da byde nqkakyv C# class, za da se vyzpolzwam
            //max ot OOP - to!!! Tova shte mi e cel ot tuk natatyk i v profesiqta mi!!!Takawa mi e celta, zashtoto kogato neshto e napraveno pod formata na
            //OOP, neshtata sa mnogo po-lesni za kontrol, mnogo po - lesni za managirane, po-lesni za poddryjka, po-lesni za testwane, kato cqlo po-lesni
            //dori za shvashtane.

            //Automapper moje da se polza ili v controller-ite ili v services, Niki kaza, che go polzwa v services!
            //Taka samite services stawat oshte po - preizpolzwaemi i samite services poluchavat tochniqt model, tochniqt class, kym kojto da prenesat
            //obekta, kojto dyrpat ot DB-a!!! T.e.mappinga se pravi ot DB model prez mapper do towa, koeto mi trqbwa v services kato class za da rabotqt
            //tezi services s tochno nujniqt im class!!!!! Za da polzwam tezi neshta v services, trqbwa da pravq Templateni methodite tam i te da
            //polzwat Templateni classove - taka stawat preizpolzwaemi!!!! 

            //TODO: da si napravq edna ogromna zaqwka i da si vzema vsichki danni ot DB-a v edin ViewModel,
            //a posle v prezentacionnata logika v samoto View chrez Razor
            //az moga da vzema ot veche vyrnatite danni, samo 20 naprimer. Towa e prezentacionna logika i nejnoto mqsto e
            //ne v servica, a vyv View-to. Zashtoto towa View moje da iska 20, ama drugi View moje da iska 100 ot tezi entities,
            //zatowa e typo da pravq otdelni methods v service, za 20 i za 100, a e po-dobre da sa vsichki v edna collection, a
            //posle v samite View-ta da wzimam kakwoto mi trqbwa ot tazi collection.

            //TODO: Da vzema pageing of presscenter na NIKI i taka da si vizualiziram artikulite i productite.

            //TODO: conformity type i supplier number da mi se izbirat ot padashto menu, kakto i suppliername.

            //TODO: vzimam si ot bootstrap css faila  mu + elementi ot free tema, koqto sym si haresala - te sa v html faila i
            //slagam si gi v moq kod i tolkowa.

            //TODO:Ako iskam da imam update-nata info za moite imoti, trqbwa da zakacha sybiracha na oferti ot imot.bg i da 
            //go sloja v moeto prilojenie
            //da se izpylnqwa na opredelen period ot vreme. Imam tools za towa -kato Hangfire, tazi library izpylnqwa daden cod 
            //prez opredeleno vreme. taka da si update-vam SubstanceLists

            //Da si napravq Edit - puskam view syshtoto kato na add, no v nego si zarejdam dannite ot model, vzet ot DB-a
            //vyv formata si slagam stojnostite polucheni ot DB za otdelnite propertyta na modela!!
            //sled tova si pish v edno hidden pole id-to na modela ot DB-a:
            //pod <form> si slagam <input type="hidden" name="id" value="@Model.Id"> i posle si prochitam towa
            //id pri post requesta za edit i si go updatewam v DB-a tochno tozi id s novite danni, koito sa doshli za nego.

            //Da vidq ot Consultation day 31.10.2020 kak se pravi startirane na task prez opredeleno vreme - chrez
            //librarity Hangfire, ima go integrirano c PressCenters na Niki.

            //Kak da si narpavq users s razlichni roli i danni za tqh v EF Core.
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
