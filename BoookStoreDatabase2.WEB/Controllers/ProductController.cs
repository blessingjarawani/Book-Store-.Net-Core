using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.WEB.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoookStoreDatabase2.WEB.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Movies()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
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
                    Name = model.Name,
                    ImagePath = uniqueFileName,
                    ProductType = model.ProductType,
                    Price = model.Price,
                    Quantity = model.Quantity
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }

    }
}
}