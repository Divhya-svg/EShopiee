using System;
using System.Collections.Generic;
using System.Text;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class UserAddress
    {
        public int UserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
    }
}
