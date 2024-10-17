using Gym_Fees.Entity;
using Gym_Fees.IService;
using Gym_Fees.Model.RequestDTO;
using Gym_Fees.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym_Fees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {


            _paymentService = paymentService;
        }


        [HttpGet(" GetAllPaymentDetails")]
        public IActionResult GetAllPaymentDetails()
        {
            try
            {
                var data = _paymentService.GetAllPaymentDetails();
                return Ok(data);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }



        }



        [HttpGet(" GetAllByPaymentId")]
        public IActionResult GetAllByPaymentId(Guid PaymentId)
        {
            try
            {
                var data = _paymentService.GetAllByPaymentId(PaymentId);
                return Ok(data);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }



        }

        [HttpGet(" GetAllByMemberId")]
        public IActionResult GetAllByMemberId(Guid MemberId)
        {
            try
            {
                var data = _paymentService.GetAllByMemberId(MemberId);
                return Ok(data);
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }



        }



        [HttpPost(" AddPayment")]
        public IActionResult AddPayment(PaymentRequestDTO payment)
        {
            //try
            //{
            //    var data = _paymentService.AddPayment(payment);
            //    return Ok(data);
            //}

            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);

            //}
            if (!Enum.IsDefined(typeof(PaymentMethod), payment.PaymentMethod))
            {
                return BadRequest("Invalid enum value.");
            }

            var paymentId = _paymentService.AddPayment(payment);
           
            return Ok(paymentId);



        }
















    }
}
