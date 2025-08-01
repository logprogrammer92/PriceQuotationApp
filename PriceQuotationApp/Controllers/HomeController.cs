using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PriceQuotationApp.Models;

namespace PriceQuotationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Initialize a new PriceQuote object to pass to the view
            PriceQuote priceQuote = new();
            // Pass the model to the view
            return View(priceQuote);
        }

        [HttpPost]
        public IActionResult index(PriceQuote priceQuote)
        {
            if (ModelState.IsValid)
            {
                // Process the valid quote
                return View(priceQuote);
            }
            else
            {
                // The model is invalid, so we return the Index view with validation errors
                return View(priceQuote);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
