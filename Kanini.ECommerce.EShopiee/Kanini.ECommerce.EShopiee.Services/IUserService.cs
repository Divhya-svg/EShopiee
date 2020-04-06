// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Services
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IUserService.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// GetAuthToke Method.
        /// </summary>
        /// <param name="userID">Param1.</param>
        /// <param name="secret">Param2.</param>
        /// <returns>returns string.</returns>
        string GetAuthToken(int userID, string secret);

        /// <summary>
        /// GetAll Method.
        /// </summary>
        /// <returns>Returns users.</returns>
        IEnumerable<UserDetails> GetAll();
    }
}
