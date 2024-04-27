using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProductsRequest();
        public Task<Product> GetProductByIdRequest(int id);
        public Task<bool> AddNewProductRequest(Product product);
        public Task<bool> UpdateProductInfoRequest(Product product);
        public Task<bool> DeleteProductRequest(int id);
    }
}
