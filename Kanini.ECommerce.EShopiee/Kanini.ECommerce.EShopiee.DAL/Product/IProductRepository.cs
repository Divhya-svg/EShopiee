// <copyright file="IProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.Product
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// IProductRepository interface.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// InsertProducts Method.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Returns integer.</returns>
        int InsertProducts(Product product);

        /// <summary>
        /// GetProducts Method.
        /// </summary>
        /// <returns>Returns List of products.</returns>
        List<Product> GetProducts();

        /// <summary>
        /// UpdateProducts.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Returns boolean status.</returns>
        bool UpdateProducts(Product product);

        /// <summary>
        /// DeleteProducts.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Returns Boolean status.</returns>
        bool DeleteProducts(Product product);
    }

    /// <summary>
    /// Class ProductRepository implements ProductRepository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="repo">repo parameter.</param>
        public ProductRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// InsertProducts Method.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Returns integer.</returns>
        public int InsertProducts(Product product)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@Name", product.Name, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@Rating", product.Rating, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@ManufactureDate", product.ManufactureDate, SqlDbType.Date));
            parameters.Add(this.baseRepo.CreateParameter("@CartDescription", product.CartDescription, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@ShortDescription", product.ShortDescription, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@Image", product.Image, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@MRP", product.MRP, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@DealPrice", product.DealPrice, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@SavePrice", product.SavePrice, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@NoOfStock", product.NoOfStock, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@ProductIsActive", product.ProductIsActive, SqlDbType.Bit));
            this.baseRepo.Insert("AddProduct", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }

        /// <summary>
        /// Delete Product Method.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Return boolean status.</returns>
        public bool DeleteProducts(Product product)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@ProductId", product.ProductId, SqlDbType.Int));
            this.baseRepo.Delete("DeleteProduct", CommandType.StoredProcedure, parameters.ToArray(), out bool status);
            return status;
        }

        /// <summary>
        /// UpdateProducts Method.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Retuns boolean status.</returns>
        public bool UpdateProducts(Product product)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@ProductId", product.ProductId, SqlDbType.Int));
            product = new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Rating = product.Rating,
                ManufactureDate = product.ManufactureDate,
                CartDescription = product.CartDescription,
                ShortDescription = product.ShortDescription,
                Image = product.Image,
                MRP = product.MRP,
                DealPrice = product.DealPrice,
                SavePrice = product.SavePrice,
                NoOfStock = product.NoOfStock,
                ProductIsActive = product.ProductIsActive,
            };

            parameters.Add(this.baseRepo.CreateParameter("@Name", 30, product.Name, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@Rating", product.Rating, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@ManufactureDate", product.ManufactureDate, SqlDbType.Date));
            parameters.Add(this.baseRepo.CreateParameter("@CartDescription", 100, product.CartDescription, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@ShortDescription", product.ShortDescription, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@Image", 100, product.Image, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@MRP", product.MRP, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@DealPrice", product.DealPrice, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@SavePrice", product.SavePrice, SqlDbType.Decimal));
            parameters.Add(this.baseRepo.CreateParameter("@NoOfStock", product.NoOfStock, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@ProductIsActive", product.ProductIsActive, SqlDbType.Bit));
            this.baseRepo.Update("UpdateProduct", CommandType.StoredProcedure, parameters.ToArray(), out bool status);
            return status;
        }

        /// <summary>
        /// GetProducts Method.
        /// </summary>
        /// <returns>Returns list of Products.</returns>
        public List<Product> GetProducts()
        {
            var parameters = new List<SqlParameter>();
            List<Product> productslist = new List<Product>();
            Product product = null;
            var productReader = this.baseRepo.GetData("ViewProducts", CommandType.StoredProcedure, null);
            while (productReader.Read())
            {
                    product = new Product();
                    product.Name = productReader[1].ToString();
                    product.Rating = Convert.ToDecimal(productReader[2].ToString());
                    product.ManufactureDate = Convert.ToDateTime(productReader[3].ToString());
                    product.CartDescription = productReader[4].ToString();
                    product.ShortDescription = productReader[5].ToString();
                    product.Image = productReader[6].ToString();
                    product.MRP = Convert.ToDecimal(productReader[7].ToString());
                    product.DealPrice = Convert.ToDecimal(productReader[8].ToString());
                    product.SavePrice = Convert.ToDecimal(productReader[9].ToString());
                    product.NoOfStock = Convert.ToInt32(productReader[10].ToString());
                    product.ProductIsActive = Convert.ToBoolean(productReader[11].ToString());
                    productslist.Add(product);
            }

            return productslist;
        }
    }
}
