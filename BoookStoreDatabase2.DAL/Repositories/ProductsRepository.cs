using AutoMapper;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.DAL.Context;
using BoookStoreDatabase2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.DAL.Repositories
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository(StoreContext storeDBContext, IMapper mapper = null) : base(storeDBContext, mapper)
        {
        }


        public async Task<List<ProductsDTO>> GetProducts(string productType = null)
        {
            var productsResult = await Task.Run(() => _dbContext.Products.Where(x => x.IsActive));
            if (!string.IsNullOrWhiteSpace(productType))
            {
                Enum.TryParse(productType, out ProductType productEnum);
                productsResult = productsResult.Where(x => x.ProductType == productEnum);
            }
            return _mapper.Map<List<ProductsDTO>>(productsResult);
        }


        public async Task<ProductsDTO> GetProduct(int id)
        {
            var productsResult = await Task.Run(() => _dbContext.Products.FirstOrDefault(x => x.Id == id));
            return _mapper.Map<ProductsDTO>(productsResult);
        }

        public async Task<int> AddOrUpdate(ProductsDTO productsDTO)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == productsDTO.Id);
            if (product != null)
            {
                UpdateProduct(productsDTO, product);
            }
            else
            {
               product = AddProduct(productsDTO);
            }

            return await SaveChangesAsync() == true ? product.Id : 0;
        }

        private void UpdateProduct(ProductsDTO productsDTO, Product product)
        {
            product.Name = productsDTO.Name;
            product.ImagePath = productsDTO.ImagePath;
            product.IsActive = true;
            product.Quantity = productsDTO.Quantity;
            product.ProductType = productsDTO.ProductType;
            product.Price = productsDTO.Price;
        }
        private Product AddProduct(ProductsDTO productsDTO)
        {
            var product = new Product
            {
                Id = GenerateId(),
                Name = productsDTO.Name,
                ImagePath = productsDTO.ImagePath,
                IsActive = true,
                Quantity = productsDTO.Quantity,
                ProductType = productsDTO.ProductType,
                Price = productsDTO.Price
            };
            _dbContext.Products.Add(product);
            return product;
        }

        private int GenerateId() =>
            _dbContext.Products.OrderByDescending(x => x.Id).FirstOrDefault()?.Id + 1 ?? 1;


    }
}
