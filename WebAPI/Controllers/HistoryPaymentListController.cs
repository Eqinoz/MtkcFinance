using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryPaymentListController : ControllerBase
    {
         IHistoryPaymentListService _historyPaymentListService;
         IUserService _userService;
         ICompanyService _companyService;
         IPaymentTypeService _paymentTypeService;
         IPaymentListService _paymentListService;

        public HistoryPaymentListController(IHistoryPaymentListService historyPaymentListService,
            IUserService userService,
            ICompanyService companyService,
            IPaymentTypeService paymentTypeService,
            IPaymentListService paymentListService)
        {
            _historyPaymentListService = historyPaymentListService;
            _userService = userService;
            _companyService = companyService;
            _paymentTypeService = paymentTypeService;
            _paymentListService = paymentListService;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result= _historyPaymentListService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Post(HistoryPaymentListDetailDto historyPaymentListDetailDto)
        {
            int UserId = _userService.GetByName(historyPaymentListDetailDto.UserName).Data.Id;
            int CompanyId = _companyService.GetById(historyPaymentListDetailDto.CompanyName).Data.Id;
            int PaymentTypeId = _paymentTypeService.GetById(historyPaymentListDetailDto.PaymentType).Data.Id;

            HistoryPaymentList historyPaymentList = new HistoryPaymentList();
            historyPaymentList.UsersId = UserId;
            historyPaymentList.DateAdded = historyPaymentListDetailDto.DateAdded;
            historyPaymentList.DatePaid=historyPaymentListDetailDto.DatePaid;
            historyPaymentList.CompanyId = CompanyId;
            historyPaymentList.PaymentTypeId = PaymentTypeId;
            historyPaymentList.Description = historyPaymentListDetailDto.Description;
            historyPaymentList.PlaceOfPayment = historyPaymentListDetailDto.PaymentOfPlace;
            historyPaymentList.Price = historyPaymentListDetailDto.Price;
            var result = _historyPaymentListService.Add(historyPaymentList);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
