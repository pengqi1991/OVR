using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace OVR.Model
{
    [Table("SysUserBelong")]
    public class UserBelongEntity 
    {

        public int Id { get; set; }
        public int? UserId { get; set; }
       
        public int? BelongId { get; set; }
        public int? BelongType { get; set; }

        /// <summary>
        /// 多个用户Id
        /// </summary>
        [NotMapped]
        public string UserIds { get; set; }
    }
}
