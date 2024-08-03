using AutoMapper;
using Mango.Services.ProductsAPI.DataDbContext;
using Mango.Services.ProductsAPI.Models;
using Mango.Services.ProductsAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductsAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = await _db.Products.FirstOrDefaultAsync(q => q.ProductId == productDto.ProductId);
            Product updatedProduct = _mapper.Map<ProductDto,Product>(productDto);

            if (product == null){
                _db.Products.Add(updatedProduct);
            }

            _db.Products.Update(updatedProduct);

            await _db.SaveChangesAsync();

            return productDto;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(q => q.ProductId == id);

                if (product == null) { return false; }

                _db.Remove(product);
                await _db.SaveChangesAsync();

                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _db.Products.Where(q => q.ProductId == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productsList = await _db.Products.ToListAsync();

            var result = _mapper.Map<List<ProductDto>>(productsList);

            return result;
        }
    }
}
