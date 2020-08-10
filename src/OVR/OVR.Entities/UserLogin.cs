using OVR.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OVR.Entities
{
    public class UserLogin : IEntity
    {
        public long UserId { get; set; }

        [Key]
        public string Account { get; set; }
        public string HashedPassword { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedTime { get; set; }

        public User User { get; set; }
    }
}
