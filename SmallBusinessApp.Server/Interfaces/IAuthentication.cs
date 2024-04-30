using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface IAuthentication
    {
        public Task<Customer> LoginRequest(LoginDto request);
    }
}
