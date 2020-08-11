using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OVR.Entities
{
    public class SysMenu
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }

        public string MenuName { get; set; }

        public string MenuIcon { get; set; }

        public string MenuUrl { get; set; }

        public int? MenuSort { get; set; }

        public int? MenuType { get; set; }


        [NotMapped]
        public string ParentName { get; set; }
    }
}
