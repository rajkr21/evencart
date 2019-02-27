﻿using DotEntity;
using DotEntity.SqlServer;
using RoastedMarketplace.Data.Database;
using RoastedMarketplace.Services.Installation;

namespace RoastedMarketplace.Services.Tests
{
    public class TestDbInit
    {
        public static void SqlServer(string connectionString)
        {
            //seed data
            var installationService = new InstallationService(new TestDatabaseSettings(connectionString, "sqlserver"));
            installationService.Install();
            installationService.FillRequiredSeedData("admin@store.com", "@#$%^&*", "localhost");
        }

        private class TestDatabaseSettings : IDatabaseSettings
        {
            public string ConnectionString { get; }
            public string ProviderName { get; }

            public TestDatabaseSettings(string connectionString, string providerName)
            {
                ConnectionString = connectionString;
                ProviderName = providerName;
            }
            public void LoadSettings()
            {
                //do nothing
            }

            public void WriteSettings(string connectionString, string providerName)
            {
                //do nothing
            }

            public bool HasSettings()
            {
                return true;
            }
        }
    }
}