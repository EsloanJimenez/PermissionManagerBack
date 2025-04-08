using PermissionManager.Domain.Core;
using System.Collections.Generic;

namespace PermissionManager.Domain.Entity
{
    public class PermissionType : BaseAuditory
    {
        public PermissionType()
        {
            Permissions = new HashSet<Permission>();
        }
        public int PermissionTypeId { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
