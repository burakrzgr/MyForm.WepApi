using Burakrzgr.MyForm.Business.Authentication;
using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Model.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserModal userParam)
        {
            var user = _userService.Authenticate(userParam.UserName, userParam.Password);
            if (user == null)
                return Ok(new ErrorResult<UserModal>(null, "Username or password is incorrect!"));
            return Ok(new SuccessResult<UserModal>(user));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }   
    }
}
