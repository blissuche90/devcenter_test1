using System;
using GlobalSetInventory.Data.Common;

namespace DevContact.Domain.Entities
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            
            Id = ShortGuid.NewGuid().ToString();
            CreatedDateTime = DateTime.UtcNow;
            IsDeleted = false;
        }

        public string Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
