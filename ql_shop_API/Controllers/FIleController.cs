using Microsoft.AspNetCore.Mvc;
using ql_shop_API.Connect;
using System;

namespace ql_shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FIleController : ControllerBase
    {
        // GET api/File
        [HttpGet]
        public string Get()
        {
            try
            {
                File mysqlGet = new File();
                return mysqlGet.getFile();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                throw;
            }
        }
    }
}