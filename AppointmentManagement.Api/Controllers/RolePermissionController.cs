using AppointmentManagement.Api.Authorization;
using AppointmentManagement.Application.Interfaces.RolePermissions;
using AppointmentManagement.Application.Interfaces.RolePermissions.DTOs;
using AppointmentManagement.Domain.Authorization;
using AppointmentManagement.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController(IRolePermissionService _service) : ControllerBase
    {
        [HttpGet()]
        [PanelPermission(PanelPermissionEnum.ViewRolePermissions)]
        public async Task<IActionResult> GetByRole(RoleType role)
        {
            var result = await _service.GetByRole(role);
            return Ok(result);
        }
        [HttpPut()]
        [PanelPermission(PanelPermissionEnum.UpdateRolePermission)]
        public async Task<IActionResult> Modify(List<ModifyRolePermissionDTO> items)
        {
            await _service.Modify(items);
            return Ok();
        }
    }
}
