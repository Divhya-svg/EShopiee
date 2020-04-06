// <copyright file="Register.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Model
{
    using System;

    /// <summary>
    /// Class Register.
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Gets or Sets RoleId.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets MobileNumber.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or Sets DateOfBirth.
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or Sets Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or Sets EmailId.
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or Sets Password.
        /// </summary>
        public string Password { get; set; }

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
        /// Gets or sets a value indicating whether gets or Sets UserIsActive.
        /// </summary>
        public bool UserIsActive { get; set; }
    }
}
