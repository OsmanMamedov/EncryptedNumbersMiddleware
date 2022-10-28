using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Controllers
{
    [ApiController]
    [Route("/api/EncryptedNumbers")]
    public class EncryptedNumbersController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            if (HttpContext.Items["numberDecrypt"] != null)
            {
                return Ok((Convert.ToInt32(HttpContext.Items["numberDecrypt"]) * 5).ToString());
            }
            return BadRequest();
        }
    }
}
