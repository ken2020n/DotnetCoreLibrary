using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiBase.JsonConverters;

namespace WebApiBase.Models
{
    public class ResponseModel<T> : IActionResult
    {
        public bool Success { get; set; }

        public string Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<T> Data { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return Task.Run(() =>
            {
                context.HttpContext.Response.ContentType = "application/json";

                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    Converters =
                    {
                        new DateTimeJsonConverter()
                    }
                };

                var json = JsonSerializer.Serialize(this, jsonSerializerOptions);
                var jsonBytes = Encoding.UTF8.GetBytes(json);
                context.HttpContext.Response.Body.WriteAsync(jsonBytes, 0, jsonBytes.Length);
            });
        }
    }
}