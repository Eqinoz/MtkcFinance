using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _paymentTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("getid")]
        public IActionResult Get(string name)
        {
            var result = _paymentTypeService.GetById(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Post(PaymentType paymentType)
        {
            var result = _paymentTypeService.Add(paymentType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
