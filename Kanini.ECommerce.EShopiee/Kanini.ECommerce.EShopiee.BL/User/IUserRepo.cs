// <copyright file="IUserRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.User
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.DAL.User;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IUserRepo.
    /// </summary>
    public interface IUserRepo
    {
        /// <summary>
        /// InsertUser Method.
        /// </summary>
        /// <param name="register">register Parameter.</param>
        /// <returns>Returns integer.</returns>
        int InsertUser(Register register);

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="roleNumber">Param1.</param>
        /// <returns>List of Users.</returns>
        List<UserDetails> GetUserDetails(UserDetails roleNumber);

        /// <summary>
        /// DeleteUser Method.
        /// </summary>
        /// <param name="register">register Parameter.</param>
        /// <returns>returns Boolean status.</returns>
        bool DeleteUser(Register register);
    }

    /// <summary>
    /// Class UserBl implemets IUserBl interface.
    /// </summary>
    public class UserRepo : IUserRepo
    {
        private readonly IUserRepository usersdal;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepo"/> class.
        /// Construtor injection.
        /// </summary>
        /// <param name="user">user parameter.</param>
        public UserRepo(IUserRepository user)
        {
            this.usersdal = user;
        }

        /// <summary>
        /// InsertUser method.
        /// </summary>
        /// <param name="register">register parameter.</param>
        /// <returns>Returns integer.</returns>
        public int InsertUser(Register register)
        {
            return this.usersdal.InsertUsers(register);
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="roleNumber">Param1.</param>
        /// <returns>List of Users.</returns>
        public List<UserDetails> GetUserDetails(UserDetails roleNumber)
        {
            return this.usersdal.GetUsers(roleNumber);
        }

        /// <summary>
        /// DeleteUser Method.
        /// </summary>
        /// <param name="register">register param.</param>
        /// <returns>Returns boolean status.</returns>
        public bool DeleteUser(Register register)
        {
            return this.usersdal.DeleteUsers(register);
        }
    }
}
