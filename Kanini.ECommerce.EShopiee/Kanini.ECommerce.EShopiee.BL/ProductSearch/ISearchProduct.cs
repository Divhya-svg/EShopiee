// <copyright file="ISearchProduct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.ProductSearch
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.DAL.ProductSearch;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// ISearchProductBl interface.
    /// </summary>
    public interface ISearchProduct
    {
        /// <summary>
        /// SearchProduct Method.
        /// </summary>
        /// <param name="product">product param.</param>
        /// <returns>Returns List.</returns>
        List<Product> SearchProduct(Product product);
    }

    /// <summary>
    /// Class SearchproductBl implements ISearchProduct interface.
    /// </summary>
    public class SearchProductBl : ISearchProduct
    {
        private readonly ISearchProductRepository productDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProductBl"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="searchProduct">SearchProduct Parameter.</param>
        public SearchProductBl(ISearchProductRepository searchProduct)
        {
            this.productDal = searchProduct;
        }

        /// <summary>
        /// SearchProduct Method.
        /// </summary>
        /// <param name="product">product parameter.</param>
        /// <returns>Returns List.</returns>
        public List<Product> SearchProduct(Product product)
        {
            return this.productDal.SearchProducts(product);
        }
    }
}
