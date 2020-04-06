// <copyright file="IRoleRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.UserRole
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Kanini.ECommerce.EShopiee.DAL.Repository;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Inertface IRoles.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// InsertUserRoles.
        /// </summary>
        /// <param name="userRoles">Param1.</param>
        /// <returns>Returns integer.</returns>
        int InsertUserRoles(UserRoles userRoles);

        /// <summary>
        /// DeleteUserRoles Method.
        /// </summary>
        /// <param name="userRoles">Param1.</param>
        /// <returns>Retuns boolean status.</returns>
        bool DeleteUserRoles(UserRoles userRoles);

        /// <summary>
        /// GetUserRoles Method.
        /// </summary>
        /// <returns>Returns List of UserRoles.</returns>
        List<UserRoles> GetUserRoles();

        /// <summary>
        /// UpdateUserRoles Method.
        /// </summary>
        /// <param name="userRoles">Param1.</param>
        /// <returns>Returns boolean status.</returns>
        bool UpdateUserRoles(UserRoles userRoles);
    }

    /// <summary>
    /// Class Roles implement interface IRoles.
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly IBaseRepo baseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="repo">Param1.</param>
        public RoleRepository(IBaseRepo repo)
        {
            this.baseRepo = repo;
        }

        /// <summary>
        /// InsertUSerRoles Method.
        /// </summary>
        /// <param name="userRoles">Param1.</param>
        /// <returns>Returns interger.</returns>
        public int InsertUserRoles(UserRoles userRoles)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@RoleDescription", 20, userRoles.RoleDescription, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@RoleNumber", userRoles.RoleNumber, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@CreatedDate", userRoles.CreatedDate, SqlDbType.DateTime));
            parameters.Add(this.baseRepo.CreateParameter("@ModifiedDate", userRoles.ModifiedDate, SqlDbType.DateTime));
            parameters.Add(this.baseRepo.CreateParameter("@RoleIsActive", userRoles.RoleIsActive, SqlDbType.Bit));
            this.baseRepo.Insert("InsertUserRoles", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }

        /// <summary>
        /// DeleteUserRoles Method.
        /// </summary>
        /// <param name="userRoles">Param1.</param>
        /// <returns>Returns Boolean status.</returns>
        public bool DeleteUserRoles(UserRoles userRoles)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@RoleId", userRoles.RoleId, SqlDbType.Int));
            this.baseRepo.Delete("DeleteRoleIdFromUserRoles", CommandType.StoredProcedure, parameters.ToArray(), out bool status);
            return status;
        }

        /// <summary>
        /// GetUserRoles Method.
        /// </summary>
        /// <returns>Returns List of UserRoles.</returns>
        public List<UserRoles> GetUserRoles()
        {
            var parameters = new List<SqlParameter>();
            List<UserRoles> userRolesList = new List<UserRoles>();
            UserRoles user = null;
            var role = this.baseRepo.GetData("GetUserRoles", CommandType.StoredProcedure, null);
            while (role.Read())
            {
                user = new UserRoles();
                user.RoleId = Convert.ToInt32(role[0].ToString());
                user.RoleDescription = role[1].ToString();
                user.RoleNumber = Convert.ToInt32(role[2].ToString());
                user.CreatedDate = Convert.ToDateTime(role[3].ToString());
                user.ModifiedDate = Convert.ToDateTime(role[4].ToString());
                user.RoleIsActive = Convert.ToBoolean(role[5].ToString());
                userRolesList.Add(user);
            }

            return userRolesList;
        }

        /// <summary>
        /// UpdateUserRoles Method.
        /// </summary>
        /// <param name="userRoles">Param1.</param>
        /// <returns>Returns boolean status.</returns>
        public bool UpdateUserRoles(UserRoles userRoles)
        {
            userRoles = new UserRoles
            {
                RoleDescription = userRoles.RoleDescription,
                RoleNumber = userRoles.RoleNumber,
                ModifiedDate = userRoles.ModifiedDate,
                RoleIsActive = userRoles.RoleIsActive,
            };
            var parameters = new List<SqlParameter>();
            parameters.Add(this.baseRepo.CreateParameter("@RoleDescription", userRoles.RoleDescription, SqlDbType.VarChar));
            parameters.Add(this.baseRepo.CreateParameter("@RoleNumber", userRoles.RoleNumber, SqlDbType.Int));
            parameters.Add(this.baseRepo.CreateParameter("@ModifiedDate", userRoles.ModifiedDate, SqlDbType.DateTime));
            parameters.Add(this.baseRepo.CreateParameter("@RoleIsActive", userRoles.RoleIsActive, SqlDbType.Bit));
            this.baseRepo.Update("UpdateUserRole", CommandType.StoredProcedure, parameters.ToArray(), out bool status);
            return status;
        }
    }
}
