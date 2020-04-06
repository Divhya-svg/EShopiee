// <copyright file="TestHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.UnitTest
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// TestHelper Class.
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// GetConfigurarationRoot Method.
        /// </summary>
        /// <param name="outputpath">Param1.</param>
        /// <returns>Returns Secret.</returns>
        public static string GetConfigurationRoot(string outputpath)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(outputpath)
                 .AddJsonFile("appsettings.json", optional: true)
                 .AddEnvironmentVariables()
                 .Build();

            return config["Secret"];
        }

        /// <summary>
        /// GetApplicationConfiguration Method.
        /// </summary>
        /// <param name="outputpath">Param1.</param>
        /// <returns>Returns Config.</returns>
        public string GetApplicationConfiguration(string outputpath)
        {
            string config = GetConfigurationRoot(outputpath);

            return config;
        }
    }
}
