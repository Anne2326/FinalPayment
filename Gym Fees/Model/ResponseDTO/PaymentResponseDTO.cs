﻿using Gym_Fees.Entity;

namespace Gym_Fees.Model.ResponseDTO
{
    public class PaymentResponseDTO
    {
        public Guid PaymentId { get; set; }
        public Guid MemberId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
       public DateTime PaymentDate { get; set; }
        public DateTime NextpaymentDate { get; set; }
    }
}
