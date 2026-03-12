using System.Threading.Tasks;
using ItemShop.IdentityServer.DTOs.RegisterDtos;
using ItemShop.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ItemShop.IdentityServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

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
                return Ok("Error");
            }
        }
    }
}