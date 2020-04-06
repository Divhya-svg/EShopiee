// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Model
{
    using System;

    /// <summary>
    /// Class Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets productId .
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets Name .
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Rating .
        /// </summary>
        public decimal Rating { get; set; }

        /// <summary>
        /// Gets or sets ManufactureDate .
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets CartDescription .
        /// </summary>
        public string CartDescription { get; set; }

        /// <summary>
        /// Gets or sets ShortDescription .
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets Image .
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets MRP .
        /// </summary>
        public decimal MRP { get; set; }

        /// <summary>
        /// Gets or sets DealPrice .
        /// </summary>
        public decimal DealPrice { get; set; }

        /// <summary>
        /// Gets or sets SavePrice .
        /// </summary>
        public decimal SavePrice { get; set; }

        /// <summary>
        /// Gets or sets NoOfStock .
        /// </summary>
        public int NoOfStock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets ProductIsActive .
        /// </summary>
        public bool ProductIsActive { get; set; }
    }
}
