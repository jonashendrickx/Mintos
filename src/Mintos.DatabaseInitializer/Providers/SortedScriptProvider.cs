using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mintos.DatabaseInitializer.Providers
{
    public class SortedScriptProvider : BaseScriptProvider
    {
        public SortedScriptProvider(Assembly assembly) : base(assembly)
        {

        }

        protected override bool IsApplicable(ICollection<string> folders)
        {
            var folderName = folders.ElementAtOrDefault(0);
            if (string.IsNullOrEmpty(folderName)) return false;

            if (folderName.Equals("_1___structure", StringComparison.OrdinalIgnoreCase)) return true;
            if (folderName.Equals("_2___data", StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }
    }
}
