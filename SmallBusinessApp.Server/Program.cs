using SmallBusinessApp.Server.Repositories;
using SmallBusinessApp.Server.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;
using SmallBusinessApp.Server.Model;
using SmallBusinessApp.Server.Services;

namespace SmallBusinessApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDbConnection>(provider =>
            {
                string connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");

                return new SqlConnection(connectionString);
            });

            builder.Services.AddScoped<IBaseRepository, BaseRepository>();
            builder.Services.AddScoped(typeof(IPrimaryRepository<>), typeof(PrimaryRepository<>));
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<Customer>();
            builder.Services.AddScoped<Product>();
            builder.Services.AddScoped<Appointment>();
            builder.Services.AddScoped<Payment>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
