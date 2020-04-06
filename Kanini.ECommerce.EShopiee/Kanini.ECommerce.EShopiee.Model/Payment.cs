// <copyright file="Payment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Model
{
    using System;

    /// <summary>
    /// Class Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or Sets PaymentId.
        /// </summary>
        public int PaymentId { get; set; }

        /// <summary>
        /// Gets or Sets PaymentTypeId.
        /// </summary>
        public int PaymentTypeId { get; set; }

        /// <summary>
        /// Gets or Sets PaymentType.
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// Gets or Sets CardNumber.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or Sets ExpiryDate.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or Sets CVV.
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// Gets or Sets Amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets DateOfPayment.
        /// </summary>
        public DateTime DateOfPayment { get; set; }
    }
}
