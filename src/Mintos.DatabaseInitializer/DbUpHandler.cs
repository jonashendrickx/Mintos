using DbUp;
using DbUp.Engine;
using Mintos.DatabaseInitializer.Extensions;
using System;
using System.Configuration;
using System.Reflection;

namespace Mintos.DatabaseInitializer
{
    internal static class DbUpHandler
    {
        internal static int Run()
        {
            var connectionString = Program.Configuration.GetSection("ConnectionStrings:LoanBookConnectionString").Value;
            var dataResult = RunStructureAndDataScripts(connectionString);
            DisplayResult(dataResult);
            Console.WriteLine();

            return 0;
        }

        private static DatabaseUpgradeResult RunStructureAndDataScripts(string connectionString)
        {
            Console.WriteLine("Upgrading structure and data scripts...");
            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithTransaction()
                .WithSortedScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            return upgrader.PerformUpgrade();
        }

        private static void DisplayResult(DatabaseUpgradeResult result)
        {
            if (result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
            }
            Console.ResetColor();
        }
    }
}
