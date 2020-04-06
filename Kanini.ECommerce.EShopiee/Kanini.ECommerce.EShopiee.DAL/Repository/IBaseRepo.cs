// <copyright file="IBaseRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Kanini.ECommerce.EShopiee.DAL.Repository
{
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Interface IBaseRepo.
    /// </summary>
    public interface IBaseRepo
    {
        /// <summary>
        /// CloseConnection Method.
        /// </summary>
        /// <param name="connection">connection.</param>
        void Closeconnection(SqlConnection connection);

        /// <summary>
        /// CreateParameter Method.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="size">size.</param>
        /// <param name="value">value.</param>
        /// <param name="dbType">dbType.</param>
        /// <returns>parameter.</returns>
        SqlParameter CreateParameter(string name, int size, object value, SqlDbType dbType);

        /// <summary>
        /// CreateParameter Method.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="value">value.</param>
        /// <param name="dbType">dbType.</param>
        /// <returns>Returns parameters.</returns>
        SqlParameter CreateParameter(string name, object value, SqlDbType dbType);

        /// <summary>
        /// CreateParameter Method.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="size">size.</param>
        /// <param name="value">value.</param>
        /// <param name="dbType">dbType.</param>
        /// <param name="direction">direction.</param>
        /// <returns>Returns parameter.</returns>
        SqlParameter CreateParameter(string name, int size, object value, SqlDbType dbType, ParameterDirection direction);

        /// <summary>
        /// GetData Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandtype">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns>Returns dataset.</returns>
        SqlDataReader GetData(string commandtext, CommandType commandtype, SqlParameter[] parameters = null);

        /// <summary>
        /// InsertMethod.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandType">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="lastId">lastid.</param>
        /// <returns>returns lastId.</returns>
        int Insert(string commandtext, CommandType commandType, SqlParameter[] parameters, out int lastId);

        /// <summary>
        /// Update Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandType">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="status">status.</param>
        /// <returns>Returns boolean Status.</returns>
        bool Update(string commandtext, CommandType commandType, SqlParameter[] parameters, out bool status);

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandType">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="status">status.</param>
        /// <returns>Returns bool status.</returns>
        bool Delete(string commandtext, CommandType commandType, SqlParameter[] parameters, out bool status);

        /// <summary>
        /// Common Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandtype">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns>Returns command.</returns>
        SqlCommand Common(string commandtext, CommandType commandtype, SqlParameter[] parameters = null);

        /// <summary>
        /// Class BaseRepo Implements IBaseRepo.
        /// </summary>
    }

    /// <summary>
    /// Class BaseRepo Implements IBaseRepo.
    /// </summary>
    public class BaseRepo : IBaseRepo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepo"/> class.
        /// Constructor injection.
        /// </summary>
        /// <param name="configuration">configuration parameter.</param>
        public BaseRepo(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Gets or Sets Connection String.
        /// </summary>
        private string ConnectionString { get; set; }

        /// <summary>
        /// CloseConnection Method.
        /// </summary>
        /// <param name="connection">connection parameter.</param>
        public void Closeconnection(SqlConnection connection)
        {
            connection.Close();
        }

        /// <summary>
        /// CreateParameter Mathod.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="size">size.</param>
        /// <param name="value">value.</param>
        /// <param name="dbType">dbType.</param>
        /// <returns>Prameters.</returns>
        public SqlParameter CreateParameter(string name, int size, object value, SqlDbType dbType)
        {
            return this.CreateParameter(name, size, value, dbType, ParameterDirection.Input);
        }

        /// <summary>
        /// CreateParameter method.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="value">value.</param>
        /// <param name="dbType">dbType.</param>
        /// <returns>Returns parameters.</returns>
        public SqlParameter CreateParameter(string name, object value, SqlDbType dbType)
        {
            return this.CreateParameter(name, 0, value, dbType, ParameterDirection.Input);
        }

        /// <summary>
        /// Create Parameter Method.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="size">size.</param>
        /// <param name="value">value.</param>
        /// <param name="dbType">dbType.</param>
        /// <param name="direction">direction.</param>
        /// <returns>Sql Parameter.</returns>
        public SqlParameter CreateParameter(string name, int size, object value, SqlDbType dbType, ParameterDirection direction)
        {
            return new SqlParameter
            {
                SqlDbType = dbType,
                ParameterName = name,
                Size = size,
                Direction = direction,
                Value = value,
            };
        }

        /// <summary>
        /// GetData Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandtype">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns>dataset.</returns>
        public SqlDataReader GetData(string commandtext, CommandType commandtype, SqlParameter[] parameters = null)
        {
            SqlCommand command = this.Common(commandtext, commandtype, parameters);
            SqlDataReader oReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            return oReader;
        }

        /// <summary>
        /// GetScalarValue Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandtype">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns>ExecuteScalar.</returns>
        public object GetScalarValue(string commandtext, CommandType commandtype, SqlParameter[] parameters = null)
        {
            SqlCommand command = this.Common(commandtext, commandtype, parameters);
            return command.ExecuteScalar();
        }

        /// <summary>
        /// InsertMethod.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandtype">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="lastId">lastId.</param>
        /// <returns>Returns integer.</returns>
        public int Insert(string commandtext, CommandType commandtype, SqlParameter[] parameters, out int lastId)
        {
            lastId = 0;
            SqlCommand command = this.Common(commandtext, commandtype, parameters);
            lastId = command.ExecuteNonQuery();
            return lastId;
        }

        /// <summary>
        /// Update Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandType">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="status">status.</param>
        /// <returns>Returns boolean Status.</returns>
        public bool Update(string commandtext, CommandType commandType, SqlParameter[] parameters, out bool status)
        {
            int result = 0;
            status = false;
            SqlCommand command = this.Common(commandtext, commandType, parameters);
            result = command.ExecuteNonQuery();

            if (result == 1)
            {
                status = true;
            }

            return status;
        }

        /// <summary>
        /// Delete Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandType">commandType.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="status">status.</param>
        /// <returns>returns boolean status.</returns>
        public bool Delete(string commandtext, CommandType commandType, SqlParameter[] parameters, out bool status)
        {
            int result = 0;
            status = false;
            SqlCommand command = this.Common(commandtext, commandType, parameters);
            result = command.ExecuteNonQuery();

            if (result == 1)
            {
                status = true;
            }

            return status;
        }

        /// <summary>
        /// Comman Method.
        /// </summary>
        /// <param name="commandtext">commandText.</param>
        /// <param name="commandtype">commadType.</param>
        /// <param name="parameters">parameters.</param>
        /// <returns>Returns command.</returns>
        public SqlCommand Common(string commandtext, CommandType commandtype, SqlParameter[] parameters = null)
        {
            var connection = new SqlConnection(this.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(commandtext, connection);
            command.CommandType = commandtype;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }
    }
}
