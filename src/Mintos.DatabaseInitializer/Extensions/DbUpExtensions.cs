using DbUp.Builder;
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
    }
}
