using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Responses;
using BoookStoreDatabase2.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository { get; }

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Response<bool>> AddToCart(AddToCartCommand addToCartCommand)
        {
            try
            {
                if (!addToCartCommand.IsValid)
                {
                    return new Response<bool> { Success = false, Message = "Invalid Object" };
                }
                var result = await _cartRepository.AddToCart(addToCartCommand);
                return result ?  new Response<bool> { Success = true, Data = result } :new Response<bool> { Success = false, Message = "Invalid Object" };

            }
            catch (Exception ex)
            {
                return new Response<bool> { Success = false, Message = ex.GetBaseException().Message };
            }

        }

        public async Task<Response<List<OrderLineDTO>>> GetCustomerCart(int customerId)
        {
            try
            {
                var result = await _cartRepository.GetCustomerOrder(customerId);
                return new Response<List<OrderLineDTO>> { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new Response<List<OrderLineDTO>> { Success = false, Message = ex.GetBaseException().Message };
            }
        }
    }
}
