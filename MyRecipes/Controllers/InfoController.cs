using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyRecipes.Options;
using MyRecipes.ViewModels;
using System;

namespace MyRecipes.Controllers
{
    public class InfoController : Controller
    {
        private readonly IOptions<ContactUsInfo> contactUsOptions;

        public InfoController(IOptions<ContactUsInfo> contactUsOptions)
        {
            this.contactUsOptions = contactUsOptions;
        }

        public IActionResult AboutUs()
        {
            ViewBag.CompanyName = "Code Academy";
            ViewBag.CurrentDate = DateTime.Now.ToString();
            return View();
        }

        public IActionResult ContactUs()
        {
            var viewModel = new ContactUsModel();
            viewModel.Email = contactUsOptions.Value.Email;
            viewModel.Phone = contactUsOptions.Value.Phone;

            return View(viewModel);
        }
    }
}
