using DbUp.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Mintos.DatabaseInitializer.Models
{
    public class ReadOnlyJournal : IJournal
    {

        private readonly IJournal _innerJournal;

        public ReadOnlyJournal(IJournal innerJournal)
        {
            _innerJournal = innerJournal;
        }

        public void EnsureTableExistsAndIsLatestVersion(Func<IDbCommand> dbCommandFactory)
        {
            _innerJournal.EnsureTableExistsAndIsLatestVersion(dbCommandFactory);
        }

        public string[] GetExecutedScripts()
        {
            return _innerJournal.GetExecutedScripts().ToArray();
        }

        public void StoreExecutedScript(SqlScript script, Func<IDbCommand> dbCommandFactory)
        {
            // don't store anything
        }
    }
}
