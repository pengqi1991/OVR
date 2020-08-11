using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Common.Helper
{
    public class HttpHelper
    {
        #region 是否是网址
        public static bool IsUrl(string url)
        {
            url = url.ToLower();
            if (url.StartsWith("http://") || url.StartsWith("https://"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
