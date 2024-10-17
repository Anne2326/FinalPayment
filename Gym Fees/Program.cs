
using Gym_Fees.Database;
using Gym_Fees.IRepositary;
using Gym_Fees.IService;
using Gym_Fees.Repositary;
using Gym_Fees.Service;

namespace Gym_Fees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");





            
            builder.Services.AddSingleton<IPaymentRepositary>(provider => new PaymentRepositary(connectionString));
            builder.Services.AddSingleton<IPaymentService>(provider => new PaymentService(provider.GetRequiredService<IPaymentRepositary>()));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Disable camelCase if needed
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()); // Enable string enum conversion
    });



            var app = builder.Build();
            var DatabaseInitialize = new DatabaseInitialize(connectionString);
            DatabaseInitialize.Initialize();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
