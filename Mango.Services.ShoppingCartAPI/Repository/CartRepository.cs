using AutoMapper;
using Mango.Services.ShoppingCartAPI.DataDbContext;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CartRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> CreateCart(CartDto cartDto)
        {
            Cart cart = _mapper.Map<Cart>(cartDto);
            
            //Check if product exsits in Database
            var productInDb = await _db.Products.FirstOrDefaultAsync(u=>u.ProductId == cartDto.CartDetails.FirstOrDefault().ProductId);

            if (productInDb == null) { 
                await _db.Products.AddAsync(cart.CartDetails.FirstOrDefault().Product);
                await _db.SaveChangesAsync();

             
                _db.CartHeaders.Add(cart.CartHeader);
                await _db.SaveChangesAsync();

                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
                cart.CartDetails.FirstOrDefault().Product = null;
                _db.CartDetails.Add(cart.CartDetails.FirstOrDefault());

                await _db.SaveChangesAsync();

                return cartDto;
            }

            return null;
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> UpdateCart(CartDto cartDto)
        {
            throw new NotImplementedException();
        }
    }
}
