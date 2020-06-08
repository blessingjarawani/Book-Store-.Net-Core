using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoookStoreDatabase2.BLL.Infrastructure.Shared.Dictionaries.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BoookStoreDatabase2.WEB.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ApplicationUsersController : Controller
    {
        private IApplicationUsersService _applicationUsersService { get; }

        public ApplicationUsersController(IApplicationUsersService applicationUsersService)
        {
            _applicationUsersService = applicationUsersService;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _applicationUsersService.GetAllUsers();
            return View(users.Data);
        }
       
    }
}