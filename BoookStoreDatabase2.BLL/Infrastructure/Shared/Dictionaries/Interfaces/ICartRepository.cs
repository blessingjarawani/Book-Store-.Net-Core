using BoookStoreDatabase2.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces
{
    public interface ICartRepository
    {
        Task<List<OrderLineDTO>> GetCustomerOrder(int customerId);
        Task<bool> AddToCart(AddToCartCommand cartCommand);

    }
}
