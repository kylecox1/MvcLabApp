using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcLabApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcLabApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ResultViewModel _messageViewModel;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _messageViewModel = new ResultViewModel();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Result(CalculatorViewModel model, string operation)
        {
            switch (operation)
            {
                case "Plus":
                    return RedirectToAction("Plus", new { num1 = model.Num1, num2 = model.Num2 });
                case "Minus":
                    return RedirectToAction("Minus", new { num1 = model.Num1, num2 = model.Num2 });
                case "Multiply":
                    return RedirectToAction("Multiply", new { num1 = model.Num1, num2 = model.Num2 });
                case "Divide":
                    return RedirectToAction("Divide", new { num1 = model.Num1, num2 = model.Num2 });
            }

            return Content($"Your answer is {model.Num1}");
        }

        public IActionResult Plus(double num1, double num2)
        {
            double result = num1 + num2;
            _messageViewModel.Message = $"The result is: {result}";
            return View("Message", _messageViewModel);
            ;
        }

        public IActionResult Minus(double num1, double num2)
        {
            double result = num1 - num2;
            _messageViewModel.Message = $"The result is: {result}";
            return View("Message", _messageViewModel);
            ;
        }

        public IActionResult Multiply(double num1, double num2)
        {
            double result = num1 * num2;
            _messageViewModel.Message = $"The result is: {result}";
            return View("Message", _messageViewModel);
            ;
        }

        public IActionResult Divide(double num1, double num2)
        {
            double result = num1 / num2;
            _messageViewModel.Message = $"The result is: {result}";
            return View("Message", _messageViewModel);
            ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
