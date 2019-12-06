using System;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace api_versioning.Controllers {
    /// <summary>
    /// Compare the request header to the type of the api
    /// Functions only called when the version on the header matches the version that is specified on the attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApiVersionUsedAttribute : Attribute, IActionConstraint
    {
        public string RequiredApiVersion { get; set; }

        public ApiVersionUsedAttribute(string apiVersion = "1")
        {            
                RequiredApiVersion = $"application/vnd.unidays.v{apiVersion}+json";
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            // Unsure of what the implication of this returning true is if no header?
            var requestedApiVersion = context.RouteContext.HttpContext.Request.Headers[HeaderNames.Accept];
            return requestedApiVersion == RequiredApiVersion;
        }
    }
}