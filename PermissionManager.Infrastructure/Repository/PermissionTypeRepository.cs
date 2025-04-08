using Microsoft.EntityFrameworkCore;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;
using PermissionManager.Domain.Interface.Repository;
using PermissionManager.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Repository
{
    public class PermissionTypeRepository : BaseRepository<PermissionType>, IpermissionTypeRepository
    {
        public PermissionTypeRepository(AppPermissionContext context) : base(context)
        {
        }

        public async Task<List<PermissionTypeDTO>> GetPermissionType()
        {
            return await _context.PermissionType
                .Where(pt => !pt.Deleted)
                .OrderByDescending(pt => pt.PermissionTypeId)
                .Select(pt => new PermissionTypeDTO
                {
                    PermissionTypeId = pt.PermissionTypeId,
                    Description = pt.Description,
                }).ToListAsync();
        }

        public async Task<PermissionTypeDTO> GetPermissionTypeId(int id)
        {
            return await _context.PermissionType
                .Where(pt => !pt.Deleted)
                .OrderByDescending(pt => pt.PermissionTypeId)
                .Select(pt => new PermissionTypeDTO
                {
                    PermissionTypeId = pt.PermissionTypeId,
                    Description = pt.Description,
                }).FirstOrDefaultAsync();
        }
    }
}
