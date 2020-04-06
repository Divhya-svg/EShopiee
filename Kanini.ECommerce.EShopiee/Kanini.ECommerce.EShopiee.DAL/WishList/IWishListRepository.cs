// <copyright file="IWishListRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.WishList
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IWishListRepository.
    /// </summary>
    public interface IWishListRepository
    {
        /// <summary>
        /// GetWishLists Method.
        /// </summary>
        /// <returns>Returns List Of Items Added to cart.</returns>
        List<WishList> GetWishLists();

        /// <summary>
        /// InsertIntoWishList Method.
        /// </summary>
        /// <param name="wishList">Param1.</param>
        /// <returns>Returns Integer.</returns>
        int InsertIntoWishLists(WishList wishList);

        /// <summary>
        /// RemoveProductFromWishLists Method.
        /// </summary>
        /// <param name="wishList">Param1.</param>
        /// <returns>Returns boolean status.</returns>
        bool RemoveProductFromWishLists(WishList wishList);
    }

    /// <summary>
    /// Class WishList Implements interface IWishList.
    /// </summary>
    public class WishListRepository : IWishListRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishListRepository"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public WishListRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// Insert Method.
        /// </summary>
        /// <param name="wishList">Param1.</param>
        /// <returns>Returns integer.</returns>
        public int InsertIntoWishLists(WishList wishList)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@UserId", wishList.UserId, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@ProductId", wishList.ProductId, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@DateOfCartAdd", wishList.DateOfCartAdd, SqlDbType.DateTime));
            this.baseRepo.Insert("InsertIntoWishList", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <returns>Returns List of Product items added to cart.</returns>
        public List<WishList> GetWishLists()
        {
            var parameters = new List<SqlParameter>();
            List<WishList> wishLists = new List<WishList>();
            WishList wishList = null;
            var cart = this.baseRepo.GetData("ViewWishList", CommandType.StoredProcedure, null);
            while (cart.Read())
            {
                wishList = new WishList();
                wishList.Name = cart[0].ToString();
                wishList.Rating = Convert.ToDecimal(cart[1].ToString());
                wishList.CartDescription = cart[2].ToString();
                wishList.ShortDescription = cart[3].ToString();
                wishList.Image = cart[4].ToString();
                wishList.MRP = Convert.ToDecimal(cart[5].ToString());
                wishList.DealPrice = Convert.ToDecimal(cart[6].ToString());
                wishList.SavePrice = Convert.ToDecimal(cart[7].ToString());
                wishList.NoOfStock = Convert.ToInt32(cart[8].ToString());
                wishList.DateOfCartAdd = Convert.ToDateTime(cart[9].ToString());
                wishLists.Add(wishList);
            }

            return wishLists;
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="wishList">Param1.</param>
        /// <returns>Returns boolean status.</returns>
        public bool RemoveProductFromWishLists(WishList wishList)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@ProductId", wishList.ProductId, SqlDbType.Int));
            this.baseRepo.Delete("RemoveFromWishList", CommandType.StoredProcedure, parameters.ToArray(), out bool status);
            return status;
        }
    }
}
