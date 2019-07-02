using Microsoft.AspNetCore.Http;
using System;

namespace Utilities.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        /// <summary>
        /// HttpRequest extension to inspect if the request object contains header with name 
        /// X-Requested-With. THe method detects whether the request header contains X-Requested-With.
        /// </summary>
        /// <param name="request">
        /// HttpRequest object for extension
        /// </param>
        /// <returns>
        /// Boolean on the evaluation of the header againts X-Request-With
        /// </returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("HttpRequest object is null");
            }

            if (request.Headers != null)
            {
                return request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return false;
        }
    }
}