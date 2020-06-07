using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Responses;
using BoookStoreDatabase2.BLL.Models.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.BLL.Infrastructure.Shared.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productsRepository { get; }
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Response<List<ProductsDTO>>> GetProducts(string productType = null)
        {
            try
            {
                var result = await _productsRepository.GetProducts(productType);
                return new Response<List<ProductsDTO>> { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new Response<List<ProductsDTO>> { Success = false, Message = ex.GetBaseException().Message };
            }

        }

        public async Task<Response<ProductsDTO>> GetProduct(int id)
        {
            try
            {
                var result = await _productsRepository.GetProduct(id);
                return new Response<ProductsDTO> { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new Response<ProductsDTO> { Success = false, Message = ex.GetBaseException().Message };
            }

        }

        public async Task<Response<int>> AddProduct(ProductsDTO productsDTO)
        {
            try
            {
                if (productsDTO != null)
                {
                    var result = await _productsRepository.AddOrUpdate(productsDTO);
                    return result > 0 ? new Response<int> { Success = true, Data = result } : new Response<int> { Success = false, Message = "Failed to Add Product" };
                }
                return new Response<int> { Success = false, Message = "Invalid Product DTO" };
            }
            catch (Exception ex)
            {
                return new Response<int> { Success = false, Message = ex.GetBaseException().Message };
            }
        }

    }
}
