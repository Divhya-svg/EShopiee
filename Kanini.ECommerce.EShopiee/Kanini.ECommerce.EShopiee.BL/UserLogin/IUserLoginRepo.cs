// <copyright file="IUserLoginRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.UserLogin
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.DAL.UserLogin;
    using Kanini.ECommerce.EShopiee.Model;
    using Kanini.ECommerce.EShopiee.Services;

    /// <summary>
    /// Interface IuserLoginRepo.
    /// </summary>
    public interface IUserLoginRepo
    {
        /// <summary>
        /// Gets or sets Secret.
        /// </summary>
        string Secret { get; set; }

        /// <summary>
        /// Authenticate Method.
        /// </summary>
        /// <param name="emailId">email.</param>
        /// <param name="mobileNumber">mobileNumber.</param>
        /// <param name="password">password.</param>
        /// <param name="secret">secret key.</param>
        /// <returns>token.</returns>
        string Authenticate(string emailId, string mobileNumber, string password, string secret);

        /// <summary>
        /// GetAll Method.
        /// </summary>
        /// <returns>Users.</returns>
        IEnumerable<UserDetails> GetAll();
        /// <summary>
        /// Class LoginBl implements ILoginBl.
        /// </summary>
    }

    /// <summary>
    /// Class UserLoginRepo implements IUserLoginRepo interface.
    /// </summary>
    public class UserLoginRepo : IUserLoginRepo
    {
        private readonly IUserLoginRepository loginDal;
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginRepo"/> class.
        /// Constructor inection.
        /// </summary>
        /// <param name="dal">dal param.</param>
        /// <param name="service">service param.</param>
        public UserLoginRepo(IUserLoginRepository dal, IUserService service)
        {
           this.loginDal = dal;
           this.userService = service;
        }

        /// <summary>
        /// Gets or sets secret or Sets Secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Authenticate Method.
        /// </summary>
        /// <param name="emailId">email.</param>
        /// <param name="mobileNumber">mobileNumber.</param>
        /// <param name="password">password.</param>
        /// <param name="secret">secret.</param>
        /// <returns>Return token.</returns>
        public string Authenticate(string emailId, string mobileNumber, string password, string secret)
        {
            UserDetails oDetails = new UserDetails() { EmailId = emailId, MobileNumber = mobileNumber, Password = password };
            var user = this.loginDal.GetUserForLogin(oDetails);
            return this.userService.GetAuthToken(user.UserId, secret);
        }

        /// <summary>
        /// GetAll Method.
        /// </summary>
        /// <returns>Returns user.</returns>
        public IEnumerable<UserDetails> GetAll()
        {
            var users = this.userService.GetAll();
            return users;
        }
    }
}
