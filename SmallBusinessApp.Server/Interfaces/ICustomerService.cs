using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAllCustomersRequest();
        public Task<Customer> GetCustomerByIdRequest(int id);
        public Task<bool> UpdateCustomerInfoRequest(Customer customer);
        public Task<bool> DeleteCustomerRequest(int id);
        public Task<bool> AddNewCustomerRequest(CustomerDto request);
    }
}
