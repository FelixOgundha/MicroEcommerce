using Mango.Services.ProductsAPI.Models.Dto;

namespace Mango.Services.ProductsAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<bool> DeleteProduct(int id);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
    }
}
