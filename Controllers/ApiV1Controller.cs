using Microsoft.AspNetCore.Mvc;

namespace api_versioning.Contollers
{
    public class ApiV1Controller : Controller
    {
        [HttpGet("/hello")]
        [Consumes("application/json", "applicaiton/vnd.unidays.v1+json")]
        public string GetSomething() => "Hello World V1!";
    }
}