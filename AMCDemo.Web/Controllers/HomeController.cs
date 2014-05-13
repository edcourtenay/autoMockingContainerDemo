using System.Web.Mvc;

namespace AMCDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return new ViewResult();
        }
    }
}