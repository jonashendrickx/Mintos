using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace Mintos.DatabaseInitializer
{
    internal class Program
    {
        public static IConfiguration Configuration; // TODO DI

        private static int Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            if (args != null && args.Length == 0)
            {
                return DbUpHandler.Run();
            }

            DbUpHandler.Run();

            return 0;
        }
    }
}
