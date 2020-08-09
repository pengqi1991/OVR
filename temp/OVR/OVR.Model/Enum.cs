using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OVR.Model
{
    public enum StatusEnum
    {
        [Description("启用")]
        Yes = 1,

        [Description("禁用")]
        No = 0
    }

    public enum AuthorizeTypeEnum
    {
        [Description("角色")]
        Role = 1,

        [Description("用户")]
        User = 2,
    }
}
