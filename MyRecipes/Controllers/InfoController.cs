using Microsoft.AspNetCore.Mvc;
using System;

namespace MyRecipes.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AboutUs()
        {
            ViewBag.CompanyName = "Code Academy";
            ViewBag.CurrentDate = DateTime.Now.ToString();
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
