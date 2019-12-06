using api_versioning.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace api_versioning.Contollers
{
    public class ApiV1Controller : Controller
    {
        [HttpGet("/hello")]
        [ApiVersionUsed("1")]
        public string GetSomething() => "Hello World V1!";
    }
}