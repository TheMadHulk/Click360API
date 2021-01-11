using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using NPoco;
using Serilog;
using Click360.Core.Database.Interfaces;

namespace Click360.Core.Database
{
    /// <summary>
    /// Click360 Database Access
    /// </summary>
    public class Click360Database : NPoco.Database, IClick360Database
    {
        private static readonly ILogger Logger = Log.ForContext<Click360Database>();

        public Click360Database(DbConnection connection)
            : base(connection)
        { }

        public Click360Database(DbConnection connection, DatabaseType dbType)
            : base(connection, dbType)
        { }

        public Click360Database(DbConnection connection, DatabaseType dbType, IsolationLevel? isolationLevel)
            : base(connection, dbType, isolationLevel)
        { }

        public Click360Database(DbConnection connection, DatabaseType dbType, IsolationLevel? isolationLevel, bool enableAutoSelect)
            : base(connection, dbType, isolationLevel, enableAutoSelect)
        { }

        public Click360Database(string connectionString, DatabaseType databaseType, DbProviderFactory provider)
            : base(connectionString, databaseType, provider)
        { }

        public Click360Database(string connectionString, DatabaseType databaseType, DbProviderFactory provider, IsolationLevel? isolationLevel = null, bool enableAutoSelect = true)
            : base(connectionString, databaseType, provider, isolationLevel, enableAutoSelect)
        { }

        protected override void OnExecutingCommand(DbCommand cmd)
        {
            var dumpSQL = Convert.ToBoolean(ConfigurationManager.AppSettings["DumpSQL"]);
            if (dumpSQL)
            {
                Logger.Debug(FormatCommand(cmd));
            }

            base.OnExecutingCommand(cmd);
        }

        protected override void OnException(Exception e)
        {
            Logger.Error(e, $"NPOCO SQL Exception. Last Executing SQL:{Environment.NewLine} {Environment.NewLine} {LastSQL}");
            if (e.InnerException != null) Logger.Error(e.InnerException, e.InnerException.Message);
            e.Data["LastSQL"] = LastSQL;
            base.OnException(e);
        }
    }
}
