// <copyright file="IRoleRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.BL.UserRole
{
    using System.Collections.Generic;
    using Kanini.ECommerce.EShopiee.DAL.UserRole;
    using Kanini.ECommerce.EShopiee.Model;

    /// <summary>
    /// Interface IRoleRepository.
    /// </summary>
    public interface IRoleRepo
    {
        /// <summary>
        /// InsertUserRole Method.
        /// </summary>
        /// <param name="userRoles">userRoles parameter.</param>
        /// <returns>Return Integer.</returns>
        int InsertUserRole(UserRoles userRoles);

        /// <summary>
        /// DeleteUserRole Method.
        /// </summary>
        /// <param name="userRoles">userRoles parameter.</param>
        /// <returns>Returns boolean status.</returns>
        bool DeleteUserRole(UserRoles userRoles);

        /// <summary>
        /// GetUserRole Method.
        /// </summary>
        /// <returns>Returns List.</returns>
        List<UserRoles> GetUserRole();

        /// <summary>
        /// UpdateUserRole Method.
        /// </summary>
        /// <param name="userRoles">userRoles parameter.</param>
        /// <returns>Returns boolean status.</returns>
        bool UpdateUserRole(UserRoles userRoles);
        /// <summary>
        /// Class RoleBl implements interface IRoleBl.
        /// </summary>
    }

    /// <summary>
    /// Class ReoleRepo implements IRoleRepo.
    /// </summary>
    public class RoleRepo : IRoleRepo
    {
        private readonly IRoleRepository roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepo"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="userRole">userRole parameter.</param>
        public RoleRepo(IRoleRepository userRole)
        {
            this.roles = userRole;
        }

        /// <summary>
        /// InsertUserRole Mehod.
        /// </summary>
        /// <param name="userRoles">userRoles parameter.</param>
        /// <returns>Returns interger.</returns>
        public int InsertUserRole(UserRoles userRoles)
        {
           return this.roles.InsertUserRoles(userRoles);
        }

        /// <summary>
        /// DeleteUserRole Method.
        /// </summary>
        /// <param name="userRoles">userRoles parameter.</param>
        /// <returns>Returns boolean status.</returns>
        public bool DeleteUserRole(UserRoles userRoles)
        {
            return this.roles.DeleteUserRoles(userRoles);
        }

        /// <summary>
        /// GetUserRole Method.
        /// </summary>
        /// <returns>Returns List.</returns>
        public List<UserRoles> GetUserRole()
        {
            return this.roles.GetUserRoles();
        }

        /// <summary>
        /// UpdateUserRole Method.
        /// </summary>
        /// <param name="userRoles">userRoles parameter.</param>
        /// <returns>returns boolean status.</returns>
        public bool UpdateUserRole(UserRoles userRoles)
        {
            return this.roles.UpdateUserRoles(userRoles);
        }
    }
}
