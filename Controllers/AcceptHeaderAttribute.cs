using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace api_versioning.Controllers {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ApiVersionAttribute : Attribute, IActionConstraint {

        public ApiVersionAttribute(string attribute) {
            if(attribute == null)
                throw new ArgumentNullException(nameof(attribute));

            MediaTypeHeaderValue.Parse(attribute);
        }

        public int Order 
        {
            get
            {
                return 0;
            }
        }

        // Returns true if valid for selection
        public bool Accept(ActionConstraintContext context)
        {
            throw new NotImplementedException();
        }
    }
}