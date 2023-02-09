using e_commerceBackEnd.Configurations;
using e_commerceBackEnd.Model;
using e_commerceBackEnd.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_commerceBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
       // private readonly JwtConfig _jwtConfig;
       private readonly IConfiguration _configuration;

        public AuthenticationController(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
           
            _configuration = configuration;
        }

        [HttpPost]
        [Route(template:"Register")]

        public async Task<IActionResult> Register([FromBody] UserRegistrationDto request)
        {
            try
            {
                //validate the incomming request
                if (ModelState.IsValid)
                {
                    //we need to  check the email is already exist in the database
                    var user_exist = await _userManager.FindByEmailAsync(request.Email);

                    if (user_exist != null)
                    {
                        return BadRequest(error: new AuthRusult
                        {
                            Result = false,
                            Error = new List<string>()
                        {
                            "Email already Exist"

                        }



                        });
                    }

                    //create a user

                    var new_user = new IdentityUser();
                    {
                        new_user.Email = request.Email;
                        new_user.UserName = request.Email;
                        
                    }

                    var is_created = await _userManager.CreateAsync(new_user, request.Password);
                    Console.Write(is_created.ToString());
                    if (is_created.Succeeded)
                    {
                        var tokenString = GenerateJwtToken(new_user);
                        return Ok(new AuthRusult()
                        {
                            Result = true,
                            Token = tokenString,
                        });

                    }
                    else
                    {

                        //faild to response
                        return BadRequest(error: new AuthRusult
                        {
                            Result = false,
                            Error = new List<string>()
                        {
                            "Password must Contains Uppercase, Digit and symbol"

                        }



                        });

                    }




                }
                return BadRequest();

            }
            catch(Exception ex)
            {
                return Ok(ex);

            }
           
        }

        [HttpPost]
        [Route(template:"Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);
                    if (existing_user == null)
                    {
                        return BadRequest(error: new AuthRusult()
                        {
                            Error = new List<string>()
                        {
                            "User not found"
                        }
                        });
                    }
                    var isCorrect = await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);
                    if (!isCorrect)
                    {
                        return BadRequest(error: new AuthRusult()
                        {
                            Error = new List<string>()
                {
                    "Invalid Credentials"
                },
                            Result = false

                        });
                    }
                    var jwtToken = GenerateJwtToken(user: existing_user);
                    return Ok(new AuthRusult()
                    {
                        Token = jwtToken,
                        Result = true,

                    });

                }
                return BadRequest(error: new AuthRusult()
                {
                    Error = new List<string>()
                {
                    "please input all fields"
                },
                    Result = false

                });

            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
            
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key= Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

            //Token descriptor

            var tokenDescrptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(type: "id", value: user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, value: user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, value: user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, value: DateTime.Now.ToUniversalTime().ToString()),
                }),
                Expires = DateTime.Now.AddHours(1),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256)
        };

            
            var token = jwtTokenHandler.CreateToken(tokenDescrptor);
            return  jwtTokenHandler.WriteToken(token);

           
            
        }

    }
}
