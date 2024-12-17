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

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetDetails")]
        public IActionResult GetDetail()
        {
            var result = _userService.GetUserDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetAllByCompany(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("GetLogin")]
        //public IActionResult GetLogin(string mail, string psw)
        //{
        //   var result = _userService.GetLogin(mail, psw);
        //    if (result.Success==true)
        //    {
        //        return Ok(result.Success);
        //    }
        //    return BadRequest(result.Success);
        //}

        [HttpGet("GetUserId")]
        public IActionResult GetUserId(string name, string lastname)
        {
            var result = _userService.GetByName(name, lastname);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Post(Users users) {
            var result = _userService.Add(users);
             if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
