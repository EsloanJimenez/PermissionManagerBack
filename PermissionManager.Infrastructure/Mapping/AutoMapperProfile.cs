using AutoMapper;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Entity;

namespace PermissionManager.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region "PERMISSION"
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();
            #endregion

            #region " PERMISSION TYPE"
            CreateMap<PermissionTypeDTO, PermissionType>();
            CreateMap<PermissionType, PermissionTypeDTO>();
            #endregion
        }
    }
}
