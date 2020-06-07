using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productsRepository { get; }
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }


    }
}
