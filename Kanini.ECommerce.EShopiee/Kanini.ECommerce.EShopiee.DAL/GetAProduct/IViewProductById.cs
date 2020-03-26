using System;
using System.Collections.Generic;
using System.Text;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.GetAProduct
{
    public interface IViewProductById
    {
        List<Product> GetProductById(Product prod);
    }
}
