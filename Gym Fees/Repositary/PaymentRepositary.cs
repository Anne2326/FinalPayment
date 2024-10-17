using Gym_Fees.Entity;
using Gym_Fees.IRepositary;
using Gym_Fees.Model.ResponseDTO;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.WebSockets;

namespace Gym_Fees.Repositary
{
    public class PaymentRepositary : IPaymentRepositary
    {
        private string _connectionstring;


        public PaymentRepositary(string connectionstring)
        {
            _connectionstring = connectionstring;
        }


        public List<PaymentResponseDTO> GetAllPaymentDetails()
        {

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                string str = "select * from  Payment ";
                command.CommandText = str;

                var payment = new List<PaymentResponseDTO>();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        try
                        {
                            var paymentResponse = new PaymentResponseDTO
                            {
                                PaymentId = reader.GetGuid(reader.GetOrdinal("PaymentId")),
                                MemberId = reader.GetGuid(reader.GetOrdinal("MemberId")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), reader["PaymentMethod"].ToString()),
                                PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                                NextpaymentDate = reader.GetDateTime(reader.GetOrdinal("NextpaymentDate")),
                                PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), reader["PaymentType"].ToString()),
                                PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), reader["PaymentStatus"].ToString())
                            };

                            payment.Add(paymentResponse);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error processing row: {ex.Message}");
                        }
                    }


                    return payment;


                }


            }
        }




        public List<PaymentResponseDTO> GetAllByPaymentId(Guid paymentId)
        {
            var paymentList = new List<PaymentResponseDTO>();

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Payment WHERE PaymentId = @PaymentId", connection))
                {
                    command.Parameters.AddWithValue("@PaymentId", paymentId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                var paymentResponse = new PaymentResponseDTO
                                {
                                    PaymentId = reader.GetGuid(reader.GetOrdinal("PaymentId")),
                                    MemberId = reader.GetGuid(reader.GetOrdinal("MemberId")),
                                    Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                    PaymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), reader["PaymentMethod"].ToString()),
                                    PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                                    NextpaymentDate = reader.GetDateTime(reader.GetOrdinal("NextpaymentDate")),
                                    PaymentType = (PaymentType)Enum.Parse(typeof(PaymentType), reader["PaymentType"].ToString()),
                                    PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), reader["PaymentStatus"].ToString())
                                };

                                paymentList.Add(paymentResponse);
                          
                        }
                    }
                }
            }

            return paymentList;
        }

        public List<PaymentResponseDTO> GetAllByMemberId(Guid MemberId)
        {

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                string str = "select * from  Payment where MemberId=@MemberId";
                command.CommandText = str;
                command.Parameters.AddWithValue("@MemberId", MemberId);
                var payment = new List<PaymentResponseDTO>();
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var paymentResponse = new PaymentResponseDTO
                        {
                            PaymentId = reader.GetGuid(reader.GetOrdinal("PaymentId")),
                            MemberId = reader.GetGuid(reader.GetOrdinal("MemberId")),
                            Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                            PaymentMethod = reader["PaymentMethod"] != DBNull.Value ?
                                (PaymentMethod)Enum.Parse(typeof(PaymentMethod), reader["PaymentMethod"].ToString()) :
                                default(PaymentMethod),
                            PaymentDate = reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
                            NextpaymentDate = reader.GetDateTime(reader.GetOrdinal("NextpaymentDate")),
                            PaymentType = reader["PaymentType"] != DBNull.Value ?
                                (PaymentType)Enum.Parse(typeof(PaymentType), reader["PaymentType"].ToString()) :
                                default(PaymentType),
                            PaymentStatus = reader["PaymentStatus"] != DBNull.Value ?
                                (PaymentStatus)Enum.Parse(typeof(PaymentStatus), reader["PaymentStatus"].ToString()) :
                                default(PaymentStatus)
                        };

                        payment.Add(paymentResponse);



                    }
                    return payment;

                }



            }
            

        }













        public Payment AddPayment(Payment payment)
        {

            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                string str = "INSERT INTO Payment (PaymentId, MemberId, Amount,PaymentMethod ,PaymentStatus,PaymentType, PaymentDate, NextpaymentDate) VALUES (@PaymentId, @MemberId, @Amount,@PaymentMethod,@PaymentStatus, @PaymentType, @PaymentDate, @NextpaymentDate)";

                command.CommandText = str;

                command.Parameters.AddWithValue("@PaymentId", Guid.NewGuid());
                command.Parameters.AddWithValue("@MemberId", payment.MemberId);
                command.Parameters.AddWithValue("@Amount", payment.Amount);
                command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod.ToString());
                command.Parameters.AddWithValue("@PaymentType", payment.PaymentType.ToString());
                command.Parameters.AddWithValue("@PaymentStatus", payment.PaymentStatus.ToString());
                command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                command.Parameters.AddWithValue("@NextpaymentDate", payment.NextpaymentDate);

                command.ExecuteNonQuery();
            }


            return payment;
        }



       



























    }
}
