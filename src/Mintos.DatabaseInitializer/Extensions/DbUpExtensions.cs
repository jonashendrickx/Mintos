using DbUp.Builder;
using DbUp.SqlServer;
using Mintos.DatabaseInitializer.Models;
using Mintos.DatabaseInitializer.Providers;
using System.Reflection;

namespace Mintos.DatabaseInitializer.Extensions
{
    internal static class DbUpExtensions
    {
        public static UpgradeEngineBuilder WithSortedScriptsEmbeddedInAssembly(this UpgradeEngineBuilder builder, Assembly assembly)
        {
            var provider = new SortedScriptProvider(assembly);
            return builder.WithScripts(provider);
        }

        public static UpgradeEngineBuilder WithReadOnlyJournal(this UpgradeEngineBuilder builder, string schema, string table)
        {
            builder.Configure(c => c.Journal = new ReadOnlyJournal(new SqlTableJournal(() => c.ConnectionManager, () => c.Log, schema, table)));
            return builder;
        }
    }
}
