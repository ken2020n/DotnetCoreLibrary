using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApiBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok(new
            {
                DateTime.Now
            });
        }
    }
}