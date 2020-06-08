using AutoMapper;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.DAL.Context;
using BoookStoreDatabase2.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.DAL.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(StoreContext storeDbContext, IMapper mapper) : base(storeDbContext, mapper)
        {

        }

        //public async Task<int> GetCustomerOrder(int customerId)
        //{
        //    var result = await _dbContext.Orders.Where(x => x.CustomerId == customerId)
        //        .Include(x => x.Customer).Include(y => y.OrderLines)?.ToListAsync();
        //}

        //private async Task<Order> GetActiveOrder(int customerId)
        //{
        //    return await Task.Run(() => _dbContext.Orders
        //       .Include(x => x.Customer).Include(y => y.OrderLines)
        //       .FirstOrDefault(x => x.CustomerId == customerId && x.IsActive));
        //}

        //public async Task<bool> AddToCart(OrderDTO orderDTO)
        //{

        //}
    }
}
