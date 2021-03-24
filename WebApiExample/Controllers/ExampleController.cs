using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebApiBase.Models;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(string id, [FromQuery] DataInfo request)
        {
            var result = new StringBuilder();
            result.AppendLine("Id: " + id);
            result.AppendLine("Text: " + request.Text);
            result.AppendLine("Number: " + request.Number);
            result.AppendLine("Time: " + request.Time);
            result.AppendLine("Currency: " + request.Currency);

            return Ok(result.ToString());
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post(RequestModel<DataInfo> request)
        {
            var data = request.Data.FirstOrDefault();
            if (data == null)
            {
                return BadRequest();
            }

            return new ResponseModel<DataResult>
            {
                Success = true,
                Code = request.ApiKey,
                Message = request.Signature,
                Data = new List<DataResult>
                {
                    new DataResult
                    {
                        Text = data.Text,
                        Number = data.Number,
                        Time = data.Time,
                        Currency = data.Currency
                    }
                }
            };
        }
    }
}