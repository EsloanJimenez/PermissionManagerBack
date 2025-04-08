using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeService _permissionTypeService;
        private readonly IMapper _mapper;
        public PermissionTypeController(IPermissionTypeService permissionTypeService, IMapper mapper)
        {
            _permissionTypeService = permissionTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permissionType = await _permissionTypeService.GetAll();
                var permissionTypeDTO = _mapper.Map<IEnumerable<PermissionTypeDTO>>(permissionType);

                return Ok(permissionTypeDTO);
            } catch (ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
