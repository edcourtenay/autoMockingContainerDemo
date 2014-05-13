using AMCDemo.Web.Interfaces;

namespace AMCDemo.Web.Services
{
    public class GreetingService : IGreetingService {
        public string GetGreeting()
        {
            return "Hello DevWeek!";
        }
    }
}