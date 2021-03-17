using Microsoft.AspNetCore.Mvc;

namespace WebApiBase.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ExampleControllers : ControllerBase
    {
    }
}