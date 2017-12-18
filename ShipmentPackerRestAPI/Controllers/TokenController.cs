using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShipmentPackerBLL;
using ShipmentPackerBLL.BusinessObjects;

namespace ShipmentPackerRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("/api/token")]
    public class TokenController : Controller
    {
        BLLFacade _facade;
        public TokenController()
        {
            _facade = new BLLFacade();
        }

        [HttpPost]
        public IActionResult Create(string WorkEmail, string password)
        {
            var user = IsValidUserAndPasswordCombination(WorkEmail, password);
            if (user != null && !string.IsNullOrEmpty(WorkEmail))
            {
                var token = GenerateToken(user);
                return new ObjectResult(token);
            }
            return StatusCode(401, "Invalid E-Mail / Password combination.");
        }

        private UserBO IsValidUserAndPasswordCombination(string WorkEmail, string password)
        {
            List<UserBO> list = _facade.UserService.GetAll();
            var userFound = list.FirstOrDefault(u => u.WorkEmail == WorkEmail && u.Password == password);
            return userFound;
        }

        private IActionResult GenerateToken(UserBO user)
        {
            var claims = new List<Claim>
            {
                new Claim("workEmail", user.WorkEmail),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            switch (user.WorkTitle)
            {
                case "Workshop":
                    claims.Add(new Claim("workTitle", "Workshop"));
                    break;
                case "Office":
                    claims.Add(new Claim("workTitle", "Office"));
                    break;
                case "Admin":
                    claims.Add(new Claim("workTitle", "Admin"));
                    break;
                default:
                    break;

            }


            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("NoTMyPRObl3mSup£rF4ncyKey")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}