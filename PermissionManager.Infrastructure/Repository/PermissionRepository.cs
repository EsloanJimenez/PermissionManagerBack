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
                .Join(_context.PermissionType,
                    per => per.PermissionTypeId,
                    perTy => perTy.PermissionTypeId,
                    (per, perTy) => new {per = per, perTy = perTy})
                .OrderByDescending(p => p.per.PermissionId)
                .Select(p => new PermissionDTO
                {
                    PermissionId = p.per.PermissionId,
                    FirstName = p.per.FirstName,
                    LastName = p.per.LastName,
                    PermissionDate = p.per.PermissionDate,
                    PermissionTypeId = p.per.PermissionTypeId,
                    Description = p.perTy.Description
                }).ToListAsync();
        }

        public async Task<PermissionDTO> GetPermissionId(int id)
        {
            return await _context.Permission
                .Where(p => !p.Deleted && p.PermissionId == id)
                .Join(_context.PermissionType,
                    per => per.PermissionTypeId,
                    perTy => perTy.PermissionTypeId,
                    (per, perTy) => new { per = per, perTy = perTy })
                .OrderByDescending(p => p.per.PermissionId)
                .Select(p => new PermissionDTO
                {
                    PermissionId = p.per.PermissionId,
                    FirstName = p.per.FirstName,
                    LastName = p.per.LastName,
                    PermissionDate = p.per.PermissionDate,
                    PermissionTypeId = p.per.PermissionTypeId,
                    Description = p.perTy.Description
                }).FirstOrDefaultAsync();
        }
    }
}
