using Microsoft.Data.SqlClient;

namespace Gym_Fees.Database
{
    public class DatabaseInitialize
    {
        private readonly string _connectionstring;

        public DatabaseInitialize(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void Initialize()
        {

            using (var connection = new SqlConnection(_connectionstring))
            {


                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name='Payment')

CREATE TABLE Payment(
  PaymentId UNIQUEIDENTIFIER PRIMARY KEY,
MemberId  UNIQUEIDENTIFIER NOT NULL,
Amount DECIMAL (15,2) NOT NULL,
Paymentmethod NVARCHAR(45) NOT NULL,


PaymentType NVARCHAR(45) NOT NULL,
PaymentStatus  NVARCHAR(45),
PaymentDate DATE NOT NULL,
NextpaymentDate DATE NOT NULL
)";


//please add here Payment status,Payment type to not null

                command.ExecuteNonQuery();

















            }




        }










    }
}
