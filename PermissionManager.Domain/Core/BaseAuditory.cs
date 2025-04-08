using System;

namespace PermissionManager.Domain.Core
{
    public class BaseAuditory
    {
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
