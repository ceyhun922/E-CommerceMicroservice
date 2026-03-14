using System.Threading.Tasks;
using ItemShop.IdentityServer.DTOs.RegisterDtos;
using ItemShop.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace ItemShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [ApiController]
    [Route("api/[controller]")]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto dto)
        {
            var user =new ApplicationUser(){
                UserName =dto.Username,
                Email =dto.Email,
                Name =dto.Name,
                Surname =dto.Surname
            };

            var result =await _userManager.CreateAsync(user,dto.Password);
            if (result.Succeeded)
            {
                return Ok("new user registred");
            }else
            {
                       return BadRequest(result.Errors);

            }
        }
    }
}