// <copyright file="IProductRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.Product
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.DAL.Product;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IProductRepo.
    /// </summary>
    public interface IProductRepo
    {
        /// <summary>
        /// InsertProduct Method.
        /// </summary>
        /// <param name="product">param product.</param>
        /// <returns>returns interger.</returns>
        int InsertProduct(Product product);

        /// <summary>
        /// GetProduct Method.
        /// </summary>
        /// <returns>Returns List of Product.</returns>
        List<Product> GetProduct();

        /// <summary>
        /// UpdateProduct.
        /// </summary>
        /// <param name="product">product param.</param>
        /// <returns>returns boolean status.</returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="product">param product.</param>
        /// <returns>Returns boolean status.</returns>
        bool DeleteProduct(Product product);
    }

    /// <summary>
    /// Class ProductRepo implements IProductRepo.
    /// </summary>
    public class ProductRepo : IProductRepo
    {
        private readonly IProductRepository productDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepo"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="dal">dal parameter.</param>
        public ProductRepo(IProductRepository dal)
        {
            this.productDal = dal;
        }

        /// <summary>
        /// InsertProduct Method.
        /// </summary>
        /// <param name="product">product parameter from Product Model.</param>
        /// <returns>Returns integer.</returns>
        public int InsertProduct(Product product)
        {
            return this.productDal.InsertProducts(product);
        }

        /// <summary>
        /// Insert Product Method.
        /// </summary>
        /// <param name="product">product parameter from Product Model.</param>
        /// <returns>Returns boolean status.</returns>
        public bool DeleteProduct(Product product)
        {
            return this.productDal.DeleteProducts(product);
        }

        /// <summary>
        /// UpdateProduct Method.
        /// </summary>
        /// <param name="product">product param.</param>
        /// <returns>Boolean status.</returns>
        public bool UpdateProduct(Product product)
        {
            return this.productDal.UpdateProducts(product);
        }

        /// <summary>
        /// GetProduct Method.
        /// </summary>
        /// <returns>Returns list of products.</returns>
        public List<Product> GetProduct()
        {
            return this.productDal.GetProducts();
        }
    }
}
