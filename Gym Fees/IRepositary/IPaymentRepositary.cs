using Gym_Fees.Entity;
using Gym_Fees.Model.ResponseDTO;

namespace Gym_Fees.IRepositary
{
    public interface IPaymentRepositary
    {


        List<PaymentResponseDTO> GetAllPaymentDetails();
        List<PaymentResponseDTO> GetAllByPaymentId(Guid PaymentId);
        List<PaymentResponseDTO> GetAllByMemberId(Guid MemberId);

        Payment AddPayment(Payment payment);




    }



}

