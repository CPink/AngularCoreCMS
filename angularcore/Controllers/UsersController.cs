using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularcore.Data;
using angularcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace angularcore.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly CoreCMSApi _context;

        public UsersController(CoreCMSApi context)
        {
            _context = context;
        }

        //POST api/user/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var username = _context.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (username != null)
            {
                return Json("userExists");
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return Json("User added");
            }
        }

        //POST api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var username = _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (username != null)
            {
                return Json(user.UserName);
            }
            else
            {
                return Json("invalidLogin");
            }
        }
    }
}