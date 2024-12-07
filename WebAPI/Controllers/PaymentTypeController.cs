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

        [HttpGet]
        public IActionResult Get()
        {
            var result = _paymentTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetByName")]
        public IActionResult Get(string name)
        {
            var result = _paymentTypeService.GetById(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
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
