using Microsoft.AspNetCore.Mvc;
using MVCViews.Models;
using System.Diagnostics;

namespace MVCViews.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet] // HttpGet metoduyla sayfayı getiriyoruz
        public IActionResult Personel()
        {
            return View();
        }

        [HttpPost] // HttpPost metoduyla sayfadan gelecek olan verileri alabiliyoruz
        public IActionResult Personel(Personel personel)
        {
            if (ModelState.IsValid) // ModelState : Modelim geçerli ise?
            {
                string personelBilgi = " ";
                personelBilgi = "Personel Bilgileri(Ad,Soyad,Yas): "+ personel.Ad + " " + personel.Soyad + " " + personel.Yas.ToString();
                ViewBag.Mesaj = personelBilgi;
            }
            return View(personel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}