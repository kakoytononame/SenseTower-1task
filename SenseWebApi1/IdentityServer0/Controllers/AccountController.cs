using IdentityServer0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace IdentityServer0.Controllers
{
    public class AccountController:Controller
    {
        // тестовые данные вместо использования базы данных
        private List<Person> people = new List<Person>
        {
            new Person {Login="admin", Password="12345" },
            new Person { Login="user", Password="55555"}
        };

        [HttpPost("stub/authstub")]
        public IActionResult Token([FromBody]LoginDto loginDto)
        {


            var identity = GetIdentity(loginDto.Login, loginDto.Password);
            if (identity == null)
            {
                return Unauthorized();
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            

            return Ok(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login)         
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
        public class LoginDto
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}

