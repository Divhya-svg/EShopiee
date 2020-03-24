using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kanini.ECommerce.EShopiee.BL;
using Kanini.ECommerce.EShopiee.Model;
using Kanini.ECommerce.EShopiee.BL.UserRegistration;

namespace Kanini.ECommerce.EShopiee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : Controller
    {
        IUserRegister userregister;
        public SignUpController(IUserRegister userRegister)
        {
            userregister = userRegister;
        }
        [HttpPost]
        public int UserRegister(Register register)
        {
            return userregister.InsertUser(register);
        }
    }
}