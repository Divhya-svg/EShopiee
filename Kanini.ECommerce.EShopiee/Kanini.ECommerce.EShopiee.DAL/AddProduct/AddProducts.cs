using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.AddProduct
{
    public class AddProducts:IAddProducts
    {
        IBaseRepo baseRepo;
        public AddProducts(IBaseRepo repo)
        {
            baseRepo = repo;
        }
        public int InsertProducts(Product product)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(baseRepo.CreateParameter("@Name", 30, product.Name, DbType.String));
            parameters.Add(baseRepo.CreateParameter("@Rating",product.Rating, DbType.Decimal));
            parameters.Add(baseRepo.CreateParameter("@ManufactureDate", product.ManufactureDate, DbType.Date));
            parameters.Add(baseRepo.CreateParameter("@CartDescription", 100, product.CartDescription, DbType.String));
            parameters.Add(baseRepo.CreateParameter("@ShortDescription", product.ShortDescription, DbType.String));
            parameters.Add(baseRepo.CreateParameter("@Image",100,product.Image,DbType.String));
            parameters.Add(baseRepo.CreateParameter("@MRP",product.MRP, DbType.Decimal));
            parameters.Add(baseRepo.CreateParameter("@DealPrice", product.DealPrice, DbType.Decimal));
            parameters.Add(baseRepo.CreateParameter("@SavePrice", product.SavePrice, DbType.Decimal));
            parameters.Add(baseRepo.CreateParameter("@NoOfStock", product.NoOfStock, DbType.Int32));
            parameters.Add(baseRepo.CreateParameter("@ProductIsActive", product.ProductIsActive, DbType.Boolean));
            baseRepo.Insert("[dbo].[AddProduct]", CommandType.StoredProcedure, parameters.ToArray(), out int lastid);
            return lastid;


        }
    }
}
