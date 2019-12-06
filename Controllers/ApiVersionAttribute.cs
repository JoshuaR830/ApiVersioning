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

        public MediaType ApiVersionRequired { get; set; }

        public ApiVersionUsedAttribute(string apiVersion = "1")
        {            
                var apiVersionRequired = $"application/vnd.unidays.v{apiVersion}+json";
                ApiVersionRequired = new MediaType(apiVersionRequired);
        }

        public int Order => 0;

        private bool IsRequestedApiSubsetOfRequiredApi(string requestedApi)
        {
            var parsedRequestedApi = new MediaType(requestedApi);
            return parsedRequestedApi.IsSubsetOf(ApiVersionRequired);
        }

        public bool Accept(ActionConstraintContext context)
        {
            // Unsure of what the implication of this returning true is - it accepts if no header?
            var requestedApiOnAccept = context.RouteContext.HttpContext.Request.Headers[HeaderNames.Accept];
            return StringValues.IsNullOrEmpty(requestedApiOnAccept) || IsRequestedApiSubsetOfRequiredApi(requestedApiOnAccept);
        }
    }
}