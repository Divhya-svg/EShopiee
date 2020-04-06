// <copyright file="IUserLoginRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.UserLogin
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IUserLoginRepository.
    /// </summary>
    public interface IUserLoginRepository
    {
        /// <summary>
        /// GetUserForLogin Method.
        /// </summary>
        /// <param name="userDetails">userDetails param.</param>
        /// <returns>Returns user.</returns>
        UserDetails GetUserForLogin(UserDetails userDetails);
    }

    /// <summary>
    /// Class IUserLoginRepository implements UserLoginRepository.
    /// </summary>
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginRepository"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="repo">repo parameter.</param>
        public UserLoginRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// GetUSerForLogin Method.
        /// </summary>
        /// <param name="userDetails">userDetails parameter.</param>
        /// <returns>returns user.</returns>
        public UserDetails GetUserForLogin(UserDetails userDetails)
        {
            var parameters = new List<SqlParameter>();
            UserDetails userDet = null;
            parameters.Add(this.baseRepo.CreateParameter("@EmailId",  userDetails.EmailId, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@MobileNumber", userDetails.MobileNumber, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@Password", userDetails.Password, SqlDbType.VarChar));
            var userdetail = this.baseRepo.GetData("UserLogin", CommandType.StoredProcedure, parameters.ToArray());
            while (userdetail.Read())
            {
                userDet = new UserDetails();
                userDet.UserId = Convert.ToInt32(userdetail["UserId"]);
                userDet.Name = userdetail["Name"].ToString();
                userDet.MobileNumber = userdetail["MobileNumber"].ToString();
                userDet.DateOfBirth = Convert.ToDateTime(userdetail["DateOfBirth"].ToString());
                userDet.Gender = userdetail["Gender"].ToString();
                userDet.EmailId = userdetail["EmailId"].ToString();
                userDet.Password = userdetail["Password"].ToString();
                userDet.CreatedDate = Convert.ToDateTime(userdetail["CreatedDate"].ToString());
                userDet.ModifiedDate = Convert.ToDateTime(userdetail["ModifiedDate"].ToString());
                userDet.UserIsActive = Convert.ToBoolean(userdetail["UserIsActive"].ToString());
            }

            return userDet;
        }
    }
}
