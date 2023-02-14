using HouseOutlook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HouseOutlook.Core.Interface;

namespace HousingOutlook2.Controllers
{
    public class HomeController : Controller
    {

        private readonly IHouseServices _hotelServices;

        public HomeController(IHouseServices hotelServices)
        {
            _hotelServices = hotelServices;


        }


        // GET: Students
        public async Task<IActionResult> Index()
        {

            ViewBag.message = HttpContext.Session.GetString("userId");
            ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
            return View(await _hotelServices.GetAllHouseAsync());
        }


        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var hotel = await _hotelServices.GetHouseByIdAsync(id);

                if (HttpContext.Session.GetString("userId") != null)
                {
                    ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
                    ViewBag.message = HttpContext.Session.GetString("userId");
                    return View(hotel);
                }
                return RedirectToAction("Login", "Authentication");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return NotFound();
            }

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
