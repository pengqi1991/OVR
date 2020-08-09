using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OVR.Model.Auth
{
    [Table("SysMenuAuthorize")]
    public class MenuAuthorizeEntity
    {
        
        public int? MenuId { get; set; }

        
        public int? AuthorizeId { get; set; }

        public int? AuthorizeType { get; set; }

        [NotMapped]
        public string AuthorizeIds { get; set; }
    }
}
