using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElhawaryApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(UserManager<IdentityUser> userManager, ITokenService tokenService) : Controller
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(SignupDTO data)
        {
            var user = new IdentityUser()
            {
                Email = data.Email,
                UserName = data.Email[..data.Email.IndexOf('@')],
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                if (data.Roles != null)
                {
                    result = await _userManager.AddToRolesAsync(user, data.Roles);
                    if (result.Succeeded)
                    {
                        return Ok("user created successfuly");
                    }
                }
            }
            return BadRequest("Failed to create user");
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> Signin(SigninDTO data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user != null)
            {
                bool passMatch = await _userManager.CheckPasswordAsync(user, data.Password);
                if (passMatch)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var token = _tokenService.CreateToken(user, [.. roles]);
                        return Ok(token);
                    }
                }
            }
            return BadRequest("wrong email or password");
        }
    }
}
