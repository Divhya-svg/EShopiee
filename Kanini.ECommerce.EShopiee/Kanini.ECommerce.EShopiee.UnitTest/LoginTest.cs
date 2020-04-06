// <copyright file="LoginTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.UnitTest
{
    using System.IO;
    using Kanini.ECommerce.EShopiee.BL.UserLogin;
    using Kanini.ECommerce.EShopiee.DAL.UserLogin;
    using Kanini.ECommerce.EShopiee.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Class LoginTest.
    /// </summary>
    [TestClass]
    public class LoginTest
    {
        /// <summary>
        /// TestInitialize Method.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// InsertLoginTest Method.
        /// </summary>
        [TestMethod]
        public void InsertLoginTest()
        {
            Mock<IUserService> moq = new Mock<IUserService>();
            Mock<IConfiguration> moqConfig = new Mock<IConfiguration>();
            TestHelper oHelper = new TestHelper();
            FileInfo info = new FileInfo("appsettings.json");
            string path = info.DirectoryName;
            string emailId = "divhyadarsh429@gmail.com";
            string mobileNumber = "9384603624";
            string password = "dbinfosys29";
            string secret = oHelper.GetApplicationConfiguration(path);
            string token = string.Empty;
            UserService us = new UserService();
            token = us.GetAuthToken(1, secret);
            Assert.IsNotNull(token);
        }
    }
}
