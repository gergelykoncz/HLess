using System;

namespace HLess.Models.Entities.Base
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
    }
}
