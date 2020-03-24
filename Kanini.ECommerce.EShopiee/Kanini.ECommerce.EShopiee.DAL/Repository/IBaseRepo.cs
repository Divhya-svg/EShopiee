using System;
using System.Data;
using System.Data.SqlClient;

namespace Kanini.ECommerce.EShopiee.DAL
{
    public interface IBaseRepo
    {
        void Closeconnection(SqlConnection connection);
        SqlParameter CreateParameter(string name, int size, object value, DbType dbType);
        SqlParameter CreateParameter(string name, object value, DbType dbType);
        SqlParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction);
        DataSet GetData(string commandtext, CommandType commandtype, SqlParameter[] parameters = null);
        int Insert(string commandtext, CommandType commandType, SqlParameter[] parameters, out int lastId);
        bool Update(string commandtext, CommandType commandType, SqlParameter[] parameters, out bool status);
        bool Delete(string commandtext, CommandType commandType, SqlParameter[] parameters, out bool status);
        SqlCommand Common(string commandtext, CommandType commandtype, SqlParameter[] parameters = null);
    }
}
