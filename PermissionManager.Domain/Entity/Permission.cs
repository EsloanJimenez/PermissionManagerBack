using PermissionManager.Domain.Core;
using System;

namespace PermissionManager.Domain.Entity
{
    public class Permission : BaseAuditory
    {
        public int PermissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }

        public virtual PermissionType PermissionTypeNav { get; set; }
    }
}
