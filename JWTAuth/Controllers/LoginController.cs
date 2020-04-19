using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JWTAuth.Data;
using JWTAuth.Helpers;
using JWTAuth.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PhonebookContext _context;
        private readonly ILoginHelper _loginHelper;

        public LoginController(PhonebookContext context, ILoginHelper loginHelper)
        {
            _context = context;
            _loginHelper = loginHelper;
        }

        [HttpGet("Login")]
        public IActionResult Login(string username, string password)
        {
            UserLogin login = new UserLogin();
            login.Username = username;
            login.Password = password;
            IActionResult response = Unauthorized();
            UserLogin user = null;

            user = _context.Login.Where(a => a.Username == login.Username && a.Password == login.Password).FirstOrDefault();

            if (user != null)
            {
                var tokenStr = _loginHelper.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }
    }
}