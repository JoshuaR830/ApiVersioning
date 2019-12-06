using api_versioning.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace api_versioning.Contollers
{
    public class ApiV2Controller : Controller
    {
        [HttpGet("/hello")]
        [ApiVersionUsed("2")]
        public string GetSomething() => "Hello World V2!";
    }
}