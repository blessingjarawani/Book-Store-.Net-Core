using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Dictionary.Dictionary;

namespace BoookStoreDatabase2.WEB.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IProductsService _productsService { get; }

        public ProductController(IWebHostEnvironment hostingEnvironment, IProductsService productsService)
        {
            _hostingEnvironment = hostingEnvironment;
            _productsService = productsService;
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Index(bool ? price = null , bool ? name = null)
        {
            
            var result = await _productsService.GetProducts();
            if (price.HasValue && price.Value == true)
            {
                result.Data = result.Data?.OrderBy(x => x.Price).ToList();
            }
            if (name.HasValue && name.Value == true)
            {
                result.Data = result.Data?.OrderBy(x => x.Name).ToList();
            }
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Movies(bool? price = null, bool? name = null)
        {
            var result = await _productsService.GetProducts(ProductType.Movies.ToString());
            if (price.HasValue && price.Value == true)
            {
                result.Data = result.Data?.OrderBy(x => x.Price).ToList();
            }
            if (name.HasValue && name.Value == true)
            {
                result.Data = result.Data?.OrderBy(x => x.Name).ToList();
            }
            return View("index", result.Data);
        }

       [HttpGet]
        public async Task<IActionResult> Books()
        {
            var result = await _productsService.GetProducts(ProductType.Books.ToString());
            return View("index", result.Data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var product = new ProductsDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    ImagePath = uniqueFileName,
                    ProductType = model.ProductType,
                    Price = model.Price,
                    Quantity = model.Quantity
                };

                var result = await _productsService.AddProduct(product);
                if (result.Success)
                    return RedirectToAction("details", new { id = result.Data });
                return View();
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _productsService.GetProduct(id);
            return View(result.Data);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productsService.GetProduct(id);
            if (!result.Success)
                return View();
            var editViewModel = new EditProductViewModel
            {
                ExistingPhotoPath = result.Data.ImagePath,
                Id = result.Data.Id,
                Name = result.Data.Name,
                ProductType = result.Data.ProductType,
                Quantity = result.Data.Quantity,
                Price = result.Data.Price
            };

            return View(editViewModel);
        }
    }
}
