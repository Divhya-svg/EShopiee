// <copyright file="IUserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.User
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface Users.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// InserUsers Method.
        /// </summary>
        /// <param name="register">Param1.</param>
        /// <returns>Returns integer.</returns>
        int InsertUsers(Register register);

        /// <summary>
        /// DeleteUsers Method.
        /// </summary>
        /// <param name="register">Param1.</param>
        /// <returns>Returns boolean status.</returns>
        bool DeleteUsers(Register register);

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="roleNumber">Param1.</param>
        /// <returns>Returns list of Users.</returns>
        List<UserDetails> GetUsers(UserDetails roleNumber);
    }

    /// <summary>
    /// Class users Implements interface IUsers.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// Constructor Injection.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public UserRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// InsertUsers Method.
        /// </summary>
        /// <param name="register">Param1.</param>
        /// <returns>Returns integer.</returns>
        public int InsertUsers(Register register)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@RoleId", register.RoleId, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@Name", 30, register.Name, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@MobileNumber", 15, register.MobileNumber, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@DateOfBirth", register.DateOfBirth, SqlDbType.Date));
            parameters.Add(this.baseRepo.CreateParameter("@Gender", 10, register.Gender, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@EmailId", 30, register.EmailId, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@Password", 20, register.Password, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@RoleNumber", register.RoleNumber, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@CreatedDate", register.CreatedDate, SqlDbType.Date));
            parameters.Add(this.baseRepo.CreateParameter("@ModifiedDate", register.ModifiedDate, SqlDbType.Date));
            parameters.Add(this.baseRepo.CreateParameter("@UserIsActive", register.UserIsActive, SqlDbType.Bit));
            this.baseRepo.Insert("Rbegister", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }

        /// <summary>
        /// DeleteUsers Method.
        /// </summary>
        /// <param name="register">Param1.</param>
        /// <returns>Returns boolean status.</returns>
        public bool DeleteUsers(Register register)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@RoleId", register.RoleId, SqlDbType.Int));
            this.baseRepo.Delete("DeleteRoleIdFromUsers", CommandType.StoredProcedure, parameters.ToArray(), out bool status);
            return status;
        }

        /// <summary>
        /// Get Method.
        /// </summary>
        /// <param name="roleNumber">Param1.</param>
        /// <returns>List of Users.</returns>
        public List<UserDetails> GetUsers(UserDetails roleNumber)
        {
            var parameters = new List<SqlParameter>();
            List<UserDetails> userList = new List<UserDetails>();
            UserDetails user = null;
            parameters.Add(this.baseRepo.CreateParameter("@RoleNumber", roleNumber.RoleNumber, SqlDbType.Int));
            var userdetail = this.baseRepo.GetData("ViewUsers", CommandType.StoredProcedure, parameters.ToArray());
            while (userdetail.Read())
            {
                user = new UserDetails();
                user.RoleId = Convert.ToInt32(userdetail[0].ToString());
                user.UserId = Convert.ToInt32(userdetail[1].ToString());
                user.Name = userdetail[2].ToString();
                user.MobileNumber = userdetail[3].ToString();
                user.DateOfBirth = Convert.ToDateTime(userdetail[4].ToString());
                user.Gender = userdetail[5].ToString();
                user.EmailId = userdetail[6].ToString();
                user.Password = userdetail[7].ToString();
                user.CreatedDate = Convert.ToDateTime(userdetail[8].ToString());
                user.ModifiedDate = Convert.ToDateTime(userdetail[9].ToString());
                user.UserIsActive = Convert.ToBoolean(userdetail[10].ToString());
                user.Address1 = userdetail[11].ToString();
                user.Address2 = userdetail[12].ToString();
                user.City = userdetail[13].ToString();
                user.State = userdetail[14].ToString();
                user.PinCode = userdetail[15].ToString();
                user.RoleDescription = userdetail[16].ToString();
                user.RoleNumber = Convert.ToInt32(userdetail[17].ToString());
                user.RoleIsActive = Convert.ToBoolean(userdetail[18].ToString());
                userList.Add(user);
            }

            return userList;
        }
    }
}
