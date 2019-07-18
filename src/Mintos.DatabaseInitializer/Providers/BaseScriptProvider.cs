using DbUp.Engine;
using DbUp.Engine.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mintos.DatabaseInitializer.Providers
{
    public abstract class BaseScriptProvider : IScriptProvider
    {
        private readonly Assembly _assembly;

        protected BaseScriptProvider(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IEnumerable<SqlScript> GetScripts(IConnectionManager connectionManager)
        {
            var sqlScripts = _assembly.GetManifestResourceNames()
                .Where(IsApplicable)
                .ToArray()
                .Select(x => SqlScript.FromStream(x, _assembly.GetManifestResourceStream(x), Encoding.UTF8))
                .OrderBy(x =>
                {
                    var folders = x.Name.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    if (folders.Length < 2)
                    {
                        return folders[folders.Length - 2];
                    }
                    return x.Name;
                }).ToList();
            return sqlScripts;
        }

        public bool IsApplicable(string scriptName)
        {
            if (!scriptName.EndsWith(".sql", StringComparison.OrdinalIgnoreCase)) return false;
            var folders = scriptName.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (!folders.Any()) return false;
            var indexOfScriptFolder = Array.IndexOf(folders, "Dump");
            if (indexOfScriptFolder < 0) return false;
            return IsApplicable(folders.Skip(indexOfScriptFolder + 1).ToList());
        }

        protected abstract bool IsApplicable(ICollection<string> folder);
    }
}
