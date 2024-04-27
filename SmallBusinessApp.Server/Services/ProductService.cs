using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Services
{
    public class ProductService(IPrimaryRepository<Product> repository) : IProductService
    {
        public async Task<List<Product>> GetAllProductsRequest()
        {
            var productList = await repository.GetAll();
            return productList;
        }

        public async Task<Product> GetProductByIdRequest(int id)
        {
            var product = await repository.GetById(id);
            return product;
        }

        public async Task<bool> AddNewProductRequest(Product product)
        {
            product.ProductId = Guid.NewGuid();
            var result = await repository.Add(product);
            return result;
        }

        public async Task<bool> UpdateProductInfoRequest(Product product)
        {
            var result = await repository.Update(product);
            return result;
        }

        public async Task<bool> DeleteProductRequest(int id)
        {
            var result = await repository.Delete(id);
            return result;
        }
    }
}
