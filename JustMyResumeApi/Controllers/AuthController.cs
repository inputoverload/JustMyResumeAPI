using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JustMyResumeApi.Data;
using JustMyResumeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JustMyResumeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JustMyResumeContext _context;

        public AuthController(JustMyResumeContext context)
        {
            _context = context;
        }

        [HttpPost, Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            try
            {
                LoginModel model = _context.LoginModels.Where(
                    item => item.UserName.ToLower().Equals(user.UserName.ToLower()) 
                    && item.Password.Equals(user.Password)).FirstOrDefault();
                if(model != null)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JustMyResumeApi.Models.LoginModel.EncodingKey));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:44396",
                        audience: "http://localhost:4200",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return CreatedAtAction("Login", new { token = tokenString });
                } else
                {
                    return Unauthorized();
                }
            } catch(Exception exc)
            {
                return BadRequest(exc.Message);
            } 
        }
    }
}