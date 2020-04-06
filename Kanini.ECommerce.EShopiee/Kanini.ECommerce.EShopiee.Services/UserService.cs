// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using Kanini.ECommerce.EShopiee.Model;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Class UserService implements IUserService.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly List<UserDetails> users = new List<UserDetails>();

        /// <summary>
        /// Gets or Sets Secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// GetAuthToken Method.
        /// </summary>
        /// <param name="userID">Param1.</param>
        /// <param name="secret">Param2.</param>
        /// <returns>Returns token.</returns>
        public string GetAuthToken(int userID, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            string tokens = string.Empty;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokens = tokenHandler.WriteToken(token);
            return tokens;
        }

        /// <summary>
        /// GetAll Method.
        /// </summary>
        /// <returns>Returns users.</returns>
        public IEnumerable<UserDetails> GetAll()
        {
            return this.users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }
    }
}
