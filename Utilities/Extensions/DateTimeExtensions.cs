using System;

namespace Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a string that can be used by JS to create a date object.
        /// </summary>
        /// <param name="dateTime"></param>
        /// 
        /// Tested in
        /// WINDOWS :
        ///     - Chrome
        ///     - IE
        ///     - Edge
        ///     - FireFox
        /// OSX :
        ///     - Safari
        ///     - Chrome
        ///     - FireFox
        public static string ToStringInJavaScriptFormat(this DateTime dateTime)
        {
            return dateTime.ToString("s");
        }
    }
}