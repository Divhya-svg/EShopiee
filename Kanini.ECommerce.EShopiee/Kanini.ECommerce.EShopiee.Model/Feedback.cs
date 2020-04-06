// <copyright file="Feedback.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Model
{
    /// <summary>
    /// Class FeedBack.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Gets or Sets ProductId.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or Sets UserId.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets Feedback.
        /// </summary>
        public string FeedBack { get; set; }

        /// <summary>
        /// Gets or Sets Rating.
        /// </summary>
        public decimal Rating { get; set; }
    }
}
