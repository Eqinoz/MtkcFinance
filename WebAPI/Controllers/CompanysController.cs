using Business.Abstract;
using Entities.Concrete;
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


        [HttpGet("getall")]
        public IActionResult Get() { 
            var result = _companyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        

        [HttpPost("add")]
        public IActionResult Post(Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("deleted")]
        public IActionResult Deleted(int id)
        {
            var result = _companyService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
