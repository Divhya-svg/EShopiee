using System;

namespace Kanini.ECommerce.EShopiee.Model
{
    public class Register
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int RoleNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool UserisActive { get; set; }
       
    }
}
