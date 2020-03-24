using System;
using Kanini.ECommerce.EShopiee.Model;
using Kanini.ECommerce.EShopiee.BL.UserRegistration;

namespace Kanini.ECommerce.EShopiee.BL
{
    public class UserRegister:IUserRegister
    {
        IUserRegister userRegistration;
        public UserRegister(IUserRegister registration)
        {
            userRegistration = registration;
        }
        public int InsertUser(Register register)
        {
            return userRegistration.InsertUser(register);
        }

    }
}
