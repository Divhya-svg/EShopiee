using System;
using System.Collections.Generic;
using System.Text;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.BL.UserRegistration
{
    public interface IUserRegister
    {
        int InsertUser(Register register);
    }
}
