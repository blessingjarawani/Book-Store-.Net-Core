using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.DAL.Entities;
using BoookStoreDatabase2.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.WEB.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : BaseController
    {
        public ICartService _cartService { get; }
        public IProductsService _productsService { get; }

        public CartController(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, ICartService cartService, IProductsService productsService) : base(httpContextAccessor, userManager)
        {
            _cartService = cartService;
            _productsService = productsService;
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            if (ModelState.IsValid && id > 0)
            {
                var userId = await GetUserId();
                var product = await _productsService.GetProduct(id);
                if (!product.Success)
                {
                }
                var command = new AddToCartCommand
                {
                    CustomerId = userId,
                    Product = product.Data
                };
                var result = await _cartService.AddToCart(command);
                if (result.Success)
                {
                    return RedirectToAction("Details","Cart");
                }

                return RedirectToAction(product.Data.ProductType.ToString(), "Product");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var userId = await GetUserId();
            var result = await _cartService.GetCustomerCart(userId);
            if (!result.Success)
            {
                return View(null);
            }
            return View(result.Data);
        }
    }
}