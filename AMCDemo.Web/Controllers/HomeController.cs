using System;
using System.Web.Mvc;
using AMCDemo.Web.ViewModels;

namespace AMCDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Index", new HomeIndexViewModel {
                Greeting = "Hello DevWeek!",
                Date = new DateTime(2014, 4, 2)
            });
        }
    }
}