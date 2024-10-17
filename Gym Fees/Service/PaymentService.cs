using Gym_Fees.Entity;
using Gym_Fees.IRepositary;
using Gym_Fees.IService;
using Gym_Fees.Model.RequestDTO;
using Gym_Fees.Model.ResponseDTO;

namespace Gym_Fees.Service
{
    public class PaymentService: IPaymentService
    {

        private readonly IPaymentRepositary _paymentRepositary;

 public PaymentService(IPaymentRepositary paymentRepositary)
        {
            _paymentRepositary = paymentRepositary;
        }


        public List<PaymentResponseDTO>GetAllPaymentDetails()
        {
            var data = _paymentRepositary.GetAllPaymentDetails();
            var list = new List<PaymentResponseDTO>();
            foreach (var item in data)
            {
                var paymentRequestDTO = new PaymentResponseDTO()
                {

                    MemberId = item.MemberId,
                    PaymentId = item.PaymentId,
                    Amount = item.Amount,
                    PaymentDate = item.PaymentDate,
                    NextpaymentDate = item.NextpaymentDate,
                    PaymentMethod = item.PaymentMethod,
                    PaymentStatus = item.PaymentStatus,
                    PaymentType = item.PaymentType






                };

                list.Add(paymentRequestDTO);

            }


            return list;



        }








        public List<PaymentResponseDTO> GetAllByPaymentId(Guid Paymentid)
        {
            var data = _paymentRepositary.GetAllByPaymentId(Paymentid);
            var list = new List<PaymentResponseDTO>();
            foreach (var item in data)
            {
                var paymentRequestDTO = new PaymentResponseDTO()
                {

                    MemberId = item.MemberId,
                    
                    Amount = item.Amount,
                    PaymentId=item.PaymentId,   
                   PaymentDate = item.PaymentDate,
                    NextpaymentDate = item.NextpaymentDate,
                   PaymentMethod = item.PaymentMethod,
                    PaymentStatus = item.PaymentStatus,
                    PaymentType = item.PaymentType






                };

                list.Add(paymentRequestDTO);

            }


            return list;



        }

        public List<PaymentResponseDTO> GetAllByMemberId(Guid MemberId)
        {
            var data = _paymentRepositary.GetAllByMemberId(MemberId);
            var list = new List<PaymentResponseDTO>();
            foreach (var item in data)
            {
                var paymentRequestDTO = new PaymentResponseDTO()
                {
                    PaymentId = item.PaymentId,
                    MemberId = item.MemberId,
                    PaymentMethod = item.PaymentMethod,
                    Amount = item.Amount,
                    PaymentDate = item.PaymentDate,
                    NextpaymentDate = item.NextpaymentDate,
                    PaymentStatus = item.PaymentStatus,
                    PaymentType = item.PaymentType





                                  

                };
                list.Add(paymentRequestDTO );


            }


            return list;



        }





        public PaymentResponseDTO AddPayment(PaymentRequestDTO payment)
        {
            var item = new Payment()
            {
                MemberId= payment.MemberId,
                Amount= payment.Amount,
              PaymentMethod= payment.PaymentMethod,
                PaymentType = payment.PaymentType,
              PaymentDate = DateTime.Now,
              NextpaymentDate = DateTime.Now.AddMonths(1)
              
              
            };

            var data = _paymentRepositary.AddPayment(item);
             DateTime currentDate= DateTime.Now;

            var paymentResponseDTO = new PaymentResponseDTO()
            {
                Amount = data.Amount,
                MemberId = data.MemberId,
               PaymentStatus= data.PaymentStatus,
               PaymentType= data.PaymentType,
               PaymentMethod= data.PaymentMethod,
                PaymentDate = currentDate,
                NextpaymentDate = currentDate.AddMonths(1)
                


            };
            return paymentResponseDTO;


        }



        //public PaymentResponseDTO GetAllPendingDetails(Payment payment)
        //{
        //    var item = new Payment()
        //    {
        //        MemberId = payment.MemberId,
        //        Amount = payment.Amount,
        //        PaymentMethod = payment.PaymentMethod,
        //        PaymentType = payment.PaymentType,
        //        PaymentDate = DateTime.Now,
        //        NextpaymentDate = DateTime.Now.AddMonths(1)

                
        //    };

        //    var data = _paymentRepositary.AddPayment(item);
        //    DateTime currentDate = DateTime.Now;

        //    var paymentResponseDTO = new PaymentResponseDTO()
        //    {
        //        Amount = data.Amount,
        //        MemberId = data.MemberId,
        //        PaymentStatus = data.PaymentStatus,
        //        PaymentType = data.PaymentType,
        //        PaymentMethod = data.PaymentMethod,
        //        PaymentDate = currentDate,
        //        NextpaymentDate = currentDate.AddMonths(1)


        //    };
        //    return paymentResponseDTO;


        //}

















    }
}
