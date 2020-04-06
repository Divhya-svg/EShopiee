// <copyright file="IWishListRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.WishList
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.DAL.WishList;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IWishListRepo.
    /// </summary>
    public interface IWishListRepo
    {
        /// <summary>
        /// GetWishList Method.
        /// </summary>
        /// <returns>Returns List of products added to cart.</returns>
        List<WishList> GetWishList();

        /// <summary>
        /// InsertintoWishList Method.
        /// </summary>
        /// <param name="wishList">wishList parameter.</param>
        /// <returns>Returns integer.</returns>
        int InsertIntoWishList(WishList wishList);

        /// <summary>
        /// RemoveFromWishList Method.
        /// </summary>
        /// <param name="wishList">wishList parameter.</param>
        /// <returns>returns boolean status.</returns>
        bool RemoveFromWishList(WishList wishList);
    }

    /// <summary>
    /// Class WishListBl implements interface IWishListbl.
    /// </summary>
    public class WishListRepo : IWishListRepo
    {
        private readonly IWishListRepository wishListDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="WishListRepo"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="dal">dal parameter.</param>
        public WishListRepo(IWishListRepository dal)
        {
            this.wishListDal = dal;
        }

        /// <summary>
        /// InsertIntoWishList Method.
        /// </summary>
        /// <param name="wishList">wishList Parameter.</param>
        /// <returns>Returns integer.</returns>
        public int InsertIntoWishList(WishList wishList)
        {
            return this.wishListDal.InsertIntoWishLists(wishList);
        }

        /// <summary>
        /// GetWishList Method.
        /// </summary>
        /// <returns>Returns List of products added to cart.</returns>
        public List<WishList> GetWishList()
        {
            return this.wishListDal.GetWishLists();
        }

        /// <summary>
        /// Remove from WishListMethod.
        /// </summary>
        /// <param name="wishList">wishListParam.</param>
        /// <returns>Returns boolean status.</returns>
        public bool RemoveFromWishList(WishList wishList)
        {
            return this.wishListDal.RemoveProductFromWishLists(wishList);
        }
    }
}
