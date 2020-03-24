using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.UserRegistration
{
    public class SignUp:ISignUp
    {
        IBaseRepo repo;
        public SignUp(IBaseRepo baseRepo)
        {
            repo = baseRepo;
        }
        public int UserSignUp(Register register)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(repo.CreateParameter("@RoleId", register.RoleId, DbType.Int32));
            parameters.Add(repo.CreateParameter("@Name", 30, register.Name, DbType.String));
            parameters.Add(repo.CreateParameter("@MobileNumber", 15, register.MobileNumber, DbType.String));
            parameters.Add(repo.CreateParameter("@DateOfBirth", register.DateOfBirth, DbType.Date));
            parameters.Add(repo.CreateParameter("@Gender", 10, register.Gender, DbType.String));
            parameters.Add(repo.CreateParameter("@EmailId", 30, register.EmailId, DbType.String));
            parameters.Add(repo.CreateParameter("@Password", 20, register.Password, DbType.String));
            parameters.Add(repo.CreateParameter("@RoleNumber", register.RoleNumber, DbType.Int32));
            parameters.Add(repo.CreateParameter("@CreatedDate", register.CreatedDate, DbType.Date));
            parameters.Add(repo.CreateParameter("@ModifiedDate", register.ModifiedDate, DbType.Date));
            parameters.Add(repo.CreateParameter("@UserIsActive", register.UserisActive, DbType.Boolean));
            repo.Insert(" [dbo].[Register]", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;
        }
    }
}
