using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanysController : ControllerBase
    {
        ICompanyService _companyService;


        public CompanysController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet("GetAll")]
        public IActionResult Get() { 
            var result = _companyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetId(int id)
        {
            var result = _companyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
