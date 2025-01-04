using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IAuthService _authService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getdetails")]
        public IActionResult GetDetail()
        {
            var result = _userService.GetUserDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycompanyid")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetAllByCompany(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        

        [HttpGet("getuserid")]
        public IActionResult GetUserId(string name, string lastname)
        {
            var result = _userService.GetByName(name);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("add")]
        public IActionResult Post(Users users) {
            var result = _userService.Add(users);
             if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("del")]
        public IActionResult Delete(int id)
        {
            var result = _userService.Deleted(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
