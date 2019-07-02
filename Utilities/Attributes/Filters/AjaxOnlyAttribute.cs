using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;
using Utilities.Extensions;

namespace Utilities.Attributes.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        /// <summary>
        /// Returns true if the method is invoked via an ajax call
        /// </summary>
        /// <param name="routeContext">CORE Route Context</param>
        /// <param name="action">Action method descriptor</param>
        /// <returns>True if the method is invoked via an ajax call</returns>        
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            return routeContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}