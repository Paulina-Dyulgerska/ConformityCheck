using ConformityCheck.Data;
using System;

namespace ConformityCheck.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ConformityCheckContext();

            db.Database.EnsureCreated();
        }
    }
}
