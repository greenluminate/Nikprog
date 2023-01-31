using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NikprogServerClient.Data;
using NikprogServerClient.Models.SocialTokens;
using NikprogServerClient.Models.UserHandling;
using NikprogServerClient.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NikprogServerClient.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NikprogDbContext _context;
        private readonly UserManager<NikprogUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(NikprogDbContext context, UserManager<NikprogUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<JsonResult> Microsoft([FromBody] SocialToken token)
        {
            //string appid = Environment.GetEnvironmentVariable("NIKPROG_AZURE_APP_ID");

            RestService rest = new RestService("https://graph.microsoft.com");
            var result = rest.GetSingle<MSModel>($"/oidc/userinfo", token.Token);

            NikprogUser user = new NikprogUser
            {
                FirstName = result.GivenName,
                LastName = result.FamilyName,
                Email = result.Email,
                UserName = result.Email,
                LoginMode = LoginMode.microsoft
            };
            return await SocialAuth(user);
        }

        private async Task<JsonResult> SocialAuth(NikprogUser user)
        {
            //not exist? --> create! (REGISTER)
            if (_userManager.Users.FirstOrDefault(t => t.Email == user.Email) == null)
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                }
            }

            //find user (LOGIN)
            var appuser = await _userManager.FindByNameAsync(user.Email);
            if (appuser != null)
            {
                var claim = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub, appuser.Email)
                };

                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }

                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var jwtToken = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  claims: claim.ToArray(),
                  expires: DateTime.Now.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );


                return new JsonResult(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                      expiration = jwtToken.ValidTo
                  });
            }
            return new JsonResult(Unauthorized());
        }
    }
}
