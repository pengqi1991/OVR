using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Common.Extensions
{
    public static class StringExtension
    {

        public static bool IsEmpty(this string text)
        {
            return String.IsNullOrEmpty(text);
        }
    }
}
