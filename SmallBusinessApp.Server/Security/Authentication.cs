using Microsoft.AspNetCore.Mvc;

using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Security
{
    public class Authentication(ICustomerRepository repository, IJwtGenerator jwt) : IAuthentication
    {
        public async Task<Customer> LoginRequest(LoginDto request)
        {
            try
            {
                var customer = await ValidateLogin(request);

                if (customer != null)
                {
                    customer.JwtToken = jwt.GetJwt(customer);

                    return customer;
                }
                else
                    return null;


            }

            catch (Exception ex)
            { 
                throw new ArgumentException(ex.Message); 
            }
        }

        private async Task<Customer> ValidateLogin(LoginDto request)
        {
            try
            {
                Customer customer = await repository.Login(request);

                bool IsValid()
                {
                    if (customer != null &&
                        request.EmailAddress == customer.EmailAddress &&
                        BCrypt.Net.BCrypt.Verify(request.Password, customer.HashedPassword))
                        return true;
                    return false;
                }

                if (IsValid())
                    return customer;
                else
                    return null;
            }

            catch (Exception ex)
            { 
                throw new ArgumentException(ex.Message); 
            }
        }
    }
}
