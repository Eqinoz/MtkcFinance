using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService= titleService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _titleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Post(Title title)
        {
            var result = _titleService.Add(title);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
