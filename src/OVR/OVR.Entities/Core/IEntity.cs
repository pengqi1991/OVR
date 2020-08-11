using System;
using System.Collections.Generic;
using System.Text;

namespace OVR.Entities.Core
{
    //没有Id主键的实体继承这个
    public interface IEntity
    {
    }
    //有Id主键的实体继承这个
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

    }
}
