using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.AddUserRole
{
    public class UserRole
    {
        IBaseRepo baseRepo;
        public UserRole(IBaseRepo repo)
        {
            baseRepo = repo;
        }
        public int InsertUserRole(UserRoles userRoles)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(baseRepo.CreateParameter("@RoleDescription",20, userRoles.RoleDescription, DbType.String));
            parameters.Add(baseRepo.CreateParameter("@RoleNumber", userRoles.RoleNumber, DbType.Int32));
            parameters.Add(baseRepo.CreateParameter("@CreatedDate", userRoles.CreatedDate, DbType.Date));
            parameters.Add(baseRepo.CreateParameter("@ModifiedDate", userRoles.ModifiedDate, DbType.Date));
            parameters.Add(baseRepo.CreateParameter("@RoleIsActive", userRoles.RoleIsActive, DbType.Boolean));
            baseRepo.Insert("[dbo].[InsertUserRoles]", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }
    }
}
