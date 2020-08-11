using OVR.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OVR.Entities
{
    public class UserLogin : BaseEntity
    {

        public string Account { get; set; }
        public string Password { get; set; }

        public bool isSuperAdmin { get; set; } = false;

    }
}
