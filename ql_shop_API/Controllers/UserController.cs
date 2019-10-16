using Microsoft.AspNetCore.Mvc;
using ql_shop_API.Connect;
using System;

namespace ql_shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/User
        [HttpGet]
        public string Get()
        {
            try
            {
                User mysqlGet = new User();
                return mysqlGet.getUser();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }
    }
}