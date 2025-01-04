using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentListController : ControllerBase
    {
        IPaymentListService _paymentListService;
        IUserService _userService;
        ICompanyService _companyService;
        IPaymentTypeService _paymentTypeService;

        public PaymentListController(IPaymentListService paymentListService, IUserService userService,
            ICompanyService companyService,
            IPaymentTypeService paymentTypeService
        )
        {
            _paymentListService = paymentListService;
            _userService = userService;
            _companyService = companyService;
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _paymentListService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Post(PaymentListDetailDto paymentListDetail)
        {
            int UserId = _userService.GetByName(paymentListDetail.UserName).Data.Id;
            int CompanyId = _companyService.GetById(paymentListDetail.CompanyName).Data.Id;
            int PaymentTypeId = _paymentTypeService.GetById(paymentListDetail.PaymentType).Data.Id;
            PaymentList paymentList = new PaymentList();
            paymentList.UsersId = UserId;
            paymentList.DateAdded = DateTime.Now;
            paymentList.CompanyId = CompanyId;
            paymentList.PaymentTypeId = PaymentTypeId;
            paymentList.Description= paymentListDetail.Description;
            paymentList.PlaceOfPayment = paymentListDetail.PaymentOfPlace;
            paymentList.Price= paymentListDetail.Price;

            var result = _paymentListService.Add(paymentList);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("deleted")]
        public IActionResult Delete(int id)
        {
            var result = _paymentListService.Deleted(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }
    }
}
