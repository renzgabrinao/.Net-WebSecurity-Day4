using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public ShopController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Index()
        {
            ShopRepo shopRepo = new(_context);

            var items = shopRepo.GetProducts();

            return View("Index", items);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Transactions()
        {
            DbSet<IPN> items = _context.IPNs;

            return View(items);
        }

        // This method receives and stores
        // the Paypal transaction details.
        [HttpPost]
        public JsonResult PaySuccess([FromBody] IPN ipn)
        {
            try
            {
                _context.IPNs.Add(ipn);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(ipn);
        }

        // Home page shows list of items.
        // Item price is set through the ViewBag.
        public IActionResult Confirmation(string paymentID)
        {
            IPN transaction =
                _context.IPNs.FirstOrDefault(t => t.paymentID == paymentID);

            return View("Confirmation", transaction);
        }

    }
}