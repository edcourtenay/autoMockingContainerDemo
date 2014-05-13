using System;
using System.Web.Mvc;
using AMCDemo.Web.Interfaces;
using AMCDemo.Web.ViewModels;

namespace AMCDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGreetingService _greetingService;
        private readonly IDateService _dateService;

        public HomeController(IGreetingService greetingService, IDateService dateService)
        {
            _greetingService = greetingService;
            _dateService = dateService;
        }

        public ViewResult Index()
        {
            return View("Index", new HomeIndexViewModel {
                Greeting = "Hello DevWeek!",
                Date = new DateTime(2014, 4, 2)
            });
        }
    }
}