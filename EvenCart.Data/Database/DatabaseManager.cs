﻿using System.Data.SqlClient;
using System.Linq;
using DotEntity;
using DotEntity.Providers;
using DotEntity.SqlServer;
using EvenCart.Core.Infrastructure;
using EvenCart.Core.Plugins;
using EvenCart.Data.Versions;

namespace EvenCart.Data.Database
{
    public class DatabaseManager
    {
        private const string DatabaseContextKey = "EvenCart";
        public static void InitDatabase(IDatabaseSettings dbSettings)
        {
            if (dbSettings.HasSettings())
                DotEntityDb.Initialize(dbSettings.ConnectionString, GetProvider(dbSettings.ProviderName));
        }

        public static bool IsDatabaseInstalled()
        {
            return IsDatabaseInstalled(DependencyResolver.Resolve<IDatabaseSettings>());
        }

        public static bool IsDatabaseInstalled(IDatabaseSettings dbSettings)
        {
            return dbSettings.HasSettings() && !string.IsNullOrEmpty(dbSettings.ConnectionString) && !string.IsNullOrEmpty(dbSettings.ProviderName);
        }

        private static IDatabaseProvider GetProvider(string providerAbstractName)
        {
            switch (providerAbstractName.ToLower())
            {

                case "sqlserver":
                    return new SqlServerDatabaseProvider();

            }
            return null;
        }

        private static bool _versionsAdded = false;
        public static void AppendVersions()
        {
            if (_versionsAdded)
                return;
            DotEntityDb.EnqueueVersions(DatabaseContextKey, new Version100(), new Version101());

            var pluginLoader = DependencyResolver.Resolve<IPluginLoader>();
            var pluginInfos = pluginLoader.GetAvailablePlugins();
            foreach (var pluginInfo in pluginInfos)
            {
                var versions = pluginInfo.LoadPluginInstance<IPlugin>().GetDatabaseVersions().ToArray();
                if (versions.Any())
                    DotEntityDb.EnqueueVersions(pluginInfo.SystemName, versions);
            }
            _versionsAdded = true;
        }

        public static void UpgradeDatabase()
        {
            UpgradeDatabase(DatabaseContextKey);
            //upgrade the installed plugin's database as well.
            var pluginLoader = DependencyResolver.Resolve<IPluginLoader>();
            var pluginInfos = pluginLoader.GetAvailablePlugins();
            foreach (var pluginInfo in pluginInfos)
            {
                if (pluginInfo.Installed)
                {
                    UpgradeDatabase(pluginInfo.SystemName);
                }
            }
        }

        public static void UpgradeDatabase(string callingContextName)
        {
            AppendVersions();
            DotEntityDb.UpdateDatabaseToLatestVersion(callingContextName);
        }

        public static void CleanupDatabase(string callingContextName)
        {
            AppendVersions();
            DotEntityDb.UpdateDatabaseToVersion(callingContextName, null);
        }

        public static void ClearVersions()
        {
            _versionsAdded = false;
        }

        public static bool IsValidConnection(string providerName, string connectionString)
        {
            DotEntityDb.Initialize(connectionString, GetProvider(providerName));
            try
            {
                DotEntityDb.Provider.Connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DotEntityDb.Provider.Connection.Close();
            }
        }
        /// <summary>
        /// Creates connection string from the provider values
        /// </summary>
        public static string CreateSqlServerConnectionString(string server, string databaseName, string userName, string password, bool integratedSecurity, int timeOut)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder {
                    IntegratedSecurity = integratedSecurity,
                    DataSource = server,
                    InitialCatalog = databaseName
                };
                if (!integratedSecurity)
                {
                    builder.UserID = userName;
                    builder.Password = password;
                }
                builder.PersistSecurityInfo = false;
                if (timeOut > 0)
                {
                    builder.ConnectTimeout = timeOut;
                }
                return builder.ConnectionString;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}