// <copyright file="ProductsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.UnitTest
{
    using System;
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.BL.Product;
    using Kanini.ECommerce.EShopiee.DAL.Product;
    using Kanini.ECommerce.EShopiee.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// ProductTest Class.
    /// </summary>
    [TestClass]
    public class ProductsTest
    {
        /// <summary>
        /// TestInitialize Method.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
        }

        /// <summary>
        /// TestGetProduct Method.
        /// </summary>
        [TestMethod]
        public void TestGetProduct()
        {
            Mock<IProductRepository> moq = new Mock<IProductRepository>();
            DateTime manufactureDate = Convert.ToDateTime("2019-12-31");
            moq.Setup(x => x.GetProducts())
                .Returns(new List<Product> { new Product { Name = "Redmi Note8 Pro", Rating = 4.2M, ManufactureDate = manufactureDate,
                    CartDescription = "Redmi Note 8 Pro (Gamma Green, 6GB RAM, 128GB Storage with Helio G90T Processor)",
                    ShortDescription = "",
                    Image = " ", MRP=17999.00M, DealPrice = 14999.00M, SavePrice = 3000.00M, NoOfStock = 90, ProductIsActive = true,
            },
                });
            ProductRepo pbl = new ProductRepo(moq.Object);

            int cnt = pbl.GetProduct().Count;
            Assert.AreEqual(1, cnt);
        }

        /// <summary>
        /// InsertProductTest Method.
        /// </summary>
        [TestMethod]
        public void InsertProductTest()
        {
            Mock<IProductRepository> moq = new Mock<IProductRepository>();
            DateTime manufactureDate = Convert.ToDateTime("2019-11-29");
            Product newProduct = new Product
            {
                Name = "SamsungM31",
                Rating = 3.1M,
                ManufactureDate = manufactureDate,
                CartDescription = "6GB RAM|64 GB Storage|Mega 64MP Quad camera",
                ShortDescription = "48MP + 8MP + 5MP triple rear camera | 16MP front facing camera",
                Image = " ",
                MRP = 15500.00M,
                DealPrice = 13999.00M,
                SavePrice = 1501.00M,
                NoOfStock = 100,
                ProductIsActive = true,
            };
            ProductRepo pbl = new ProductRepo(moq.Object);
            int productcnt = pbl.InsertProduct(newProduct);
            //Assert.AreEqual(1, productcnt);
        }

        /// <summary>
        /// DeleteProductTest Method.
        /// </summary>
        [TestMethod]
        public void DeteleProductTest()
        {
            Mock<IProductRepository> pDal = new Mock<IProductRepository>();

            pDal.Setup(x => x.DeleteProducts(new Product() { ProductId = 1 })).Returns(true);

            Product p = new Product();
            p.ProductId = 1;

            Assert.AreEqual(1, pDal.Object);
            bool cnt = pDal.Object.DeleteProducts(p);
        }

        // public void UpdateProduct()
        // {
        //    Mock<IProductDal> moq = new Mock<IProductDal>();
        //    Product testProduct = this.dal.UpdateProducts();
        //    Product productTest = new Product
        //    {
        //        ProductId = 1,
        //        Rating = 2.7M
        //    };
    }
}
