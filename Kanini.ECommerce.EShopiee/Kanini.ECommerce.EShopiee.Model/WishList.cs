using System;
using System.Collections.Generic;
using System.Text;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class WishList
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateOfCartAdd { get; set; }

    }
}
