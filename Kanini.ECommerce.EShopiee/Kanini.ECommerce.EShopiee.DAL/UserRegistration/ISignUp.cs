using System;
using System.Collections.Generic;
using System.Text;
using Kanini.ECommerce.EShopiee.Model;

namespace Kanini.ECommerce.EShopiee.DAL.UserRegistration
{
    public interface ISignUp
    {
        int UserSignUp(Register register);
    }
}
