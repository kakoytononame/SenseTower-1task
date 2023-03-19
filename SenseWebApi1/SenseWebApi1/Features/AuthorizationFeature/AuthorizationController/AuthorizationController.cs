using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SC.Internship.Common.Exceptions;

namespace SenseWebApi1.Features.AuthorizationFeature.AuthorizationController
{
    [ApiController]
    public class AuthorizationController:ControllerBase
    {

        private static readonly HttpClient Client = new HttpClient();
        /// <summary>
        /// Запрос авторизации
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Пример входных данных:
        ///
        ///     POST /stub/authstub
        ///     {
        ///        "login": "admin",Тип данных:string
        ///        "password": "12345",Тип данных:string
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Возвращает id добавленного события </response>
        /// <response code="401">Возвращает unauthorized </response>
        /// <response code="500">Ошибка сервера </response>
        [HttpPost("stub/authstub")]
        public async Task<IActionResult> LogIn(string login,string password)
        {
            var value = new
            {
                login = login,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://identityserver0:3000/stub/authstub", content);
            var response = await Client.PostAsync("http://localhost:5006/stub/authstub", content);
            var responseString = await response.Content.ReadAsStringAsync();
            ControllerContext.HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", responseString, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(60),
                SameSite = SameSiteMode.Strict,
                Secure = false,
            });
            if (response.StatusCode==System.Net.HttpStatusCode.Unauthorized)
            {
                throw new ScException("Не верный логин или пароль");
            }
            return Ok(response);
        }
    }
}
