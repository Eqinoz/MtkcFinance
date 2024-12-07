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


        [HttpGet("GetAll")]
        public IActionResult Get() { 
            var result = _companyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        

        [HttpPost]
        public IActionResult Post(Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
