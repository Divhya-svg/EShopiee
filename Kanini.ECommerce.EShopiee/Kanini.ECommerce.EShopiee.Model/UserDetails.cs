// <copyright file="UserDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Kanini.ECommerce.EShopiee.Model
{
    using System;

    /// <summary>
    /// Class UserDetails.
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// Gets or Sets UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets RoleId.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or Sets RoleId.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets MobileNumber.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or Sets DateOfBirth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

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

        /// <summary>
        /// Gets or Sets Address1.
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or Sets Address2.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or Sets City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets Pincode.
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Gets or Sets RoleDescription.
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or Sets RoleNumber.
        /// </summary>
        public int RoleNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets RoleIsActive.
        /// </summary>
        public bool RoleIsActive { get; set; }

        /// <summary>
        /// Gets or Sets Token for Authentication.
        /// </summary>
        public string Token { get; set; }
    }
}
