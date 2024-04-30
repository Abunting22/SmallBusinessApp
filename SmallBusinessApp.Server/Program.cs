using System.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;
using SmallBusinessApp.Server.Repositories;
using SmallBusinessApp.Server.Security;
using SmallBusinessApp.Server.Services;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace SmallBusinessApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerServices>();
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config["JwtSettings:Issuer"],
                    ValidAudience = config["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
                x.IncludeErrorDetails = true;

            });
            builder.Services.AddAuthorization();
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
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IAuthentication, Authentication>();
            builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
            builder.Services.AddScoped<Customer>();
            builder.Services.AddScoped<CustomerDto>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
