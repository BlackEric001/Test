using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastucture.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculationService _service;

        public HomeController(ICalculationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(InputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Err"] = "Error: Input Error";
                return View();
            }

            try
            {
                ViewData["Result"] = await _service.Calculate(inputModel);
                ViewData["Err"] = String.Empty;
            }
            catch (Exception ex)
            {
                ViewData["Result"] = String.Empty;
                ViewData["Err"] = ex.Message;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
