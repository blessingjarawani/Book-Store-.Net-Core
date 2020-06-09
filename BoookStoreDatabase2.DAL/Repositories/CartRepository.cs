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
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.DAL.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(StoreContext storeDbContext, IMapper mapper) : base(storeDbContext, mapper)
        {

        }

        public async Task<List<OrderLineDTO>> GetCustomerOrder(int customerId)
        {
            var result = await Task.Run(() => _dbContext.OrderLines
             .Where(x => x.CustomerId == customerId && x.IsActive)?.Include(x => x.Product)
             .Select(fl => new { fl.CustomerId, fl.ProductId, fl.Price, fl.Quantity, fl.Product.Name, fl.Product.ProductType }).AsEnumerable()
                         .GroupBy(fl => new { fl.CustomerId })
                         .Select(fl => new OrderLineDTO
                         {
                             CustomerId = fl.Key.CustomerId,
                             Products = fl.Select(y =>
                             new ProductsDTO
                             {
                                 Id = y.ProductId,
                                 Quantity = y.Quantity,
                                 Name = y.Name,
                                 Price = y.Price,
                                 ProductType = y.ProductType
                             }).ToList()
                         })
            );
            return result?.ToList();
        }



        public async Task<bool> AddToCart(AddToCartCommand cartCommand)
        {
            var orderLine = new OrderLines
            {
                Id = GenerateId(),
                IsActive = true,
                CustomerId = cartCommand.CustomerId,
                Quantity = 1,
                Price = cartCommand.Product.Price,
                CartStatus = CartStatus.Inprogress,
                ProductId = cartCommand.Product.Id
            };
            await _dbContext.OrderLines.AddAsync(orderLine);
            return await SaveChangesAsync();
        }

        private int GenerateId() =>
          _dbContext.OrderLines.OrderByDescending(x => x.Id).FirstOrDefault()?.Id + 1 ?? 1;
    }
}
