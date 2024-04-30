using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;
using BCrypt;

namespace SmallBusinessApp.Server.Services
{
    public class CustomerService(IPrimaryRepository<Customer> repository) : ICustomerService
    {
        public async Task<List<Customer>> GetAllCustomersRequest()
        {
            var customerList = await repository.GetAll();
            return customerList;
        }
        public async Task<Customer> GetCustomerByIdRequest(int id)
        {
            var customer = await repository.GetById(id);
            return customer;
        }

        public async Task<bool> UpdateCustomerInfoRequest(Customer customer)
        {
            var result = await repository.Update(customer);
            return result;
        }

        public async Task<bool> DeleteCustomerRequest(int id)
        {
            var result = await repository.Delete(id);
            return result;
        }

        public async Task<bool> AddNewCustomerRequest(CustomerDto request)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            var result = await repository.Add(customer);
            return result;
        }
    }
}
