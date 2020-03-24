using System;
using System.Collections.Generic;
using System.Text;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class UserRoles
    {
        public string RoleDescription { get; set; }
        public int RoleNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool RoleIsActive { get; set; }
    }
}
