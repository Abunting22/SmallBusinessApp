using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> Login(LoginDto request);
    }
}
