using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface IJwtGenerator
    {
        public string GetJwt(Customer customer);
    }
}
