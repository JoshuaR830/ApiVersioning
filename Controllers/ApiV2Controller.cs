using Microsoft.AspNetCore.Mvc;

namespace api_versioning.Contollers
{
    public class ApiV2Controller : Controller
    {
        [HttpGet("/hello")]
        [Consumes("application/json", "applicaiton/vnd.unidays.v2+json")]
        public string GetSomething() => "Hello World V2!";
    
    
    
        [HttpGet("/hello")]
        [Consumes("application/json", "applicaiton/vnd.unidays.v3+json")]
        public string GetSomethingElse() => "Hello World V3!";
    }
}