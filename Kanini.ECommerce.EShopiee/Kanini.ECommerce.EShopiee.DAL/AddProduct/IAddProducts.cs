using System;
using System.Collections.Generic;
using System.Text;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.AddProduct
{
    public interface IAddProducts
    {
        int InsertProducts(Product product);
    }
}
