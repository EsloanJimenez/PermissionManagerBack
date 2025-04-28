using AutoMapper;
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
    public class PermissionRepository : BaseRepository<Permission, PermissionDTO>, IPermissionRepository
    {
        public PermissionRepository(AppPermissionContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<PermissionDTO>> GetPermission()
        {
            return await _context.Permission
                .Where(p => !p.Deleted)
                .OrderByDescending(p => p.PermissionId)
                .Select(p => new PermissionDTO
                {
                    PermissionId = p.PermissionId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PermissionDate = p.PermissionDate,
                    PermissionTypeId = p.PermissionTypeId,
                    Description = p.PermissionTypeNav.Description,
                }).ToListAsync();
        }

        public async Task<PermissionDTO> GetPermissionId(int id)
        {
            return await _context.Permission
                .Where(p => !p.Deleted && p.PermissionId == id)
                .OrderByDescending(p => p.PermissionId)
                .Select(p => new PermissionDTO
                {
                    PermissionId = p.PermissionId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PermissionDate = p.PermissionDate,
                    PermissionTypeId = p.PermissionTypeId,
                    Description = p.PermissionTypeNav.Description,
                }).FirstOrDefaultAsync();
        }
    }
}
 