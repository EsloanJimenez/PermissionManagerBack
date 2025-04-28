using Microsoft.AspNetCore.Mvc;
using PermissionManager.Domain.Interface.Service;
using System;
using System.Threading.Tasks;

namespace PermissionManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeService _permissionTypeService;
        public PermissionTypeController(IPermissionTypeService permissionTypeService)
        {
            _permissionTypeService = permissionTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permissionTypes = await _permissionTypeService.GetAll();
                return Ok(permissionTypes);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
