using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPI.Core.Application.Dtos.Account;
using PruebaTecnicaAPI.Core.Application.Enums;
using PruebaTecnicaAPI.Core.Application.Interfaces.Services;

namespace PruebaTecnicaAPI_SuperIntendenciaDeBancos.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userService = userService;
            _roleManager = roleManager;
            _mapper = mapper;
        }


        //[ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                AuthenticationResponse response = await _userService.LoginAsync(dto);
                
                if (response != null && !response.HasError)
                {
                    if (response.Roles.Contains(Roles.Admin.ToString()))
                    {
                        return NoContent();
                    }
                    else if (response.Roles.Contains(Roles.Basic.ToString()))
                    {
                        return NoContent();
                    }

                    return NoContent();
                }
                else
                {
                    dto.HasError = response.HasError;
                    dto.Error = response.Error;
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _userService.SignOutAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
