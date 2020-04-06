// <copyright file="UserRoles.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Model
{
    using System;

    /// <summary>
    /// Class UserRoles.
    /// </summary>
    public class UserRoles
    {
        /// <summary>
        /// Gets or Sets RoleId.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or Sets RoleDescription.
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or Sets RoleNumber.
        /// </summary>
        public int RoleNumber { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets ModifiedDate.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets RoleIsActive.
        /// </summary>
        public bool RoleIsActive { get; set; }
    }
}
