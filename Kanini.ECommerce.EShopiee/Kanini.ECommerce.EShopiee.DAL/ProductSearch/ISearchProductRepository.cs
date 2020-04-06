// <copyright file="ISearchProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.ProductSearch
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface ISearchProductRepository.
    /// </summary>
    public interface ISearchProductRepository
    {
        /// <summary>
        /// SearchProducts Method.
        /// </summary>
        /// <param name="product">product.</param>
        /// <returns>Returns list of product.</returns>
        List<Product> SearchProducts(Product product);
    }

    /// <summary>
    /// Class SearchProductRepository implements ISearchProductRepository.
    /// </summary>
    public class SearchProductRepository : ISearchProductRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProductRepository"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="repo">repo parameter.</param>
        public SearchProductRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// SearchProduct Method.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Returns Searched Product.</returns>
        public List<Product> SearchProducts(Product product)
        {
            var parameters = new List<SqlParameter>();

            List<Product> productList = new List<Product>();
            Product productsearch = null;
            parameters.Add(this.baseRepo.CreateParameter("@Name", 30, product.Name, SqlDbType.VarChar));
            var search = this.baseRepo.GetData("SearchProduct", CommandType.StoredProcedure, parameters.ToArray());
            while (search.Read())
            {
                productsearch = new Product();
                productsearch.Name = search[1].ToString();
                productsearch.Rating = Convert.ToDecimal(search[2].ToString());
                productsearch.ManufactureDate = Convert.ToDateTime(search[3].ToString());
                productsearch.CartDescription = search[4].ToString();
                productsearch.ShortDescription = search[5].ToString();
                productsearch.Image = search[6].ToString();
                productsearch.MRP = Convert.ToDecimal(search[7].ToString());
                productsearch.DealPrice = Convert.ToDecimal(search[8].ToString());
                productsearch.SavePrice = Convert.ToDecimal(search[9].ToString());
                product.NoOfStock = Convert.ToInt32(search[10].ToString());
                productList.Add(product);
            }

            return productList;
        }
    }
}
