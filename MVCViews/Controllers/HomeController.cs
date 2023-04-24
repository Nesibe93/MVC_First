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

        [HttpPost] // HttpPost metoduyla sayfadan gelecek olan verileri alabiliyoruz.Attribute
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
        [HttpGet] // HttpGet metoduyla sayfayı getiriyoruz
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] // Login sayfasından gelen verileri alıyor
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid) // ModelState : Modelim geçerli ise?
            {
                //string Giris = " ";
                //Giris = "Login(UserID,Password): " + Login.UserID + " " + Login.Password;
                if (login.UserID == "nes" && login.Password == "1234")
                {
                    ViewBag.Mesaj = "Başarılı Giriş";
                    return View("Congrats");
                }
                else
                {
                    ViewBag.Mesaj = "Hatalı Giriş";
                }
            }
            return View(login);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Razor()
        {
            return View();
        }
    }
}