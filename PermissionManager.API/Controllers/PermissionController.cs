using Microsoft.AspNetCore.Mvc;
using PermissionManager.Domain.DTO;
using PermissionManager.Domain.Interface.Service;
using System;
using System.Threading.Tasks;

namespace PermissionManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var permissions = await _permissionService.GetAll();

<<<<<<< HEAD
                return Ok(permission);
            }catch(ArgumentException ex)
=======
                return Ok(permissions);
            }
            catch (ArgumentException ex)
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
            {
                return BadRequest(new { messge = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO is null)
                    return BadRequest("La entidad no puede ser nula.");

<<<<<<< HEAD
                await _permissionService.CreatePermision(permissionDTO);

                return Ok();
=======
                permissionDTO = await _permissionService.Add(permissionDTO);

                return Ok(permissionDTO);
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
            }
            catch (ArgumentException)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO is null)
                    return BadRequest("La entidad no puede ser nula.");

<<<<<<< HEAD
                await _permissionService.UpdatePermision(permissionDTO);

                return Ok();
=======
                await _permissionService.Update(permissionDTO);

                return NoContent();
>>>>>>> 0da53cd66c5081af1b4d436208626e79c4d0f748
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Permission permission)
        {
            try
            {
                await _permissionService.Remove(permission);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
